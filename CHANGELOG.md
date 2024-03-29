# v3.0.2
- Fixes an issue where nullable is not defined for primitive response type schema https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2731
- Fixes an issue where nested record types nullable does not get generated correctly https://github.com/Havunen/DotSwashbuckle/commit/ab7e8e681888034fa9157565eaf45ec18703849b
- Adds support for Length attribute https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2756

# v3.0.1
- Adds support for required property modifiers. Fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2764
- DotSwashbuckle dependencies are now defined with open version to allow applications update them

# v3.0.0
- Adds support for using `<remarks>` on schema XML comments.
When using `<remarks>` on a class, it will be used as the description for the schema.
When there is also `<summary>` defined, the `<summary>` will be used as the title for the schema.
When `<summary>` is defined alone it is used as description for the schema.
- Adds support for defining examples using `SwaggerSchemaAttribute`.
- Adds support for custom Required and Binding attributes
- Fixes an issue where UniqueItems is not set true for `IReadOnlySet<T>` 
- Adds support for `WithSummary` and `WithDescription` metadata
- Improve performance of IsRequiredSpecified method
- Fixes an issue where query string parameters crash OpenApi path generation `System.ArgumentException: Literal sections cannot contain the '?' character.`
- For more details see: https://github.com/Havunen/DotSwashbuckle/issues/1

## Breaking Changes
- `ReDoc` has been renamed to `Redoc`, this applies to all methods and types. Including the Nuget package name `DotSwashbuckle.AspNetCore.Redoc`

# v2.0.0

- XML comments parsing performance has been improved
- Add support for JsonPolymorphic and JsonDerivedType attributes
- DotSwashbuckle.AspNetCore.Filters added
- DotSwashbuckle.AspNetCore.Filters.Abstractions added

## Removed following obsolete features:

- SwaggerGenOptionsExtensions.TagActionsBy overload -> "Use the overload that accepts a Func that returns a list of tags"
- SwaggerGenOptionsExtensions.GeneratePolymorphicSchemas -> You can use \"UseOneOfForPolymorphism\", \"UseAllOfForInheritance\" and \"SelectSubTypesUsing\" to configure equivalent behavior
- DataContract.ForPrimitive -> "Provide jsonConverter function instead of enumValues"
- DataContract.EnumValues -> Use JsonConverter instead
- ApiDescriptionExtensions.GetAdditionalMetadata -> "Use TryGetMethodInfo() and CustomAttributes() instead"
- ApiParameterDescriptionExtensions.GetAdditionalMetadata -> "Use ParameterInfo(), PropertyInfo() and CustomAttributes() extension methods instead"
- SwaggerUIOptionsExtensions.ValidatorUrl -> "The validator is disabled by default. Use EnableValidator to enable it"
- SwaggerSubType, SwaggerSubTypesAttribute and SwaggerDiscriminator has been removed, use JsonPolymorphic and JsonDerivedType instead
