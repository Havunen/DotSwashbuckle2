using DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotSwashbuckle.AspNetCore.Annotations;
using System;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Fakes
{
    public static class FakeControllers
    {
        public class NotAnnotated
        {
            public IActionResult None()
            {
                throw new NotImplementedException();
            }
        }

        [Authorize]
        public class AuthController
        {
            [AllowAnonymous]
            public IActionResult AllowAnonymous()
            {
                throw new NotImplementedException();
            }

            [Authorize("Customer")]
            public IActionResult Customer()
            {
                throw new NotImplementedException();
            }

            public IActionResult None()
            {
                throw new NotImplementedException();
            }
        }

        [Authorize]
        public class AuthControllerDerived : NotAnnotated
        {
        }

        [AllowAnonymous]
        public class AllowAnonymousController
        {
            [Authorize("Customer")] // this does nothing, because [AllowAnonymous] on the controller overrides it
            public IActionResult Customer()
            {
                throw new NotImplementedException();
            }
        }

        [SwaggerResponse(200, type: typeof(PersonResponse))]
        [SwaggerResponseExample(200, typeof(PersonResponseExample))]
        public class SwaggerResponseExampleController
        {
            public IActionResult None()
            {
                throw new NotImplementedException();
            }
        }

        [SwaggerResponse(200, type: typeof(PersonResponse))]
        public class SwaggerResponseController
        {
            public IActionResult None()
            {
                throw new NotImplementedException();
            }
        }
    }
}
