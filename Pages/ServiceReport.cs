using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProCivReport.Models;
using Microsoft.JSInterop;

namespace ProCivReport.Pages
{
    public partial class ServiceReport
    {
        private ServiceReportDto serviceReport = new ServiceReportDto
        {
            Operators = new List<Operator> { new Operator() },
            Vehicles = new List<Vehicle> { new Vehicle() }
        };
        private int _maxOperatorNumber = 1;
        private int _maxVehicleNumber = 1;

        private async Task HandleValidSubmit()
        {
            //await _jsRuntime.InvokeVoidAsync("serviceReportStorage", _maxOperatorNumber, _maxVehicleNumber);

            await _http.PostAsJsonAsync("api/ServiceReport", _persistency);
        }

        private void CalculateGroup(int groupNumber)
        {

            var difference = groupNumber == 1 ? _persistency.ServiceReport.FirstGroup.ArrivalTime.Subtract(_persistency.ServiceReport.FirstGroup.DepartureTime) : _persistency.ServiceReport.SecondGroup.ArrivalTime.Subtract(_persistency.ServiceReport.SecondGroup.DepartureTime);
            if (groupNumber == 1)
                _persistency.ServiceReport.FirstGroup.TotalHours = (int)difference.TotalHours;
            else
                _persistency.ServiceReport.SecondGroup.TotalHours = (int)difference.TotalHours;
        }

        private void AddOperator()
        {
            _maxOperatorNumber++;
            serviceReport.Operators.Add(new Operator());
            _persistency.ServiceReport.Operators = serviceReport.Operators;
        }

        private void AddVehicle()
        {
            _maxVehicleNumber++;
            serviceReport.Vehicles.Add(new Vehicle());
            _persistency.ServiceReport.Vehicles = serviceReport.Vehicles;
        }
    }
}