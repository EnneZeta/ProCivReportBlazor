using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ProCivReport.Pages
{
    public partial class PathList
    {
        private readonly Paths _paths = new() { StreetList = new List<Street>() };

        private int _nrPaths = 0;

        private async Task HasClicked(int checkId)
        {
            await _jsRuntime.InvokeVoidAsync("disableCheckbox", checkId, "");
            await _jsRuntime.InvokeVoidAsync("saveInSession", checkId);
        }

        private async Task HandleValidSubmit()
        {
            _paths.StreetList = new List<Street>();

            await _jsRuntime.InvokeVoidAsync("sessionStorageClean");

            if (_paths.NrPath == "Nr1")
            {
                var path001 = await _http.GetFromJsonAsync<List<Street>>("db-json/path001.json");
                _paths.StreetList.AddRange(path001);

                _nrPaths = 1;
            }

            if (_paths.NrPath == "Nr2")
            {
                var path002 = await _http.GetFromJsonAsync<List<Street>>("db-json/path002.json");
                _paths.StreetList.AddRange(path002);

                _nrPaths = 2;

            }

            if (_paths.NrPath == "Nr3")
            {
                var path003 = await _http.GetFromJsonAsync<List<Street>>("db-json/path003.json");
                _paths.StreetList.AddRange(path003);

                _nrPaths = 3;

            }

            if (_paths.NrPath == "Nr4")
            {
                var path004 = await _http.GetFromJsonAsync<List<Street>>("db-json/path004.json");
                _paths.StreetList.AddRange(path004);

                _nrPaths = 4;

            }

            if (_paths.NrPath == "Nr5")
            {
                var path005 = await _http.GetFromJsonAsync<List<Street>>("db-json/path005.json");
                _paths.StreetList.AddRange(path005);

                _nrPaths = 5;

            }
        }
    }
}