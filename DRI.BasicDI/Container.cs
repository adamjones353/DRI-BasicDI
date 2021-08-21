using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DRI.BasicDI.Exceptions;

namespace DRI.BasicDI
{
    public sealed class Container : List<Type>
    {
        public void Register<T>()
        {
            if(Contains(typeof(T)))
            {
                throw new AlreadyRegisteredException($"Type {typeof(T)} is already registered");
            }

            Add(typeof(T));
        }

        public int Registrations()
        {
            return Count;
        }

        public T GetInstance<T>(params object[] args)
        {
            if (!Contains(typeof(T)))
            {
                throw new UnregisteredDependencyException($"Type {typeof(T)} is not registered");
            }         
            
            return (T)Activator.CreateInstance(typeof(T), GetDependencies<T>(args));
        }

        private object[] GetDependencies<T>(params object[] args)
        {
            var ctor = typeof(T).GetConstructors().Single();
            var paramTypes = ctor.GetParameters().Select(p => p.ParameterType);

            CheckForCircularDependancey(typeof(T));

            return paramTypes.Select(x =>
            {
                MethodInfo method = typeof(Container).GetMethod(nameof(GetInstance));
                MethodInfo generic = method.MakeGenericMethod(x);
                try
                {
                    return generic.Invoke(this, null);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException; // reflection handles errors inside so need to catch the internal exception.
                }
                
            }).ToArray();
        }

        private void CheckForCircularDependancey(Type parent, params Type[] childrenTypes)
        {
            var combine = childrenTypes.ToList();
            var ctor = parent.GetConstructors().Single();
            var paraments = ctor.GetParameters().Select(p => p.ParameterType).ToList();

            if (combine.Count == 0)
            {
                combine.Add(parent);
            }
                      
            combine.AddRange(paraments);

            if (combine.Count != combine.Distinct().Count())
            {
                throw new CircularDependencyException();
            }
                                  
            foreach(Type param in paraments)
            {
                CheckForCircularDependancey(param,combine.ToArray());
            }
        }
    }
}