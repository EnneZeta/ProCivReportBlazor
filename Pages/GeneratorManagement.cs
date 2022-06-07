using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Components;
using ProCivReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCivReport.Pages
{
    public partial class GeneratorManagement
    {
        public DataStore dataStoreOperators;
        public IDocumentCollection<Operator> operatorsCollection;
        public List<Operator> operators;

        public DataStore dataStoreGenerators;
        public IDocumentCollection<GeneratorManagementDto> generatorsCollection;
        public List<GeneratorManagementDto> generators { get; set; }
        public List<GeneratorManagementDto> searched { get; set; }

        private string CurrentSearchValue { get; set; } = "";

        private string SelectedCriteria { get; set; } = "";


        protected override void OnInitialized()
        {

            GetOperators();
            GetGeneratorsHistory();
            base.OnInitialized();

            searched = new List<GeneratorManagementDto>();
        }

        private async Task HandleValidSubmit()
        {
            var store = new DataStore("wwwroot/db-json/generators.json");
            var collection = store.GetCollection<GeneratorManagementDto>();

            var ops = new GeneratorManagementDto
            {
                Date = _persistency.GeneratorManagement.Date,
                OperationType = _persistency.GeneratorManagement.OperationType,
                Generator = _persistency.GeneratorManagement.Generator,
                Operator = _persistency.GeneratorManagement.Operator,
                WorkHours = _persistency.GeneratorManagement.WorkHours
            };
            await collection.InsertOneAsync(ops);

            GetGeneratorsHistory();
            _persistency.GeneratorManagement = new GeneratorManagementDto();
        }

        private void ChangeOp(ChangeEventArgs args)
        {
            var fullName = args.Value.ToString();
            _persistency.GeneratorManagement.Operator.FullName = fullName;
            _persistency.GeneratorManagement.Operator.BadgeId = operators.First(w => w.FullName.Equals(fullName)).BadgeId;
        }

        private void Search()
        {
            dataStoreGenerators = new DataStore("wwwroot/db-json/generators.json");
            generatorsCollection = dataStoreGenerators.GetCollection<GeneratorManagementDto>();

            if(SelectedCriteria == "operator")
                searched = generatorsCollection.AsQueryable().Where(w => w.Operator.FullName.ToLower().Contains(CurrentSearchValue.ToLower())).OrderByDescending(o => o.Date).ToList();
            else
                searched = generatorsCollection.AsQueryable().Where(w => w.Generator.ToString().ToLower().Contains(CurrentSearchValue.ToLower())).OrderByDescending(o => o.Date).ToList();
        }

        private void ChangeWorkHours(ChangeEventArgs args)
        {
            var workHours = Convert.ToInt32(args.Value);
            _persistency.GeneratorManagement.WorkHours = workHours;           
        }

        private void GetOperators()
        {
            dataStoreOperators = new DataStore("wwwroot/db-json/nominativi.json");
            operatorsCollection = dataStoreOperators.GetCollection<Operator>();
            operators = operatorsCollection.AsQueryable().ToList();
        }

        private void GetGeneratorsHistory()
        {
            dataStoreGenerators = new DataStore("wwwroot/db-json/generators.json");
            generatorsCollection = dataStoreGenerators.GetCollection<GeneratorManagementDto>();
            generators = generatorsCollection.AsQueryable().OrderByDescending(o => o.Date).Take(10).ToList();
        }
    }
}