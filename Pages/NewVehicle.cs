using JsonFlatFileDataStore;
using ProCivReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCivReport.Pages
{
    public partial class NewVehicle
    {
        public string Type;
        public string Plate;

        private async void AddVehicle()
        {
            var store = new DataStore("wwwroot/db-json/veicoli.json");
            var collection = store.GetCollection<Vehicle>();

            var veh = new Vehicle { Plate = Plate, Type = Type };
            await collection.InsertOneAsync(veh);
        }
    }
}
