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
        public async void GetContactById_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4.ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvm = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvm);

            Assert.NotNull(contacvm);

            Assert.IsType<Int64>(Int64.Parse(contacvm.NationalId));

            Assert.Equal(contacvm.NationalId, TestData4.NationalId);
        }
        [Fact]
        public async void PostContactIFMobileNotExisit_ExpectedGuid_ThenGetContact()
        {
            var httpClient = new HttpClient();
            ContactVm contacvm = GetContactVM();

            HttpResponseMessage httpResponsePhone = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/byphone/{contacvm.MobilePhone}");

            var foundContact = await httpResponsePhone.Content.ReadAsStringAsync();
            if(httpResponsePhone.StatusCode == HttpStatusCode.OK)
            {
                Assert.Throws<Exception>(() => true);
            }


            var jsonString = JsonConvert.SerializeObject(contacvm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}", httpContent);

            var ContactId = await httpResponseMessage.Content.ReadAsStringAsync();
            ContactId = ContactId.Substring(1, ContactId.Length - 2);
            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode);


            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{ContactId}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVm contacvmByID = JsonConvert.DeserializeObject<ContactVm>(strJson);

            Assert.IsType<ContactVm>(contacvmByID);

            Assert.NotNull(contacvmByID);

            Assert.Equal(contacvmByID.MobilePhone, contacvm.MobilePhone);
        }

        private ContactVm GetContactVM()
        {
            ContactVm contacvm = new ContactVm()
            {
                FirstName = FakeData.RandomString(10),
                LastName = FakeData.RandomString(10),
                Telephone = FakeData.RandomNumberString(11),
                MobilePhone = FakeData.RandomNumberString(11),
                NationalId = FakeData.RandomNumberString(10),
                FathersName = FakeData.RandomString(10),
                Address = FakeData.RandomString(15),
                //Birthday = DateTime.Parse("1990-01-12"),
                StateId = Guid.Parse("58d7db17-3b2f-eb11-a772-005056b4efa1"),
                CityName = FakeData.RandomString(10)
            };
            return contacvm;
        }

    }
}
