using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleIoC
{
    public class DIContainer
    {
        private static readonly Dictionary<Type, object> RegisteredModules = new Dictionary<Type, object>();

        // public 

        public static void SetModule<TInterface, TModule>()
        {
            SetModule(typeof(TInterface), typeof(TModule));
        }
        public static T GetModule<T>()
        {
            return (T) GetModule(typeof(T));
        }
        
        // private
        private static object GetModule(Type interfaceType)
        {
            if (!RegisteredModules.ContainsKey(interfaceType)) throw new Exception("Module not register");
            return RegisteredModules[interfaceType];
        }

        private static void SetModule(Type interfaceType, Type moduleType)
        {
            if (!interfaceType.IsAssignableFrom(moduleType)) throw new Exception("Wrong Module type");

            var firstConstructor = moduleType.GetConstructors()[0];
            object? module;
            if (!firstConstructor.GetParameters().Any()) module = firstConstructor.Invoke(null);
            else
            {
                var constructorParameter = firstConstructor.GetParameters();
                module = firstConstructor.Invoke(constructorParameter.Select(parameter => GetModule(parameter.ParameterType)).ToArray());
            }
            
            RegisteredModules.Add(interfaceType,module);
        }
    }
}