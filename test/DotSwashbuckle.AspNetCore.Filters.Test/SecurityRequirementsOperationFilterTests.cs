﻿using Shouldly;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using Xunit;
using System.Linq;
using static DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Fakes.FakeControllers;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Fakes;

namespace DotSwashbuckle.AspNetCore.Filters.Test
{
    public class SecurityRequirementsOperationFilterTests : BaseOperationFilterTests
    {
        private readonly IOperationFilter sut;

        public SecurityRequirementsOperationFilterTests()
        {
            sut = new SecurityRequirementsOperationFilter();
        }

        [Fact]
        public void Apply_SetsAuthorize_WithNoPolicy()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.Authorize));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            securityScheme.Value.Count().ShouldBe(0);
        }

        [Fact]
        public void Apply_SetsAuthorize_WithNoPolicy_WhenCustomSecuritySchemaIsSet()
        {
            // Arrange
            const string securitySchemaName = "customSchema";
            var sut = new SecurityRequirementsOperationFilter(true, securitySchemaName);
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.Authorize));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == securitySchemaName);
            securityScheme.Value.ShouldNotBeNull();
            securityScheme.Value.Count().ShouldBe(0);
        }
        [Fact]
        public void Apply_SetsAuthorize_WithMultipleSecuritySchemas()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.Authorize));

            const string securitySchemaName = "customSchema";
            var sut = new SecurityRequirementsOperationFilter();
            var sut2 = new SecurityRequirementsOperationFilter(true, securitySchemaName);

            // Act
            sut.Apply(operation, filterContext);
            sut2.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(2);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            securityScheme.Value.Count().ShouldBe(0);

            var securityScheme2 = operation.Security[1].SingleOrDefault(ss => ss.Key.Reference.Id == securitySchemaName);
            securityScheme2.Value.ShouldNotBeNull();
            securityScheme2.Value.Count().ShouldBe(0);
        }

        [Fact]
        public void Apply_DoesNotSetSecurity_WhenNoAuthorize()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.None));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(0);
        }

        [Fact]
        public void Apply_Adds401And403_ToResponses()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.Authorize));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Responses["401"].Description.ShouldBe("Unauthorized");
            operation.Responses["403"].Description.ShouldBe("Forbidden");
        }

        [Fact]
        public void Apply_DoesNotAdd401And403_WhenConfiguredNotTo()
        {
            // Arrange
            var sut = new SecurityRequirementsOperationFilter(false);
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.Authorize));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Responses.ShouldNotContainKey("401");
            operation.Responses.ShouldNotContainKey("403");
        }

        [Fact]
        public void Apply_DoesNotCrash_When403AlreadyPresent()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            var filterContext = FilterContextFor(typeof(AuthController), nameof(AuthController.Customer));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Responses.ShouldContainKey("401");
            operation.Responses.ShouldContainKey("403");
            operation.Responses.Count.ShouldBe(2);
        }

        [Fact]
        public void Apply_DoesNotCrash_When401AlreadyPresent()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

            var filterContext = FilterContextFor(typeof(AuthController), nameof(AuthController.Customer));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Responses.ShouldContainKey("401");
            operation.Responses.ShouldContainKey("403");
            operation.Responses.Count.ShouldBe(2);
        }

        [Fact]
        public void Apply_SetsAuthorize_WithOnePolicy()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.AuthorizeAdministratorPolicy));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            var policies = securityScheme.Value;
            policies.Single().ShouldBe("Administrator");
        }

        [Fact]
        public void Apply_SetsAuthorize_WithMultiplePolicies()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(FakeActions), nameof(FakeActions.AuthorizeMultiplePolicies));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            var policies = securityScheme.Value;
            policies.Count().ShouldBe(2);
            policies.ShouldContain("Administrator");
            policies.ShouldContain("Customer");
        }

        [Fact]
        public void Apply_SetsAuthorize_WithController()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(AuthController), nameof(AuthController.None));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            securityScheme.Value.Count().ShouldBe(0);
        }

        [Fact]
        public void Apply_SetsAuthorize_WithControllerAndMethod()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(AuthController), nameof(AuthController.Customer));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            var policies = securityScheme.Value;
            policies.Single().ShouldBe("Customer");
        }

        [Fact]
        public void Apply_DoesNotSetSecurity_WhenActionHasAllowAnonymous()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(AuthController), nameof(AuthController.AllowAnonymous));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(0);
        }

        [Fact]
        public void Apply_DoesNotSetSecurity_WhenControllerHasAllowAnonymous()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(AllowAnonymousController), nameof(AllowAnonymousController.Customer));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(0);
        }

        [Fact]
        public void Apply_SetsAuthorizeToTheActionFromBaseController_WithController()
        {
            // Arrange
            var operation = new OpenApiOperation { OperationId = "foobar", Responses = new OpenApiResponses() };
            var filterContext = FilterContextFor(typeof(AuthControllerDerived), nameof(AuthController.None));

            // Act
            sut.Apply(operation, filterContext);

            // Assert
            operation.Security.Count.ShouldBe(1);
            var securityScheme = operation.Security[0].SingleOrDefault(ss => ss.Key.Reference.Id == "oauth2");
            securityScheme.Value.ShouldNotBeNull();
            securityScheme.Value.Count().ShouldBe(0);
        }
    }
}
