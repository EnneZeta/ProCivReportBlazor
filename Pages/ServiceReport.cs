using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProCivReport.Models;
using Microsoft.JSInterop;
using JsonFlatFileDataStore;

namespace ProCivReport.Pages
{
    public partial class ServiceReport
    {
        private readonly ServiceReportDto _serviceReport = new();
        private int _maxOperatorNumber;
        private int _maxVehicleNumber;
        public DataStore dataStoreVehicles;
        public DataStore dataStoreOperators;
        public IDocumentCollection<Operator> operatorsCollection;
        public IDocumentCollection<Vehicle> vehiclesCollection;
        public List<Operator> operators;
        public List<Vehicle> vehicles;


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

            GetVehicles();
            GetOperators();

            base.OnInitialized();
        }

        private async Task HandleValidSubmit()
        {
            _persistency.ServiceReport.Operators = _serviceReport.Operators;
            _persistency.ServiceReport.Vehicles = _serviceReport.Vehicles;
            //await _http.PostAsJsonAsync("api/ServiceReport", _persistency);
        }

        private void ChangeOp(ChangeEventArgs args)
        {
            var fullName = args.Value.ToString();
            _persistency.ServiceReport.TeamLeader.FullName = fullName;
            _persistency.ServiceReport.TeamLeader.BadgeId = operators.First(w => w.FullName.Equals(fullName)).BadgeId;
        }

        private void ChangeOp(ChangeEventArgs args, int localVariable)
        {
            var fullName = args.Value.ToString();
            _serviceReport.Operators[localVariable-1].FullName = fullName;
            _serviceReport.Operators[localVariable-1].BadgeId = operators.First(w => w.FullName.Equals(fullName)).BadgeId;
        }

        private void ChangeVh(ChangeEventArgs args, int localVariable)
        {
            var type = args.Value.ToString();
            _serviceReport.Vehicles[localVariable - 1].Type = type;
            _serviceReport.Vehicles[localVariable - 1].Plate = vehicles.First(w => w.Type.Equals(type)).Plate;
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

        private void GetVehicles()
        {
            dataStoreVehicles = new DataStore("wwwroot/db-json/veicoli.json");
            vehiclesCollection = dataStoreVehicles.GetCollection<Vehicle>();
            vehicles = vehiclesCollection.AsQueryable().ToList();
        }

        private void GetOperators()
        {
            dataStoreOperators = new DataStore("wwwroot/db-json/nominativi.json");
            operatorsCollection = dataStoreOperators.GetCollection<Operator>();
            operators = operatorsCollection.AsQueryable().ToList();
        }
    }
}