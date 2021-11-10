using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class Print
    {
        protected override async Task OnInitializedAsync()
        {
            await _http.PostAsJsonAsync("api/Print", _persistency);
            await base.OnInitializedAsync();
        }
    }
}