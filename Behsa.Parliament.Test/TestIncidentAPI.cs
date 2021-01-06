using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace Behsa.Parliament.Test
{
    public class TestIncidentAPI
    {
        [Fact]
        public async void AddIncidentNullAccountContactExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("AccountContact");

            var accountId = incidentAddVm.AccountId;
            var contactId = incidentAddVm.ContactId;

            Assert.Null(accountId);
            Assert.Null(contactId);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentNullUserExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("User");

            var userId = incidentAddVm.UserId;

            Assert.Null(userId);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentNullRequestGroupExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("RequestGroup");

            var RequestGroupId = incidentAddVm.RequestGroupId;

            Assert.Null(RequestGroupId);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentNullRequestSubGroupExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("RequestSubGroup");

            var RequestSubGroupId = incidentAddVm.RequestSubGroupId;

            Assert.Null(RequestSubGroupId);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentNullRequestTypeExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("RequestType");

            var RequestType = incidentAddVm.RequestType;

            Assert.Null(RequestType);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentAgentRequestTypeAndNullUserExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("User");

            incidentAddVm.RequestType = 2;

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncidentNegativeRequestTypeExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("FullData");
            incidentAddVm.RequestType = -1;
            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(incidentAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });

        }
        [Fact]
        public async void AddIncident()
        {
            var httpClient = new HttpClient();
            IncidentAddVm incidentAddVm = GetIncident("FullData");
            var jsonString = JsonConvert.SerializeObject(incidentAddVm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}", httpContent);
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);

        }
        [Fact]
        public async void GetIncidentByContact_ExpectedFound()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/bycontact/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            IncidentAddVm incidentAddVm = JsonConvert.DeserializeObject<IncidentAddVm>(strJson);

            Assert.IsType<IncidentAddVm>(incidentAddVm);

            Assert.NotNull(incidentAddVm);          

            
        }
        [Fact]
        public async void GetIncidentByAccount_ExpectedFound()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/byaccount/{TestData4.AccountId}");
            var strJson = await json.Content.ReadAsStringAsync();
            IncidentAddVm incidentAddVm = JsonConvert.DeserializeObject<IncidentAddVm>(strJson);

            Assert.IsType<IncidentAddVm>(incidentAddVm);

            Assert.NotNull(incidentAddVm);


        }
        [Fact]
        public async void GetIncidentById_ExpectedFound()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/byaccount/{TestData4.AccountId}");
            var strJson = await json.Content.ReadAsStringAsync();
            IncidentAddVm incidentAddVm = JsonConvert.DeserializeObject<IncidentAddVm>(strJson);

            Assert.IsType<IncidentAddVm>(incidentAddVm);

            Assert.NotNull(incidentAddVm);


        }
        [Fact]
        public async void GetIncidentById_ExpectedStatusCode200()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/{TestData4.IncidentId}");
            var strJson = await json.Content.ReadAsStringAsync();
            if (json.StatusCode == HttpStatusCode.OK)
                Assert.True(true);
            else
                Assert.True(false);


        }
        [Fact]
        public async void GetIncidentById_ExpectedNotFound()
        {
            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Incidents}/{TestData4.AccountId}");
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void CheckIncidentTicketNumber_ExpectedFound()
        {
            string ticketNumber;
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.ContactIdIncident}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            var httpClient2 = new HttpClient();
            var json2 = await httpClient2.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/{TestData4.Incident4TicketNumber}");
            var strJson2 = await json2.Content.ReadAsStringAsync();
            IncidentVm incidentAddVm = JsonConvert.DeserializeObject<IncidentVm>(strJson2);

            Assert.IsType<IncidentVm>(incidentAddVm);

            Assert.NotNull(incidentAddVm);
            bool result = incidentAddVm.TicketNumber.StartsWith(contacvm.NationalId);
            Assert.True(result);

            //ticketNumber = contacvm.NationalId;

            //if (incidentAddVm.RequestType == 10)
            //{
            //    ticketNumber += "-10-";
            //    ticketNumber += contacvm.bhs_LTN_Incident_S;
            //}
            //else
            //{
            //    ticketNumber += "-20-";
            //    ticketNumber += contacvm.bhs_LTN_Incident_L;
            //}
            //Assert.Equal(incidentAddVm.TicketNumber, ticketNumber);
        }
        public IncidentAddVm GetIncident(string state)
        {
            IncidentAddVm incident = new IncidentAddVm();
            
            incident.AccountId = state == "AccountContact" ? null : (Guid?) Guid.Parse(TestData4.AccountId);
            incident.ContactId = state == "AccountContact" ? null : (Guid?) Guid.Parse(TestData4.ContactId);

            if (state == "ParliamentBoss")
                incident.RequestType = 1; // رییس مجلس
            else if (state == "Agent")
                incident.RequestType = 2;// نماینده مجلس
            else if (state == "RequestType")
                incident.RequestType = null;
            else
                incident.RequestType = 1;
            incident.UserId = state == "User" ? null : (Guid?) Guid.Parse(TestData4.UserId);
            incident.Description = FakeData.RandomString(10);
            incident.IncidentTitle = FakeData.RandomString(10);
            incident.RequestGroupId = state == "RequestGroup" ? null : (Guid?) Guid.Parse(TestData4.RequestGroupId);
            incident.RequestSubGroupId = state == "RequestSubGroup" ? null : (Guid?) Guid.Parse(TestData4.RequestSubGroupId);
            return incident;
        }
    }
}
