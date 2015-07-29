using System.Collections.Generic;
using NUnit.Framework;
using RestaurantFinder.Domain;
using TechTalk.SpecFlow;

namespace RestaurantFinder.Providers.Tests
{
    [Binding]
    public class RestaurantFinderRepositorySteps
    {
        private JustEatRepository justEatRepository;
        private IEnumerable<Restaurant> results;

        [Given(@"I have created an instance of the JustEatRepository")]
        public void GivenIHaveCreatedAnInstanceOfTheRestaurantRepository()
        {
            justEatRepository = new JustEatRepository();
        }

        [Then(@"I the base URL should be (.*)")]
        public void ThenITheBaseUrlShouldBe(string p0)
        {
            Assert.AreEqual(p0, justEatRepository.BaseUrl);
        }

        [Then(@"I the request URI should be (.*)")]
        public void ThenITheRequestUriShouldBe(string p0)
        {
            Assert.AreEqual(p0, justEatRepository.RequestUri);
        }

        [When(@"I call the get method with outcode (.*)")]
        public void WhenICallTheGetMethodWithThe(string p0)
        {
            results = justEatRepository.Get(p0).Result;
        }

        [Then(@"the result should be an IEnumerable of Restaurant")]
        public void ThenTheResultShouldBeAnIEnumerableOfRestaurant()
        {
            Assert.IsInstanceOf<IEnumerable<Restaurant>>(results);
        }

        [Then(@"the result should not be empty")]
        public void ThenTheResultShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(results);
        }

        [Then(@"the result should be an empty enumeration")]
        public void ThenTheResultShouldBeAnEmptyEnumeration()
        {
            Assert.IsEmpty(results);
        }

        [When(@"I call the get method with null arguments")]
        public void WhenICallTheGetMethodWithNullArguments()
        {
            results = justEatRepository.Get(null).Result;
        }
    }
}