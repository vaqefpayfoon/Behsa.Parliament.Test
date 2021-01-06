using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestDocumentAPI
    {

        [Fact]
        public async void UploadFileTestEliteapplications_ExpectedResultCreated()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/eliteapplications/{TestData4.EliteApplicationId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.Created, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTestEliteapplications_ExpectedResultRequestEntityTooLarge()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/eliteapplications/{TestData4.EliteApplicationId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.RequestEntityTooLarge, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTestEliteapplications_ExpectedResultBadRequest()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/eliteapplications/{TestData4.EliteApplicationId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);
            }

        }
        [Fact]
        public async void GetEliteApplicationsDocument_ExpectedListOfDocument()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/{EndPoints.EliteApplication}/byentity/{TestData4.EliteApplicationId}");
            var strJson = await json.Content.ReadAsStringAsync();
            DocumentListVm documentList = JsonConvert.DeserializeObject<DocumentListVm>(strJson);

            Assert.NotNull(documentList);
        }
        [Fact]
        public async void DownloadFileByDocumentId()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/{TestData4.DocumentId}");
            var strJson = await json.Content.ReadAsStringAsync();
            Assert.NotNull(strJson);
        }

        [Fact]
        public async void UploadFileTestComplaints_ExpectedResultCreated()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/complaints/{TestData4.ComplaintId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.Created, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTestComplaints_ExpectedResultRequestEntityTooLarge()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/complaints/{TestData4.ComplaintId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.RequestEntityTooLarge, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTestComplaints_ExpectedResultBadRequest()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}/{EndPoints.Documents}/complaints/{TestData4.EliteApplicationId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);
            }
        }
        [Fact]
        public async void GetComplaintsDocument_ExpectedListOfDocument()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/{EndPoints.Complaint}/byentity/{TestData4.ComplaintId}");
            var strJson = await json.Content.ReadAsStringAsync();
            DocumentListVm documentList = JsonConvert.DeserializeObject<DocumentListVm>(strJson);

            Assert.NotNull(documentList);
        }


        [Fact]
        public async void UploadFileTestIncidents_ExpectedResultCreated()
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
                var response = await client.PostAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/byincident/{TestData4.IncidentId}", formData);
                HttpStatusCode httpStatusCode = response.StatusCode;

                Assert.Equal(HttpStatusCode.Created, httpStatusCode);
            }

        }
        [Fact]
        public async void UploadFileTestIncidents_ExpectedResultRequestEntityTooLarge()
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
        public async void UploadFileTestIncidents_ExpectedResultBadRequest()
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
        public async void GetIncidentsDocument_ExpectedListOfDocument()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Documents}/byincident/{TestData4.IncidentId}");
            var strJson = await json.Content.ReadAsStringAsync();
            DocumentListVm documentList = JsonConvert.DeserializeObject<DocumentListVm>(strJson);

            Assert.NotNull(documentList);
        }
    }
}
