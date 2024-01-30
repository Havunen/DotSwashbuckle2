﻿using System;
using System.Reflection;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class PropertyInfoExtensions
    {
        public static bool HasAttribute<TAttribute>(this PropertyInfo property)
            where TAttribute : Attribute
        {
            return property.GetCustomAttribute<TAttribute>() != null;
        }

        public static bool IsPubliclyReadable(this PropertyInfo property)
        {
            return property.GetMethod?.IsPublic == true;
        }

        public static bool IsPubliclyWritable(this PropertyInfo property)
        {
            return property.SetMethod?.IsPublic == true;
        }
    }
}
