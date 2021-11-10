using System;
using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.VisualBasic.CompilerServices;

namespace ProCivReport.Models
{
    public class ServiceReportDto
    {
        public ServiceReportDto()
        {
            FirstGroup = new FirstGroup();
            SecondGroup = new SecondGroup();
            Operators = new List<Operator>();
            Vehicles = new List<Vehicle>();
            Other = new BoolWithNote();
            Emergency = new BoolWithNote();
            TeamLeader = new Operator();
            Date = DateTime.Now;
        }

        public string ReportNumber { get; set; }

        public DateTime Date { get; set; }

        public bool LandMonitoring { get; set; }

        public bool Drill { get; set; }

        public bool ToolOfficeManagement { get; set; }

        public bool CorSoup { get; set; }

        public bool TrainingCourse { get; set; }

        public BoolWithNote Emergency { get; set; }

        public BoolWithNote Other { get; set; }

        public Operator TeamLeader { get; set; }

        public List<Operator> Operators { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public FirstGroup FirstGroup { get; set; }

        public SecondGroup SecondGroup { get; set; }

        public string Note { get; set; }
    }

    public class SecondGroup
    {
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string TotalHours { get; set; }
    }

    public class FirstGroup
    {
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string TotalHours { get; set; }
    }

    public class Vehicle
    {
        public string Type { get; set; }

        public string Plate { get; set; }

        public int TotKm { get; set; }
    }

    public class Operator
    {
        public string FullName { get; set; }

        public string BadgeId { get; set; }
    }

    public class BoolWithNote
    {
        public bool IsChecked { get; set; }

        public string Note { get; set; }

    }
}


