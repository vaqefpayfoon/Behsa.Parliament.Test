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
    public class TestComplaintAPI
    {
        #region Contact
        [Fact]
        public async void AddComplaintContactNullContactAccountExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact("AccountContact");

            var AccountId = Complaint.AccountId;
            var ContactId = Complaint.ContactId;

            Assert.Null(AccountId);
            Assert.Null(ContactId);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullContactNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.ContactName));

            var item = Complaint.ContactName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullContactLastNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.ContactLastName));

            var item = Complaint.ContactLastName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullReferToExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.ReferTo));

            var item = Complaint.ReferTo;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullReasonsExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.Reasons));

            var item = Complaint.Reasons;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullTopicExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.Topic));

            var item = Complaint.Topic;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContactNullFathersNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.FathersName));

            var item = Complaint.FathersName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintContact_ExpectedGuidTicketNumber_ThenGetComplaintContact()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm complaintAddContact = GetComplaintAddContact("FullData");

            var jsonString = JsonConvert.SerializeObject(complaintAddContact);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintContact}", httpContent);

            var strJsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            ComplaintResult complaintResult = JsonConvert.DeserializeObject<ComplaintResult>(strJsonResult);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            HttpResponseMessage httpResponseMessageComplaint = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{complaintResult.complaintId}");

            HttpStatusCode httpStatusComplaint = httpResponseMessageComplaint.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusComplaint);

            var strJson = await httpResponseMessageComplaint.Content.ReadAsStringAsync();

            var complaintByID = JsonConvert.DeserializeObject<ComplaintResult>(strJson);

            Assert.IsType<ComplaintResult>(complaintByID);

            Assert.NotNull(complaintByID);

        }
        private ComplaintAddContactVm GetComplaintAddContact(string state)
        {
            ComplaintAddContactVm complaintAddContactVm = new ComplaintAddContactVm()
            {
                AccountId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.AccountId),
                ContactId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.ContactId),
                ContactAddress = FakeData.RandomString(10),
                ContactBusinessPhone = FakeData.RandomString(10),
                ContactName = state == "ContactName" ? null : FakeData.RandomString(10),
                ContactLastName = state == "ContactLastName" ? null : FakeData.RandomString(10),
                ContactNationalID = state == "ContactNationalID" ? null : FakeData.RandomString(10),
                FathersName = state == "FathersName" ? null : FakeData.RandomString(10),
                Reasons = state == "Reasons" ? null : FakeData.RandomString(10),
                Topic = state == "Topic" ? null : FakeData.RandomString(10),
            };
            if (state == "ReferTo")
                complaintAddContactVm.ReferTo = null;
            else
                complaintAddContactVm.ReferTo = 1;

            return complaintAddContactVm;
        }

        #endregion
        #region Account
        [Fact]
        public async void AddComplaintAccountNullContactAccountExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddAccountVm Complaint = GetComplaintAddAccount("AccountContact");

            var AccountId = Complaint.AccountId;
            var ContactId = Complaint.ContactId;

            Assert.Null(AccountId);
            Assert.Null(ContactId);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintAccountNullAccountNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddAccountVm Complaint = GetComplaintAddAccount(nameof(Complaint.AccountName));

            var item = Complaint.AccountName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintAccountNullReferToExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddAccountVm Complaint = GetComplaintAddAccount(nameof(Complaint.ReferTo));

            var item = Complaint.ReferTo;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintAccountNullReasonsExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddAccountVm Complaint = GetComplaintAddAccount(nameof(Complaint.Reasons));

            var item = Complaint.Reasons;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintAccountNullTopicExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddContactVm Complaint = GetComplaintAddContact(nameof(Complaint.Topic));

            var item = Complaint.Topic;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintAccount_ExpectedGuidTicketNumber_ThenGetComplaintContact()
        {
            var httpClient = new HttpClient();
            ComplaintAddAccountVm complaintAddAccount = GetComplaintAddAccount("FullData");

            var jsonString = JsonConvert.SerializeObject(complaintAddAccount);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintAccount}", httpContent);

            var strJsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            ComplaintResult complaintResult = JsonConvert.DeserializeObject<ComplaintResult>(strJsonResult);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            HttpResponseMessage httpResponseMessageComplaint = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{complaintResult.complaintId}");

            HttpStatusCode httpStatusComplaint = httpResponseMessageComplaint.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusComplaint);

            var strJson = await httpResponseMessageComplaint.Content.ReadAsStringAsync();

            var complaintByID = JsonConvert.DeserializeObject<ComplaintResult>(strJson);

            Assert.IsType<ComplaintResult>(complaintByID);

            Assert.NotNull(complaintByID);

        }
        private ComplaintAddAccountVm GetComplaintAddAccount(string state)
        {
            ComplaintAddAccountVm complaintAddAccountVm = new ComplaintAddAccountVm()
            {
                AccountId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.AccountId),
                ContactId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.ContactId),
                AccountName = state == "AccountName" ? null : FakeData.RandomString(10),
                Reasons = state == "Reasons" ? null : FakeData.RandomString(10),
                Topic = state == "Topic" ? null : FakeData.RandomString(10),
                AccountActivityType = FakeData.RandomString(10),
                AccountAddress = FakeData.RandomString(10),
                AccountBusinessphone = FakeData.RandomString(10),
                AccountNationalId = FakeData.RandomString(10),
                CorporateBranding = FakeData.RandomString(10),
                RegistrationNumber = FakeData.RandomString(10),
            };
            if (state == "ReferTo")
                complaintAddAccountVm.ReferTo = null;
            else
                complaintAddAccountVm.ReferTo = 1;

            return complaintAddAccountVm;
        }
        #endregion
        #region Organization
        [Fact]
        public async void AddComplaintOrganizationNullContactAccountExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm Complaint = GetComplaintAddOrganization("AccountContact");

            var AccountId = Complaint.AccountId;
            var ContactId = Complaint.ContactId;

            Assert.Null(AccountId);
            Assert.Null(ContactId);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintOrganizationNullOrganizationNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm Complaint = GetComplaintAddOrganization(nameof(Complaint.OrganName));

            var item = Complaint.OrganName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintOrganizationNullReferToExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm Complaint = GetComplaintAddOrganization(nameof(Complaint.ReferTo));

            var item = Complaint.ReferTo;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintOrganizationNullReasonsExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm Complaint = GetComplaintAddOrganization(nameof(Complaint.Reasons));

            var item = Complaint.Reasons;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintOrganizationNullTopicExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm Complaint = GetComplaintAddOrganization(nameof(Complaint.Topic));

            var item = Complaint.Topic;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                var jsonString = JsonConvert.SerializeObject(Complaint);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddComplaintOrganization_ExpectedGuidTicketNumber_ThenGetComplaintContact()
        {
            var httpClient = new HttpClient();
            ComplaintAddOrganizationVm complaintAddOrganization = GetComplaintAddOrganization("FullData");

            var jsonString = JsonConvert.SerializeObject(complaintAddOrganization);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.ComplaintOrganization}", httpContent);

            var strJsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            ComplaintResult complaintResult = JsonConvert.DeserializeObject<ComplaintResult>(strJsonResult);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            HttpResponseMessage httpResponseMessageComplaint = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{complaintResult.complaintId}");

            HttpStatusCode httpStatusComplaint = httpResponseMessageComplaint.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusComplaint);

            var strJson = await httpResponseMessageComplaint.Content.ReadAsStringAsync();

            var complaintByID = JsonConvert.DeserializeObject<ComplaintResult>(strJson);

            Assert.IsType<ComplaintResult>(complaintByID);

            Assert.NotNull(complaintByID);

        }
        private ComplaintAddOrganizationVm GetComplaintAddOrganization(string state)
        {
            ComplaintAddOrganizationVm complaintAddOrganizationVm = new ComplaintAddOrganizationVm()
            {
                AccountId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.AccountId),
                ContactId = state == "AccountContact" ? null : (Guid?)Guid.Parse(TestData4.ContactId),
                Reasons = state == "Reasons" ? null : FakeData.RandomString(10),
                Topic = state == "Topic" ? null : FakeData.RandomString(10),
                OrganName = state == "OrganName" ? null : FakeData.RandomString(10),
                OrganActivityType = FakeData.RandomString(10),
                OrganAddress = FakeData.RandomString(10),
                OrganBusinessPhone = FakeData.RandomString(10),
            };
            if (state == "ReferTo")
                complaintAddOrganizationVm.ReferTo = null;
            else
                complaintAddOrganizationVm.ReferTo = 1;

            return complaintAddOrganizationVm;
        }
        #endregion

        [Fact]
        public async void GetComplaintById_ExpectedFound()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{TestData4.ComplaintId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ComplaintVm complaintVm = JsonConvert.DeserializeObject<ComplaintVm>(strJson);

            Assert.IsType<ComplaintVm>(complaintVm);

            Assert.NotNull(complaintVm);

            Assert.IsType<Int32>(complaintVm.AccuseType);
        }
        [Fact]
        public async void GetComplaintById_ExpectedNotFound()
        {

            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{TestData4.ContactId}");
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void CheckComplaintTicketNumber_ExpectedFound()
        {
            string ticketNumber;
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.ContactIdComplaint}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            var httpClient2 = new HttpClient();
            var json2 = await httpClient2.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Complaint}/{TestData4.Complaint4TicketNumber}");
            var strJson2 = await json2.Content.ReadAsStringAsync();
            ComplaintVm complaintContactVm = JsonConvert.DeserializeObject<ComplaintVm>(strJson2);

            Assert.IsType<ComplaintVm>(complaintContactVm);

            Assert.NotNull(complaintContactVm);
            bool result = complaintContactVm.ComplaintContact.TicketNumber.StartsWith(contacvm.NationalId);
            Assert.True(result);

            //ticketNumber = contacvm.NationalId;

            //ticketNumber += "-30-";
            //ticketNumber += contacvm.bhs_LTN_Complaint;

            //Assert.Equal(complaintContactVm.ComplaintContact.TicketNumber, ticketNumber);
        }
        [Fact]
        public async void GetComplaintById_CheckWithAccountAccuseType_ExpectedFound()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{TestData4.ComplaintId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ComplaintVm complaintVm = JsonConvert.DeserializeObject<ComplaintVm>(strJson);

            Assert.IsType<ComplaintVm>(complaintVm);
            Assert.NotNull(complaintVm);

            if (complaintVm.AccuseType == 2)
                Assert.NotNull(complaintVm.ComplaintAccount);
        }
        [Fact]
        public async void GetComplaintById_CheckWithContactAccuseType_ExpectedFound()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{TestData4.ComplaintId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ComplaintVm complaintVm = JsonConvert.DeserializeObject<ComplaintVm>(strJson);

            Assert.IsType<ComplaintVm>(complaintVm);
            Assert.NotNull(complaintVm);


            if (complaintVm.AccuseType == 1)
                Assert.NotNull(complaintVm.ComplaintContact);
        }
        [Fact]
        public async void GetComplaintById_CheckWithOrganizationAccuseType_ExpectedFound()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Complaint}/{TestData4.ComplaintId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ComplaintVm complaintVm = JsonConvert.DeserializeObject<ComplaintVm>(strJson);

            Assert.IsType<ComplaintVm>(complaintVm);
            Assert.NotNull(complaintVm);


            if (complaintVm.AccuseType == 3)
                Assert.NotNull(complaintVm.ComplaintOrganization);
        }
    }
}
