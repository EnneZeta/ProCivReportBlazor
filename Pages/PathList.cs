using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class PathList
    {
        private readonly Paths _paths = new() { StreetList = new List<Street>() };
        private int _nrPaths = 0;

        private async Task HasClicked(int streetId, string streetName, int nrPath)
        {
            await _jsRuntime.InvokeVoidAsync("disableCheckbox", streetId, "");
            await _jsRuntime.InvokeVoidAsync("saveInSession", streetId, nrPath);

            if (_persistency.Paths.StreetList.All(w => w.Id != streetId))
                _persistency.Paths.StreetList.Add(new Street { AlreadyChecked = true, Id = streetId, Name = streetName});
        }

        private async Task HandleValidSubmit()
        {
            _paths.StreetList = new List<Street>();
            Paths p = new() { StreetList = new List<Street>() };
            var sessionPaths = await _jsRuntime.InvokeAsync<string>("sessionStorageClean", _paths.NrPath);
            if (!string.IsNullOrEmpty(sessionPaths))
            {
                var x = sessionPaths.Replace("[", "").Replace("]", "").Split(",").ToArray();
                foreach (var s in x)
                    p.StreetList.Add(new Street { Id = Convert.ToInt32(s), Name = string.Empty });
            }

            if (_paths.NrPath == "Nr1")
            {
                var path001 = await _http.GetFromJsonAsync<List<Street>>("db-json/path001.json");
                _paths.StreetList.AddRange(path001);
                _nrPaths = 1;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr2")
            {
                var path002 = await _http.GetFromJsonAsync<List<Street>>("db-json/path002.json");
                _paths.StreetList.AddRange(path002);
                _nrPaths = 2;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr3")
            {
                var path003 = await _http.GetFromJsonAsync<List<Street>>("db-json/path003.json");
                _paths.StreetList.AddRange(path003);
                _nrPaths = 3;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr4")
            {
                var path004 = await _http.GetFromJsonAsync<List<Street>>("db-json/path004.json");
                _paths.StreetList.AddRange(path004);
                _nrPaths = 4;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr5")
            {
                var path005 = await _http.GetFromJsonAsync<List<Street>>("db-json/path005.json");
                _paths.StreetList.AddRange(path005);
                _nrPaths = 5;

                GetChecked(p);
            }
        }

        private void GetChecked(Paths p)
        {
            if (p.StreetList.Any())
            {
                _paths.StreetList.ForEach(f =>
                {
                    if (p.StreetList.Any(s => s.Id == f.Id))
                        f.AlreadyChecked = true;
                });
            }

            _persistency.Paths = new Paths { NrPath = _nrPaths.ToString(), StreetList = _paths.StreetList.Where(w => w.AlreadyChecked).ToList() };
        }
    }
}