using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * TODO: rewrite these three tests into a single parameterized test
         * If you're stuck, have a look at the exercises for Day 1, as we
         * did the exact same thing there (just for a unit test instead of an API test).
         * Do this either using the [TestCase] attribute, or using [TestDataSource] combined
         * with the appropriate method to create and yield the TestCaseData objects.
         */
        [TestCase("/users/1", "Leanne Graham", TestName = "GetDataForUser1_CheckName_ShouldEqualLeanneGraham")]
        [TestCase("/users/2", "Ervin Howell", TestName = "GetDataForUser2_CheckName_ShouldEqualErvinHowell")]
        [TestCase("/users/3", "Clementine Bauch", TestName = "GetDataForUser3_CheckName_ShouldEqualClementineBauch")]
        public async Task GetDataForUser_CheckName(string user, string name)
        {
            RestRequest request = new RestRequest(user, Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo(name));
        }

    }
}
