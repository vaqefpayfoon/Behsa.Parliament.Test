using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Nancy.Json;
using Newtonsoft.Json;
using System;
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
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4Contact.Id}");
            var strJson = await json.Content.ReadAsStringAsync();
            ContactVM contacvm = JsonConvert.DeserializeObject<ContactVM>(strJson);

            Assert.IsType<ContactVM>(contacvm);

            Assert.NotNull(contacvm);

            Assert.IsType<Int64>(Int64.Parse(contacvm.NationalId));
            Assert.IsType<Int64>(Int64.Parse(contacvm.MobilePhone));

            Assert.Equal(contacvm.NationalId, TestData4Contact.NationalId);
        }
        [Fact]
        public async void PostContact_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4Contact.Id}");

            var httpClient = new HttpClient();
            ContactVM contacvm = new ContactVM()
            {
                    FirstName = "lili3",
                    LastName = "mosadeghi3",
                    Telephone = "02122442244",
                    MobilePhone = "09126433300",
                    NationalId = "0011387033",
                    FathersName = "ناصر",
                    Address = "ابادان خیابان شهید کوچه 1",
                    Birthday = DateTime.Parse("1990-01-12"),
                    StateId = Guid.Parse("58d7db17-3b2f-eb11-a772-005056b4efa1"),
                    CityName = "اهواز"
            };

            var jsonString = JsonConvert.SerializeObject(contacvm);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json"); 

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Contacts}", httpContent);

            HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;

            Assert.Equal(HttpStatusCode.OK, httpStatusCode); 
        }
        [Fact]
        public async void PostContact2_ExpectedFound()
        {
            //var json = new WebClient().DownloadString($"{EndPoints.BaseUrl}/{EndPoints.Contacts}/{TestData4Contact.Id}");

            ContactVM contacvm = new ContactVM()
            {
                FirstName = "lili3",
                LastName = "mosadeghi3",
                Telephone = "02122442244",
                MobilePhone = "09123562210",
                NationalId = "0011387033",
                FathersName = "ناصر",
                Address = "ابادان خیابان شهید کوچه 1",
                Birthday = DateTime.Parse("1990-01-12"),
                StateId = Guid.Parse("58d7db17-3b2f-eb11-a772-005056b4efa1"),
                CityName = "اهواز"
            };


            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{EndPoints.BaseUrl}/{EndPoints.Contacts}")
            {
                Content = new StringContent(new JavaScriptSerializer().Serialize(contacvm), Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);

            string apiResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
