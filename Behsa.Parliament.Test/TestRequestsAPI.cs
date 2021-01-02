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
    public class TestRequestsAPI
    {
        [Fact]
        public async void GetRequests_Expected()
        {
            //ارتباط با نماینده / رییس مجلس    112
            //ثبت شکایات  10025
            //فرم نخبگانی 10022
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.RequestSubGroups}");
            var strJson = await json.Content.ReadAsStringAsync();
            RequestSubGroupListVm requestSubGroupList = JsonConvert.DeserializeObject<RequestSubGroupListVm>(strJson);


            Assert.NotNull(requestSubGroupList);

            Assert.True(requestSubGroupList.RequestSubGroups.Count > 5);
        }
    }
}
