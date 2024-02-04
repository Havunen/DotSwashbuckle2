using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    internal class PersonResponseMultipleExamples : IMultipleExamplesProvider<PersonResponse>
    {
        public IEnumerable<SwaggerExample<PersonResponse>> GetExamples()
        {
            yield return SwaggerExample.Create("Dave",
                "Posts Dave",
                new PersonResponse { FirstName = "Dave", Title = Title.Mr });
            yield return SwaggerExample.Create("Angela",
                "Posts Angela",
                new PersonResponse { FirstName = "Angela", Title = Title.Dr });
        }
    }
}