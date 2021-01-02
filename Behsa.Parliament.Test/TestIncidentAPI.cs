using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.IO;
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
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.Incidents}/byaccount/{TestData4.IncidentId}");
            var strJson = await json.Content.ReadAsStringAsync();
            IncidentAddVm incidentAddVm = JsonConvert.DeserializeObject<IncidentAddVm>(strJson);

            Assert.IsType<IncidentAddVm>(incidentAddVm);

            Assert.NotNull(incidentAddVm);


        }
        [Fact]
        public async void UploadFileTest_ExpectedResultCreated()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string file = Path.Combine(projectDirectory, "Files\\Logical.pdf");
            FileStream fs;
            MemoryStream ms;
            byte[] data;
            using (fs = File.OpenRead(file))
            {
                int length = Convert.ToInt32(fs.Length);
                data = new byte[length];
                fs.Read(data, 0, length);
                fs.Close();
                ms = new MemoryStream(data);
            }
            HttpContent fileStreamContent = new StreamContent(ms);
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, "file", "Logical.pdf");
                var response = await client.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/incident/byentity/{TestData4.IncidentId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.Created, httpStatusCode);
            }

        }

        [Fact]
        public async void UploadFileTest_ExpectedResultRequestEntityTooLarge()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string file = Path.Combine(projectDirectory, "Files\\ASPANgular.pdf");
            FileStream fs;
            MemoryStream ms;
            byte[] data;
            using (fs = File.OpenRead(file))
            {
                int length = Convert.ToInt32(fs.Length);
                data = new byte[length];
                fs.Read(data, 0, length);
                fs.Close();
                ms = new MemoryStream(data);
            }
            HttpContent fileStreamContent = new StreamContent(ms);
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, "file", "ASPANgular.pdf");
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/byincident/{TestData4.IncidentId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.RequestEntityTooLarge, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTest_ExpectedResultBadRequest()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string file = Path.Combine(projectDirectory, "Files\\test.exe");
            FileStream fs;
            MemoryStream ms;
            byte[] data;
            using (fs = File.OpenRead(file))
            {
                int length = Convert.ToInt32(fs.Length);
                data = new byte[length];
                fs.Read(data, 0, length);
                fs.Close();
                ms = new MemoryStream(data);
            }
            HttpContent fileStreamContent = new StreamContent(ms);
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, "file", "test.exe");
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/byincident/{TestData4.IncidentId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);
            }

        }
        [Fact]
        public void AddIncidentExpectedGuidWithUpload()
        {

        }
        public IncidentAddVm GetIncident(string state)
        {
            IncidentAddVm incident = new IncidentAddVm();
            
            incident.AccountId = state == "Account" ? (Guid?) Guid.Parse("8D230B9B-9B37-EB11-B34A-0050569C6D6D") : null;
            incident.ContactId = state == "Contact" ? (Guid?)Guid.Parse("8D230B9B-9B37-EB11-B34A-0050569C6D6D") : null;
            incident.RequestType = 2;    //1:  رییس مجلس  

            incident.UserId = Guid.Parse("56950A2C-0C30-EB11-A772-005056B4EFA1");
            incident.Description = FakeData.RandomString(10);
            incident.IncidentTitle = FakeData.RandomString(10);
            incident.RequestGroupId = Guid.Parse("77c45ffa-152f-eb11-a772-005056b4efa1");
            incident.RequestSubGroupId =  Guid.Parse("46cb66a6-7e34-eb11-b34a-0050569c6d6d");
            return incident;
        }
    }
}
