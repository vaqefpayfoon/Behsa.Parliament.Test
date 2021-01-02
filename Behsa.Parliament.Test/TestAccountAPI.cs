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
        public async void AddAccountWithNullAccountName()
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
        public async void AddAccountWithNullCorporateBranding()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.CorporateBranding));

            var item = accountAddVm.CorporateBranding;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountWithNullPrimaryContactFirstName()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactFirstName));

            var item = accountAddVm.PrimaryContactFirstName;

            Assert.Null(item);

            var jsonString = JsonConvert.SerializeObject(accountAddVm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountWithNullPrimaryContactLastName()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactLastName));

            var item = accountAddVm.PrimaryContactLastName;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountWithNullPrimaryContactMobilePhone()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactMobilePhone));

            var item = accountAddVm.PrimaryContactMobilePhone;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }

        [Fact]
        public async void AddAccountWithNullPrimaryContactNationalId()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.PrimaryContactNationalId));

            var item = accountAddVm.PrimaryContactNationalId;

            Assert.Null(item);

            await Assert.ThrowsAsync<ArgumentException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new ArgumentException();
            });
        }
        [Fact]
        public async void AddAccountWithNullStateId()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount(nameof(accountAddVm.StateId));

            var item = accountAddVm.StateId;

            Assert.Null(item);

            await Assert.ThrowsAsync<HttpRequestException>(async () => {
                var jsonString = JsonConvert.SerializeObject(accountAddVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                    throw new HttpRequestException();
            });
        }
        [Fact]
        public async void AddAccount()
        {
            var httpClient = new HttpClient();
            AccountAddVm accountAddVm = GetAccount("full");

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/byphone/{accountAddVm.PrimaryContactMobilePhone}");

            if (httpResponsePhone.StatusCode == HttpStatusCode.OK)
                throw new ArgumentException();


            var jsonString = JsonConvert.SerializeObject(accountAddVm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}", httpContent);

            var AccountId = await httpResponseMessage.Content.ReadAsStringAsync();
            AccountId = AccountId.Substring(1, AccountId.Length - 2);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);

            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Accounts}/{AccountId}");
            var strJson = await json.Content.ReadAsStringAsync();
            AccountVm AccountvmByID = JsonConvert.DeserializeObject<AccountVm>(strJson);

            Assert.IsType<AccountVm>(AccountvmByID);

            Assert.NotNull(AccountvmByID);

            Assert.Equal(AccountvmByID.AccountName, accountAddVm.AccountName);
        }
        private AccountAddVm GetAccount(string state)
        {
            AccountAddVm acc = new AccountAddVm();
            acc.AccountName = state == nameof(acc.AccountName) ? null : FakeData.RandomString(10);
            acc.CorporateBranding = state == nameof(acc.CorporateBranding) ? null : FakeData.RandomString(10);
            acc.LicensingReference = state == nameof(acc.LicensingReference) ? null : FakeData.RandomString(10);
            acc.StateId = state == nameof(acc.StateId) ? null : (Guid?)Guid.Parse("58d7db17-3b2f-eb11-a772-005056b4efa1");
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
    }

}
