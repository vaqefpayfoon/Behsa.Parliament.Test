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
    public class TestExpertiseAreaAPI
    {
        [Fact]
        public async void GetExpertiesAreas_ExpectedMoreThan5()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.ExpertiesAreas}");
            var strJson = await json.Content.ReadAsStringAsync();
            ExpertiesAreaLsitVm ExpertiesAreas = JsonConvert.DeserializeObject<ExpertiesAreaLsitVm>(strJson);


            Assert.NotNull(ExpertiesAreas);

            Assert.True(ExpertiesAreas.ExpertiesAreasVm.Count > 5);
        }
    }
}
