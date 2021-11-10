using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class GuastiIlluminazione
    {
        private readonly LightingBreakdownsDto _lightingBreakdowns = new();
        private int _maxNumber;

        protected override void OnInitialized()
        {
            _lightingBreakdowns.Breaks = _persistency.LightingBreakdowns.Breaks.Any() 
                ? _persistency.LightingBreakdowns.Breaks 
                : new List<Break> { new() };

            _maxNumber = _persistency.LightingBreakdowns.Breaks.Any()
                ? _persistency.LightingBreakdowns.Breaks.Count
                : 1;

            base.OnInitialized();
        }

        private async Task HandleValidSubmit()
        {
            //await _jsRuntime.InvokeAsync<string>("lightingBreakdownsStorage", _maxNumber);

            _persistency.LightingBreakdowns.ReportNumber = _persistency.ServiceReport.ReportNumber;
            _persistency.LightingBreakdowns.Date = _persistency.ServiceReport.Date;
            _persistency.LightingBreakdowns.Breaks = _lightingBreakdowns.Breaks;
        }


        private void AddRow()
        {
            _maxNumber++;
            _lightingBreakdowns.Breaks.Add(new Break());
            _persistency.LightingBreakdowns.Breaks = _lightingBreakdowns.Breaks;
        }
    }
}