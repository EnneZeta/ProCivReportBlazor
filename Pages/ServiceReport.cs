using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProCivReport.Models;

namespace ProCivReport.Pages
{
    public partial class ServiceReport
    {
        private Paths paths = new() { StreetList = new List<Street>() };

        private ServiceReportDto _serviceReport = new ServiceReportDto();

        private async Task HandleValidSubmit()
        {
            var x = await _http.GetFromJsonAsync<List<string>>("api/ServiceReport");
        }

        private int _maxOperatorNumber = 0;
        private int _maxVehicleNumber = 0;


        private void CalculateGroup(int groupNumber)
        {

            var difference = groupNumber == 1 ? _serviceReport.FirstGroup.ArrivalTime.Subtract(_serviceReport.FirstGroup.DepartureTime) : _serviceReport.SecondGroup.ArrivalTime.Subtract(_serviceReport.SecondGroup.DepartureTime);
            if (groupNumber == 1)
                _serviceReport.FirstGroup.TotalHours = (int)difference.TotalHours;
            else
                _serviceReport.SecondGroup.TotalHours = (int)difference.TotalHours;
        }

        private void AddOperator()
        {
            _maxOperatorNumber++;
        }

        private void AddVehicle()
        {
            _maxVehicleNumber++;
        }
    }
}