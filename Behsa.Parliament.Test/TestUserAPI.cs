using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestUserAPI
    {
        [Fact]
        public async void GetUsers_ByConstituencyId_ExpectedFound()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}{EndPoints.Users}/byconstituency/{TestData4.ConstituencyId}");
            var strJson = await json.Content.ReadAsStringAsync();
            UsersListVm usersListVm = JsonConvert.DeserializeObject<UsersListVm>(strJson);


            Assert.NotNull(usersListVm);
        }
    }
}
