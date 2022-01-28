namespace VectorViewer.Utils
{
    using System;
    using System.Linq;

    public static class TypeUtils
    {
        public static bool Implements(this Type type, Type @interface)
        {
            return @interface.IsGenericType
                ? type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == @interface)
                : @interface.IsAssignableFrom(type);
        }
    }
}