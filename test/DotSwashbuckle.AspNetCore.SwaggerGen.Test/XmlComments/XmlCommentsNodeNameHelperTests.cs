﻿using System;
using Xunit;
using Xunit.Abstractions;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class XmlCommentsNodeNameHelperTests
    {
        private readonly ITestOutputHelper _output;

        public XmlCommentsNodeNameHelperTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), "AcceptsNothing",
            "M:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.AcceptsNothing")]
        [InlineData(typeof(XmlAnnotatedType), "AcceptsNestedType",
            "M:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.AcceptsNestedType(DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.NestedType)")]
        [InlineData(typeof(XmlAnnotatedType), "AcceptsConstructedGenericType",
            "M:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.AcceptsConstructedGenericType(System.Collections.Generic.KeyValuePair{System.String,System.Int32})")]
        [InlineData(typeof(XmlAnnotatedType), "AcceptsConstructedOfConstructedGenericType",
            "M:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.AcceptsConstructedOfConstructedGenericType(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Int32}})")]
        [InlineData(typeof(XmlAnnotatedType), "AcceptsArrayOfConstructedGenericType",
            "M:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.AcceptsArrayOfConstructedGenericType(System.Nullable{System.Int32}[])")]
        public void GetMemberNameForMethod_ReturnsCorrectXmlCommentsMemberName_ForGivenMethodInfo(
            Type declaringType, 
            string name,
            string expectedMemberName)
        {
            var methodInfo = declaringType.GetMethod(name);

            var memberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(methodInfo);

            _output.WriteLine(expectedMemberName);
            _output.WriteLine(memberName);
            Assert.Equal(expectedMemberName, memberName);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType),
            "T:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType")]
        [InlineData(typeof(XmlAnnotatedType.NestedType),
            "T:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.NestedType")]
        [InlineData(typeof(XmlAnnotatedGenericType<int,string>),
            "T:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedGenericType`2")]
        [InlineData(typeof(NoNamespaceType),
            "T:NoNamespaceType")]
        public void GetMemberNameForType_ReturnsCorrectXmlCommentsMemberName_ForGivenType(
            Type type,
            string expectedMemberName
        )
        {
            var memberName = XmlCommentsNodeNameHelper.GetMemberNameForType(type);

            _output.WriteLine(expectedMemberName);
            _output.WriteLine(memberName);
            Assert.Equal(expectedMemberName, memberName);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), "StringProperty",
            "P:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.StringProperty")]
        [InlineData(typeof(XmlAnnotatedType.NestedType), "Property",
            "P:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.NestedType.Property")]
        [InlineData(typeof(XmlAnnotatedType.NestedType.InnerNestedType), "InnerProperty",
            "P:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedType.NestedType.InnerNestedType.InnerProperty")]
        [InlineData(typeof(XmlAnnotatedGenericType<int,string>), "GenericProperty",
            "P:DotSwashbuckle.AspNetCore.SwaggerGen.Test.XmlAnnotatedGenericType`2.GenericProperty")]
        public void GetMemberNameForProperty_ReturnsCorrectXmlCommentMemberName_ForGivenMemberInfo(
            Type declaringType,
            string fieldOrPropertyName,
            string expectedMemberName
        )
        {
            var memberInfo = declaringType.GetMember(fieldOrPropertyName)[0];

            var memberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(memberInfo);

            _output.WriteLine(expectedMemberName);
            _output.WriteLine(memberName);
            Assert.Equal(expectedMemberName, memberName);
        }
    }
}
