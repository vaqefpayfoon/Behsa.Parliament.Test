using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestRequestsAPI
    {
        [Fact]
        public async void GetRequests_ExpectedPersianCharacterStateCode()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Requests}/byCustomer/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            RequestListVm requestListVm = JsonConvert.DeserializeObject<RequestListVm>(strJson);

            var stateCode = requestListVm.AllRequests.FirstOrDefault().StateCode;

            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
            bool res = regex.IsMatch(stateCode);
            Assert.Equal(res, true);

        }
        [Fact]
        public async void GetRequests_ExpectedPersianCharacterApplicationType()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Requests}/byCustomer/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            RequestListVm requestListVm = JsonConvert.DeserializeObject<RequestListVm>(strJson);

            var stateCode = requestListVm.AllRequests.FirstOrDefault().ApplicationType;

            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
            bool res = regex.IsMatch(stateCode);
            Assert.Equal(res, true);

        }
    }
}
