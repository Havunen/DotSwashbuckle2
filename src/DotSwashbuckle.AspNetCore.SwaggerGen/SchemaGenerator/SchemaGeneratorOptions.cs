﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SchemaGeneratorOptions
    {
        private static Dictionary<Assembly, Type[]> AssemblyTypeCache = new();

        public SchemaGeneratorOptions()
        {
            CustomTypeMappings = new Dictionary<Type, Func<OpenApiSchema>>();
            SchemaIdSelector = DefaultSchemaIdSelector;
            SubTypesSelector = DefaultSubTypesSelector;
            DiscriminatorNameSelector = DefaultDiscriminatorNameSelector;
            DiscriminatorValueSelector = DefaultDiscriminatorValueSelector;
            SchemaFilters = new List<ISchemaFilter>();
        }

        public IDictionary<Type, Func<OpenApiSchema>> CustomTypeMappings { get; set; }

        public bool UseInlineDefinitionsForEnums { get; set; }

        public Func<Type, string> SchemaIdSelector { get; set; }

        public bool IgnoreObsoleteProperties { get; set; }

        public bool UseAllOfForInheritance { get; set; }

        public bool UseOneOfForPolymorphism { get; set; }

        public Func<Type, IEnumerable<Type>> SubTypesSelector { get; set; }

        public Func<Type, string> DiscriminatorNameSelector { get; set; }

        public Func<Type, string> DiscriminatorValueSelector { get; set; }

        public bool UseAllOfToExtendReferenceSchemas { get; set; }

        public bool SupportNonNullableReferenceTypes { get; set; }

        public IList<ISchemaFilter> SchemaFilters { get; set; }

        private string DefaultSchemaIdSelector(Type modelType)
        {
            if (!modelType.IsConstructedGenericType) return modelType.Name.Replace("[]", "Array");

            var prefix = modelType.GetGenericArguments()
                .Select(genericArg => DefaultSchemaIdSelector(genericArg))
                .Aggregate((previous, current) => previous + current);

            return prefix + modelType.Name.Split('`').First();
        }

        private IEnumerable<Type> DefaultSubTypesSelector(Type baseType)
        {
            if (!AssemblyTypeCache.TryGetValue(baseType.Assembly, out var types))
            {
                types = baseType.Assembly.GetTypes();
                AssemblyTypeCache[baseType.Assembly] = types;
            }

            return types.Where(type => type.IsSubclassOf(baseType));
        }

        private string DefaultDiscriminatorNameSelector(Type baseType)
        {
            return null;
        }

        private string DefaultDiscriminatorValueSelector(Type subType)
        {
            return null;
        }
    }
}