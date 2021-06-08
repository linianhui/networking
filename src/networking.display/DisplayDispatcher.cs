using System;
using System.Collections.Generic;
using System.Reflection;

namespace Networking.Display
{
    internal class DisplayDispatcher
    {
        internal IDictionary<Type, Func<Object, Object[], Object>> DisplayMethods { get; }

        internal DisplayDispatcher(Type type)
        {
            DisplayMethods = CreateDisplayMethods(type as TypeInfo);
        }

        internal Boolean Display(Object @this, Octets octets)
        {
            var type = octets.GetType();
            if (DisplayMethods.TryGetValue(type, out var displayMethod))
            {
                _ = displayMethod(@this, new Object[] { octets });
                return true;
            }
            return false;
        }

        private static Dictionary<Type, Func<Object, Object[], Object>> CreateDisplayMethods(TypeInfo type)
        {
            var displayMethods = new Dictionary<Type, Func<Object, Object[], Object>>();
            foreach (var method in type.DeclaredMethods)
            {
                if (IsDisplayMethod(method, out var parameterType))
                {
                    displayMethods.Add(parameterType, method.Invoke);
                }
            }
            return displayMethods;
        }

        private static Boolean IsDisplayMethod(MethodBase method, out Type parameterType)
        {
            parameterType = null;
            if (method.Name != "Display")
            {
                return false;
            }
            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }
            parameterType = parameters[0].ParameterType;
            var type = typeof(Octets);
            return type != parameterType && type.IsAssignableFrom(parameterType);
        }
    }
}
