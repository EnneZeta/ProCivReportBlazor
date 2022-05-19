using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using JsonFlatFileDataStore;
using Microsoft.JSInterop;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class PathList
    {
        private readonly Paths _paths = new() { StreetList = new List<Street>() };
        private int _nrPaths = 0;

        public DataStore dataStorePaths;
        public IDocumentCollection<Street> pathCollection;

        private async Task HasClicked(int streetId, string streetName, int nrPath)
        {
            await _jsRuntime.InvokeVoidAsync("disableCheckbox", streetId, "");
            await _jsRuntime.InvokeVoidAsync("saveInSession", streetId, nrPath);

            if (_persistency.Paths.StreetList.All(w => w.Id != streetId))
                _persistency.Paths.StreetList.Add(new Street { AlreadyChecked = true, Id = streetId, Name = streetName });
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
                dataStorePaths = new DataStore("wwwroot/db-json/path001.json");
                pathCollection = dataStorePaths.GetCollection<Street>();

                var path001 = pathCollection.AsQueryable().ToList();//await _http.GetFromJsonAsync<List<Street>>("wwwroot/db-json/path001.json");
                _paths.StreetList.AddRange(path001);
                _nrPaths = 1;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr2")
            {
                dataStorePaths = new DataStore("wwwroot/db-json/path002.json");
                pathCollection = dataStorePaths.GetCollection<Street>();

                var path002 = pathCollection.AsQueryable().ToList();

                _paths.StreetList.AddRange(path002);
                _nrPaths = 2;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr3")
            {
                dataStorePaths = new DataStore("wwwroot/db-json/path003.json");
                pathCollection = dataStorePaths.GetCollection<Street>();

                var path003 = pathCollection.AsQueryable().ToList();

                _paths.StreetList.AddRange(path003);
                _nrPaths = 3;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr4")
            {
                dataStorePaths = new DataStore("wwwroot/db-json/path004.json");
                pathCollection = dataStorePaths.GetCollection<Street>();

                var path004 = pathCollection.AsQueryable().ToList();
                _paths.StreetList.AddRange(path004);
                _nrPaths = 4;

                GetChecked(p);
            }

            if (_paths.NrPath == "Nr5")
            {
                dataStorePaths = new DataStore("wwwroot/db-json/path005.json");
                pathCollection = dataStorePaths.GetCollection<Street>();

                var path005 = pathCollection.AsQueryable().ToList();
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