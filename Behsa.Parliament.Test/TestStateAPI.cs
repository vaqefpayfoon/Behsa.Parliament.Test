using Behsa.Parliament.Test.Utilities;
using Behsa.Parliament.Test.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    //[TestCaseOrderer("FullNameOfOrderStrategyHere", "OrderStrategyAssemblyName")]
    //public class TestStateAPI
    //{
        
    //    public async void GetStates_ExpectedMoreThan5()
    //    {
    //        var httpClient = new HttpClient();
    //        var json = await httpClient.GetAsync($"{EndPoints.BaseUrl}/{EndPoints.States}");
    //        var strJson = await json.Content.ReadAsStringAsync();
    //        StateListVm states = JsonConvert.DeserializeObject<StateListVm>(strJson);
            

    //        Assert.NotNull(states);            

    //        Assert.True(states.StatesVm.Count > 5);
    //    }
    //}
}
