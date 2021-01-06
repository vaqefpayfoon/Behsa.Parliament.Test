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
    public class TestAccountAPI
    {
        [Fact]
        public async void AddAccountNullAccountNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.AccountName));

            var item = accountAddVm.AccountName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async()  => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountNullCorporateBrandingExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.CorporateBranding));

            var item = accountAddVm.CorporateBranding;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountNullPrimaryContactFirstNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactFirstName));

            var item = accountAddVm.PrimaryContactFirstName;

            Assert.Null(item);

            var jsonString = JsonConvert.SerializeObject(accountAddVm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountNullPrimaryContactLastNameExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactLastName));

            var item = accountAddVm.PrimaryContactLastName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountNullPrimaryContactMobilePhoneExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactMobilePhone));

            var item = accountAddVm.PrimaryContactMobilePhone;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountNullPrimaryContactNationalIdExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactNationalId));

            var item = accountAddVm.PrimaryContactNationalId;

            Assert.Null(item);

            await Assert.ThrowsAsync<ArgumentException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new ArgumentException();
            });
        }
        [Fact]
        public async void AddAccountNullStateIdExpectedBadRequest()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.StateId));

            var item = accountAddVm.StateId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddAccountWithoutDuplicateContactPhoneNumberExpextedGuid()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount("full");

            //accountAddVm.PrimaryContactMobilePhone = "09126455464";
            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{accountAddVm.PrimaryContactMobilePhone}");

            if (httpResponsePhone.StatusCode == HttpStatusCode.NotFound)
            {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}", httpContent);

                var AccountId = await httpResponseMessage.Content.ReadAsStringAsync();
                AccountId = AccountId.Substring(1, AccountId.Length - 2);
                HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

                Assert.Equal(HttpStatusCode.OK, httpStatusCode);

                var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/{AccountId}");
                var strJson = await json.Content.ReadAsStringAsync();
                AccountVm AccountvmByID = JsonConvert.DeserializeObject<AccountVm>(strJson);

                Assert.IsType<AccountVm>(AccountvmByID);

                Assert.NotNull(AccountvmByID);

                Assert.Equal(AccountvmByID.AccountName, accountAddVm.AccountName);
            }
            else
                throw new ArgumentException();



        }
        private AccountAddVm GetAccount(string state)
        {
            AccountAddVm acc = new AccountAddVm();
            acc.AccountName = state == nameof(acc.AccountName) ? null : FakeData.RandomString(10);
            acc.CorporateBranding = state == nameof(acc.CorporateBranding) ? null : FakeData.RandomString(10);
            acc.LicensingReference = state == nameof(acc.LicensingReference) ? null : FakeData.RandomString(10);
            acc.StateId = state == nameof(acc.StateId) ? null : (Guid?)Guid.Parse(TestData4.StateId);
            acc.RegistrationNumber = FakeData.RandomString(10);
            acc.NationalId = FakeData.RandomNumberString(10);
            acc.ActivityType = "1";
            acc.MainActivity = "fff";
            acc.PrimaryContactFirstName = state == nameof(acc.PrimaryContactFirstName) ? null : FakeData.RandomString(10);
            acc.PrimaryContactLastName = state == nameof(acc.PrimaryContactLastName) ? null : FakeData.RandomString(10);
            acc.PrimaryContactNationalId = state == nameof(acc.PrimaryContactNationalId) ? null : FakeData.RandomNumberString(10);
            acc.PrimaryContactMobilePhone = state == nameof(acc.PrimaryContactMobilePhone) ? null : FakeData.RandomNumberString(11);
            acc.Address = FakeData.RandomString(10);
            acc.Telephone = FakeData.RandomString(10);
            acc.CityName = FakeData.RandomString(10);
            return acc;
        }
        [Fact]
        public async void GetAccountById_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/{TestData4.AccountId}");
            var strJson = await json.Content.ReadAsStringAsync();
            AccountVm accountVm = JsonConvert.DeserializeObject<AccountVm>(strJson);

            Assert.IsType<AccountVm>(accountVm);

            Assert.NotNull(accountVm);

            Assert.IsType<Int64>(Int64.Parse(accountVm.NationalId));
        }
        [Fact]
        public async void GetAccountById_ExpectedStatusCode200()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/{TestData4.AccountId}");
            var strJson = await json.Content.ReadAsStringAsync();
            AccountVm accountVm = JsonConvert.DeserializeObject<AccountVm>(strJson);

            if (json.StatusCode == HttpStatusCode.OK)
                Assert.True(true);
            else
                Assert.True(false);
        }
        [Fact]
        public async void GetAccountByPhone_ExpectedStatusCode200()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/byphone/{TestData4.AccountPhone}");
            var strJson = await json.Content.ReadAsStringAsync();
            AccountVm accountVm = JsonConvert.DeserializeObject<AccountVm>(strJson);

            if (json.StatusCode == HttpStatusCode.OK)
                Assert.True(true);
            else
                Assert.True(false);
        }

        [Fact]
        public async void GetAccountById_ExpectedNotFound()
        {

            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/{TestData4.ContactId}");
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetAccountByPhone_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/{TestData4.AccountPhone}");

            var strJson = await httpResponsePhone.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            Assert.NotNull(contacvm.AccountId);

            Assert.IsType<Int64>(Int64.Parse(contacvm.NationalId));


            var httpClient2 = new HttpClient();
            var json2 = await httpClient2.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Accounts}/{contacvm.AccountId}");
            var strJson2 = await json2.Content.ReadAsStringAsync();
            AccountVm accountVm = JsonConvert.DeserializeObject<AccountVm>(strJson2);

            Assert.IsType<AccountVm>(accountVm);

            Assert.NotNull(accountVm);
        }
        [Fact]
        public async void GetAccountByPhone_ExpectedNotFound()
        {
            

            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/09306885252");

                if (httpResponsePhone.StatusCode == HttpStatusCode.NotFound)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void GetAccountByPhone_ValidatePhone_ExpectedFound()
        {
            var httpClient = new HttpClient();

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Contacts}/byphone/0930");

                if (httpResponsePhone.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
    }

}
