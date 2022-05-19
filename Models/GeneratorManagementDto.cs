using System;
using System.Collections.Generic;

namespace ProCivReport.Models
{
    public class GeneratorManagementDto
    {
        public GeneratorManagementDto()
        {
            Date = DateTime.Now;
            Operator = new Operator();            
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Operator Operator { get; set; }

        public string Generator { get; set; }

        public string OperationType { get; set; }

        public int WorkHours { get; set; }

        public string Signature { get; set; }
    }
}