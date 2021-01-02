using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    
    public class TestEliteApplicationAPI
    {
        [Fact]
        public async void GetEliteApplicationById_ExpectedFound()
        {           

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.EliteApplication}/{TestData4.EliteApplicationId}");
            var strJson = await json.Content.ReadAsStringAsync();
            EliteApplicationVm eliteApplicationVm = JsonConvert.DeserializeObject<EliteApplicationVm>(strJson);

            Assert.IsType<EliteApplicationVm>(eliteApplicationVm);

            Assert.NotNull(eliteApplicationVm);
            
        }
        [Fact]
        public async void PostEliteApplication_ExpectedGuid_ThenGetEliteApplication()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm eliteApplication = GetEliteApplicationVm();

            var jsonString = JsonConvert.SerializeObject(eliteApplication);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.EliteApplication}", httpContent);

            //var eliteApplicationId = await httpResponseMessage.Content.ReadAsStringAsync();
            //eliteApplicationId = eliteApplicationId.Substring(1, eliteApplicationId.Length - 2);
            var strJsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            EliteApplicationResult eliteResult = JsonConvert.DeserializeObject<EliteApplicationResult>(strJsonResult);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            HttpResponseMessage httpResponseMessageElite = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.EliteApplication}/{eliteResult.EliteapplicationId}");

            HttpStatusCode httpStatusElite = httpResponseMessageElite.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusElite);

            var strJson = await httpResponseMessageElite.Content.ReadAsStringAsync();

            EliteApplicationVm eliteByID = JsonConvert.DeserializeObject<EliteApplicationVm>(strJson);

            Assert.IsType<EliteApplicationVm>(eliteByID);

            Assert.NotNull(eliteByID);

            Assert.Equal(eliteByID.ExpertiseAreaId, eliteApplication.ExpertiseAreaId);
        }
        [Fact]
        public async void PostEliteApplication_ExpectedInternalServerError()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm eliteApplication = GetEliteApplicationVm();
            eliteApplication.ContactId = Guid.Empty;
            var jsonString = JsonConvert.SerializeObject(eliteApplication);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.EliteApplication}", httpContent);

            var eliteApplicationId = await httpResponseMessage.Content.ReadAsStringAsync();
            eliteApplicationId = eliteApplicationId.Substring(1, eliteApplicationId.Length - 2);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);

        }
        private EliteApplicationAddVm GetEliteApplicationVm()
        {
            EliteApplicationAddVm eliteApplicationAddVm = new EliteApplicationAddVm()
            {
                Description = FakeData.RandomString(10),
                ExperimentalRecords = FakeData.RandomString(10),
                ScientificResearchRecords = FakeData.RandomNumberString(11),
                ContactId = Guid.Parse("51D8602E-B32F-EB11-A772-005056B4EFA1"),
                ExpertiseAreaId = Guid.Parse("10E8ECDE-633C-EB11-A774-005056B4EFA1"),
                
            };
            return eliteApplicationAddVm;
        }
    }
}
