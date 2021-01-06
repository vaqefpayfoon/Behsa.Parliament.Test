using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestConstituencyAPI
    {
        [Fact]
        public async void GetConstituencies_ExpectedMoreThan190()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Constituencies}");
            var strJson = await json.Content.ReadAsStringAsync();
            ConstituencyListVm Constituencies = JsonConvert.DeserializeObject<ConstituencyListVm>(strJson);


            Assert.NotNull(Constituencies);

            Assert.True(Constituencies.Constituencies.Count > 190);
        }
        [Fact]
        public async void GetConstituencies_WithStateID()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Constituencies}/bystate/{TestData4.StateId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ConstituencyListVm Constituencies = JsonConvert.DeserializeObject<ConstituencyListVm>(strJson);


            Assert.NotNull(Constituencies);
        }

    }
}
