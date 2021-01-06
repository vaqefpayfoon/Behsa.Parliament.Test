using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    
    public class TestEliteApplicationAPI
    {
        [Fact]
        public async void AddEliteNullContactExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm Elite = GetEliteApplicationVm(nameof(Elite.ContactId));

            var item = Elite.ContactId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(Elite);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddEliteNullExpertiseAreaExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm Elite = GetEliteApplicationVm(nameof(Elite.ExpertiseAreaId));

            var item = Elite.ExpertiseAreaId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(Elite);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddEliteNullExperimentalRecordsExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm Elite = GetEliteApplicationVm(nameof(Elite.ExperimentalRecords));

            var item = Elite.ExperimentalRecords;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(Elite);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddEliteNullScientificResearchRecordsExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm Elite = GetEliteApplicationVm(nameof(Elite.ScientificResearchRecords));

            var item = Elite.ScientificResearchRecords;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(Elite);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetEliteApplicationById_ExpectedStatusCode200()
        {           

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}/{TestData4.EliteApplicationId}");
            var strJson = await json.Content.ReadAsStringAsync();
            EliteApplicationVm eliteApplicationVm = JsonConvert.DeserializeObject<EliteApplicationVm>(strJson);

            Assert.IsType<EliteApplicationVm>(eliteApplicationVm);

            Assert.NotNull(eliteApplicationVm);
            if (json.StatusCode == HttpStatusCode.NotFound)
                throw new HttpRequestException();

        }
        [Fact]
        public async void GetContactById_ExpectedNotFound()
        {

            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}/{TestData4.AccountId}");
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddEliteApplication_ExpectedGuidTicketNumber_ThenGetEliteApplication()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm eliteApplication = GetEliteApplicationVm("FullData");

            var jsonString = JsonConvert.SerializeObject(eliteApplication);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);

            //var eliteApplicationId = await httpResponseMessage.Content.ReadAsStringAsync();
            //eliteApplicationId = eliteApplicationId.Substring(1, eliteApplicationId.Length - 2);
            var strJsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            EliteApplicationResult eliteResult = JsonConvert.DeserializeObject<EliteApplicationResult>(strJsonResult);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            HttpResponseMessage httpResponseMessageElite = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}/{eliteResult.EliteapplicationId}");

            HttpStatusCode httpStatusElite = httpResponseMessageElite.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusElite);

            var strJson = await httpResponseMessageElite.Content.ReadAsStringAsync();

            EliteApplicationVm eliteByID = JsonConvert.DeserializeObject<EliteApplicationVm>(strJson);

            Assert.IsType<EliteApplicationVm>(eliteByID);

            Assert.NotNull(eliteByID);

            Assert.Equal(eliteByID.ExpertiseAreaId, eliteApplication.ExpertiseAreaId);
        }
        [Fact]
        public async void PostEliteApplication_ExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            EliteApplicationAddVm eliteApplication = GetEliteApplicationVm("ContactId");
            eliteApplication.ContactId = Guid.Empty;
            var jsonString = JsonConvert.SerializeObject(eliteApplication);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.EliteApplication}", httpContent);

            var eliteApplicationId = await httpResponseMessage.Content.ReadAsStringAsync();
            eliteApplicationId = eliteApplicationId.Substring(1, eliteApplicationId.Length - 2);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);

        }
        private EliteApplicationAddVm GetEliteApplicationVm(string state)
        {
            EliteApplicationAddVm eliteApplicationAddVm = new EliteApplicationAddVm()
            {
                Description = FakeData.RandomString(10),
                ExperimentalRecords = state == "ExperimentalRecords" ? null : FakeData.RandomString(10),
                ScientificResearchRecords = state == "ScientificResearchRecords" ? null : FakeData.RandomNumberString(11),
                ContactId = state == "ContactId" ? null : (Guid?)Guid.Parse(TestData4.ContactId),
                ExpertiseAreaId = state == "ExpertiseAreaId" ? null : (Guid?)Guid.Parse(TestData4.ExpertiseAreaId),
                
            };
            return eliteApplicationAddVm;
        }
        [Fact]
        public async void CheckEliteApplicationTicketNumber_ExpectedFound()
        {
            string ticketNumber;
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.ContactIdEliteApplication}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            var httpClient2 = new HttpClient();
            var json2 = await httpClient2.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.EliteApplication}/{TestData4.EliteApplication4TicketNumber}");
            var strJson2 = await json2.Content.ReadAsStringAsync();
            EliteApplicationVm eliteApplicationVm = JsonConvert.DeserializeObject<EliteApplicationVm>(strJson2);

            Assert.IsType<EliteApplicationVm>(eliteApplicationVm);

            Assert.NotNull(eliteApplicationVm);
            bool result = eliteApplicationVm.TicketNumber.StartsWith(contacvm.NationalId);
            Assert.True(result);

            //ticketNumber = contacvm.NationalId;

            //ticketNumber += "-30-";
            //ticketNumber += contacvm.bhs_LTN_Complaint;

            //Assert.Equal(complaintContactVm.ComplaintContact.TicketNumber, ticketNumber);
        }
    }
}
