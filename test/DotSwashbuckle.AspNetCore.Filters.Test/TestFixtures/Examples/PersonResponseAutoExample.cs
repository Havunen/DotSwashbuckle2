﻿namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    internal class PersonResponseAutoExample : IExamplesProvider<PersonResponse>
    {
        public PersonResponse GetExamples()
        {
            return new PersonResponse { Id = 123, Title = Title.Dr, FirstName = "John Auto!", LastName = "Doe", Age = 27, Income = null };
        }
    }
}
