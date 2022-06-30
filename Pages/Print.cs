using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class Print
    {
        public Dictionary<string,string> pdfList = new Dictionary<string, string>();

        protected override async Task OnInitializedAsync()
        {
            var apiResponse = await _http.PostAsJsonAsync("api/Print", _persistency);
            if (apiResponse.IsSuccessStatusCode)
            {
                var r = await apiResponse.Content.ReadAsStringAsync();
                pdfList =  JsonConvert.DeserializeObject<Dictionary<string,string>>(r);
            }
                

            await base.OnInitializedAsync();
        }
    }
}