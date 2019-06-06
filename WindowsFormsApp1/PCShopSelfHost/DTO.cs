using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCShopSelfHost
{
    public class clsCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<clsAllItem> ItemsList { get; set; }
    }

    public class clsAllItem
    {  
        public string Model { get; set; }
        public string Description { get; set; }
        public string OperatingSystem { get; set; }
        public decimal? Price { get; set; }
        public int? QtyInStock { get; set; }
        public DateTime? LastModified { get; set; }
        public char? NewOrUsed { get; set; }
        public string Condition { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public string ImportCountry { get; set; }
        public string CategoryName { get; set; }
    }
}
