using JsonFlatFileDataStore;
using ProCivReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCivReport.Pages
{
    public partial class NewUser
    {
        public string FullName;
        public string BadgeId;

        private async void AddOperator()
        {
            var store = new DataStore("wwwroot/db-json/nominativi.json");
            var collection = store.GetCollection<Operator>();

            var ops = new Operator { BadgeId = BadgeId, FullName = FullName };
            await collection.InsertOneAsync(ops);

            FullName = string.Empty;
            BadgeId = string.Empty;
        }
    }
}
