using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestRequestSubGroupsAPI
    {
        [Fact]
        public async void GetRequestSubGroups_ExpectedMoreThan5()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.RequestSubGroups}");
            var strJson = await json.Content.ReadAsStringAsync();
            RequestSubGroupListVm requestSubGroupList = JsonConvert.DeserializeObject<RequestSubGroupListVm>(strJson);


            Assert.NotNull(requestSubGroupList);

            Assert.True(requestSubGroupList.RequestSubGroups.Count > 5);
        }
    }
}
