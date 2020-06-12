using Microsoft.CSharp;
using System;
using System.CodeDom;

namespace WhattaMovie.Infrastructure
{
    public static class ExtensionMethods
    {
        public static string ToFriendlyName(this Type type)
        {
            string typeName;
            using (var provider = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(type);
                typeName = provider.GetTypeOutput(typeRef);
            }
            return typeName;
        }
    }
}
