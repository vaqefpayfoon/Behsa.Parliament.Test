using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestRequestGroupAPI
    {
        [Fact]
        public async void GetRequestGroup_ExpectedMoreThan32()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.RequestGroups}");
            var strJson = await json.Content.ReadAsStringAsync();
            RequestGroupListVm RequestGroups = JsonConvert.DeserializeObject<RequestGroupListVm>(strJson);


            Assert.NotNull(RequestGroups);

            Assert.True(RequestGroups.RequestGroups.Count > 5);
        }
    }
}
