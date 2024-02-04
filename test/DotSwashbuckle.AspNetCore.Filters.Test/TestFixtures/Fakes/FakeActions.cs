using DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotSwashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Fakes
{
    public class FakeActions
    {
        [SwaggerResponse(200, type: typeof(PersonResponse))]
        [SwaggerResponseExample(200, typeof(PersonResponseExample))]
        public IActionResult AnnotatedWithSwaggerResponseExampleAttribute()
        {
            throw new NotImplementedException();
        }

        [SwaggerResponse(200, type: typeof(PersonResponse))]
        [SwaggerResponseExample(200, typeof(PersonResponseMultipleExamples))]
        public IActionResult AnnotatedWithSwaggerResponseMultipleExamplesAttribute()
        {
            throw new NotImplementedException();
        }

        [SwaggerResponse(200, type: typeof(IEnumerable<PersonResponse>))]
        [SwaggerResponseExample(200, typeof(PeopleResponseExample))]
        public IActionResult AnnotatedWithSwaggerResponseExampleAttributeOfTypeEnumerable()
        {
            throw new NotImplementedException();
        }

        [SwaggerResponse(200, type: typeof(IEnumerable<PersonResponse>))]
        public IActionResult AnnotatedWithSwaggerResponseAttributeOfTypeEnumerable()
        {
            throw new NotImplementedException();
        }

        [SwaggerResponse(200, type: typeof(PersonResponse))]
        public IActionResult AnnotatedWithSwaggerResponseAttribute()
        {
            throw new NotImplementedException();
        }

        [SwaggerResponse(200, type: typeof(IEnumerable<string>))]
        public IActionResult GenericAnnotatedWithSwaggerResponseAttribute()
        {
            throw new NotImplementedException();
        }

        [SwaggerRequestExample(typeof(PersonRequest), typeof(PersonRequestExample))]
        public IActionResult AnnotatedWithSwaggerRequestExampleAttribute(PersonRequest personRequest)
        {
            throw new NotImplementedException();
        }

        [SwaggerRequestExample(typeof(PersonRequest), typeof(PersonRequestMultipleExamples))]
        public IActionResult AnnotatedWithSwaggerRequestMultipleExamplesAttribute(PersonRequest personRequest)
        {
            throw new NotImplementedException();
        }

        public IActionResult PersonRequestUnannotated(PersonRequest personRequest)
        {
            throw new NotImplementedException();
        }

        public IActionResult IPersonRequestUnannotated(IPersonRequest personRequest)
        {
            throw new NotImplementedException();
        }

        [SwaggerRequestExample(typeof(PersonResponse), typeof(PersonRequestExample))]
        public IActionResult AnnotatedWithIncorrectSwaggerRequestExampleAttribute(PersonRequest personRequest)
        {
            throw new NotImplementedException();
        }

        [SwaggerRequestExample(typeof(Dictionary<string, object>), typeof(DictionaryRequestExample))]
        public IActionResult AnnotatedWithDictionarySwaggerRequestExampleAttribute(Dictionary<string, object> personRequest)
        {
            throw new NotImplementedException();
        }

        public IActionResult DictionaryRequestAttribute(Dictionary<string, object> personRequest)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public IActionResult Authorize()
        {
            throw new NotImplementedException();
        }

        [Authorize("Administrator")]
        public IActionResult AuthorizeAdministratorPolicy()
        {
            throw new NotImplementedException();
        }

        [Authorize("Administrator")]
        [Authorize("Customer")]
        public IActionResult AuthorizeMultiplePolicies()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AuthorizeAdministratorRole()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Customer")]
        public IActionResult AuthorizeMultipleRoles()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator, Customer")]
        public IActionResult AuthorizeMultipleRolesInOneAttribute()
        {
            throw new NotImplementedException();
        }

        [Authorize(Policy = "Administrator")]
        [Authorize(Roles = "Customer")]
        public IActionResult AuthorizePolicyAndRole()
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        public IActionResult AllowAnonymous()
        {
            throw new NotImplementedException();
        }

        public IActionResult RequestTakesAnInt([FromBody] int blah)
        {
            throw new NotImplementedException();
        }

        public IActionResult RequestTakesANullableEnum([FromBody] Title? title)
        {
            throw new NotImplementedException();
        }

        public IActionResult None()
        {
            throw new NotImplementedException();
        }

        public PersonResponse PersonResponseNotAnnotated()
        {
            throw new NotImplementedException();
        }
    }

    [Authorize]
    public class BaseController
    {
    }

    public class FakeInheritedController : BaseController
    {
        public IActionResult Authorize()
        {
            throw new NotImplementedException();
        }
    }
}