using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace Behsa.Parliament.Test
{
    public class TestContactsAPI
    {
        [Fact]
        public async void AddContactNullFirstNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.FirstName));

            var item = contactAddVm.AccountName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddContactNullLastNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.LastName));

            var item = contactAddVm.LastName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddContactNullNationalIdExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.NationalId));

            var item = contactAddVm.NationalId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddContactNullMobilePhoneExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.MobilePhone));

            var item = contactAddVm.MobilePhone;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddContactNullCityNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.CityName));

            var item = contactAddVm.CityName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddContactNullStateExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            ContactVm contactAddVm = GetContactVM(nameof(contactAddVm.StateId));

            var item = contactAddVm.StateId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(contactAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetContactById_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            Assert.NotNull(contacvm);


            Assert.IsType<Int64>(Int64.Parse(contacvm.NationalId));

            Assert.Equal(contacvm.NationalId, TestData4.NationalId);
        }
        [Fact]
        public async void GetContactById_ExpectedStatusCode200()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            if (json.StatusCode == HttpStatusCode.OK)
                Assert.True(true);
            else
                Assert.True(false);
        }
        [Fact]
        public async void GetContactById_ExpectedNotFound()
        {

            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4.AccountId}");
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetContactByPhone_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{TestData4.ContactPhone}");

            var strJson = await httpResponsePhone.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            Assert.NotNull(contacvm);

            Assert.IsType<Int64>(Int64.Parse(contacvm.NationalId));
        }
        [Fact]
        public async void GetContactByPhone_StatusCode200()
        {

            var httpClient = new HttpClient();

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{TestData4.ContactPhone}");

            var strJson = await httpResponsePhone.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            if (httpResponsePhone.StatusCode == HttpStatusCode.OK)
                Assert.True(true);
            else
                Assert.True(false);
        }
        [Fact]
        public async void PostContactIFMobileNotExisit_ExpectedGuid_ThenGetContact()
        {
            var httpClient = new HttpClient();
            ContactVm contacvm = GetContactVM("FullData");

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{contacvm.MobilePhone}");

            var foundContact = await httpResponsePhone.Content.ReadAsStringAsync();
            if(httpResponsePhone.StatusCode == HttpStatusCode.OK)
            {
                Assert.Throws<Exception>(() => true);
            }


            var jsonString = JsonConvert.SerializeObject(contacvm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}", httpContent);

            var ContactId = await httpResponseMessage.Content.ReadAsStringAsync();
            ContactId = ContactId.Substring(1, ContactId.Length - 2);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvmByID = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvmByID);

            Assert.NotNull(contacvmByID);

            Assert.Equal(contacvmByID.MobilePhone, contacvm.MobilePhone);
        }
        private ContactVm GetContactVM(string state)
        {
            ContactVm contacvm = new ContactVm()
            {
                FirstName = state == "FirstName" ? null : FakeData.RandomString(10),
                LastName = state == "LastName" ? null : FakeData.RandomString(10),
                Telephone = FakeData.RandomNumberString(11),
                MobilePhone = state == "MobilePhone" ? null : FakeData.RandomNumberString(11),
                NationalId = state == "NationalId" ? null : FakeData.RandomNumberString(10),
                FathersName = FakeData.RandomString(10),
                Address = FakeData.RandomString(15),
                //Birthday = DateTime.Parse("1990-01-12"),
                StateId = state == "StateId" ? null : (Guid?)Guid.Parse(TestData4.StateId),
                CityName = state == "CityName" ? null : FakeData.RandomString(10)
            };
            return contacvm;
        }
        [Fact]
        public async void GetContactByPhone_ExpectedNotFound()
        {
            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/09306885252");

                if (httpResponsePhone.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetContactByPhone_ValidatePhone_ExpectedFound()
        {
            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/0930");

                if (httpResponsePhone.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetAccountByPhone_CheckPrimaryContactId_ExpectedFound()
        {
            var httpClient = new HttpClient();

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{TestData4.AccountPhone}");

            var strJson = await httpResponsePhone.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            Assert.NotNull(contacvm.AccountId);
        }
    }
}
