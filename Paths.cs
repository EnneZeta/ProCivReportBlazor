   using System.ComponentModel.DataAnnotations;
   using System.Collections.Generic;
   
   public class Paths
   {
		public string NrPath {get; set;} 
		
		public List<Street> StreetList {get; set;}
   }

   public class Street
   {
       public int Id { get; set; }

       public string Name { get; set; }
   }
   