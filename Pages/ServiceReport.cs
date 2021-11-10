using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProCivReport.Models;
using Microsoft.JSInterop;

namespace ProCivReport.Pages
{
    public partial class ServiceReport
    {
        private readonly ServiceReportDto _serviceReport = new();
        private int _maxOperatorNumber;
        private int _maxVehicleNumber;

        protected override void OnInitialized()
        {
            _serviceReport.Operators = _persistency.ServiceReport.Operators.Any() 
                ? _persistency.ServiceReport.Operators 
                : new List<Operator> {new Operator()};

            _serviceReport.Vehicles = _persistency.ServiceReport.Vehicles.Any() 
                ? _persistency.ServiceReport.Vehicles 
                : new List<Vehicle> {new Vehicle()};

            _maxOperatorNumber = _persistency.ServiceReport.Operators.Any() ? _persistency.ServiceReport.Operators.Count : 1;
            _maxVehicleNumber = _persistency.ServiceReport.Vehicles.Any() ? _persistency.ServiceReport.Vehicles.Count :  1;

            base.OnInitialized();
        }

        private async Task HandleValidSubmit()
        {
            _persistency.ServiceReport.Operators = _serviceReport.Operators;
            _persistency.ServiceReport.Vehicles = _serviceReport.Vehicles;
            //await _http.PostAsJsonAsync("api/ServiceReport", _persistency);
        }

        private void CalculateGroup(ChangeEventArgs args, int field, int groupNumber)
        {
            if (groupNumber == 1)
            {
                if (field == 0)
                    _persistency.ServiceReport.FirstGroup.DepartureTime = Convert.ToDateTime(args.Value.ToString());

                if (field == 1)
                    _persistency.ServiceReport.FirstGroup.ArrivalTime = Convert.ToDateTime(args.Value.ToString());
            }


            if (groupNumber == 2)
            {
                if (field == 0)
                    _persistency.ServiceReport.SecondGroup.DepartureTime = Convert.ToDateTime(args.Value.ToString());

                if (field == 1)
                    _persistency.ServiceReport.SecondGroup.ArrivalTime = Convert.ToDateTime(args.Value.ToString());
            }
                

            var difference = groupNumber == 1 ? _persistency.ServiceReport.FirstGroup.ArrivalTime.Subtract(_persistency.ServiceReport.FirstGroup.DepartureTime) : _persistency.ServiceReport.SecondGroup.ArrivalTime.Subtract(_persistency.ServiceReport.SecondGroup.DepartureTime);
            if (groupNumber == 1)
            {
                _persistency.ServiceReport.FirstGroup.TotalHours = difference.Hours.ToString("00") + ":" + difference.Minutes.ToString("00");
            }
            else
                _persistency.ServiceReport.SecondGroup.TotalHours = difference.Hours.ToString("00") + ":" + difference.Minutes.ToString("00");
        }

        private void AddOperator()
        {
            _maxOperatorNumber++;
            _serviceReport.Operators.Add(new Operator());
            _persistency.ServiceReport.Operators = _serviceReport.Operators;
        }

        private void AddVehicle()
        {
            _maxVehicleNumber++;
            _serviceReport.Vehicles.Add(new Vehicle());
            _persistency.ServiceReport.Vehicles = _serviceReport.Vehicles;
        }
    }
}