using System;
using System.Collections.Generic;
/// <summary>
/// Author: Robin Le Couteur
/// Date: 23/06/2019
/// 
/// This code file contains the data definition classes
/// </summary>
namespace PCShopSelfHost
{
    public class clsCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<clsAllItem> ItemsList { get; set; }
    }

    public class clsAllItem
    {  
        public int ID { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string OperatingSystem { get; set; }
        public decimal Price { get; set; }
        public int QtyInStock { get; set; }
        public DateTime LastModified { get; set; }
        public char NewOrUsed { get; set; }
        public string Condition { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public string ImportCountry { get; set; }
        public int CategoryID { get; set; }
    }

    public class clsOrder
    {
        public int OrderNo { get; set; }
        public int Qnty { get; set; }
        public decimal PricePerItem { get; set; }
        public string CustName { get; set; }
        public string CustPh { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int ItemID { get; set; }
        public clsAllItem OrderItem { get; set; }

        public decimal TotalOrderPrice { get => (PricePerItem * Qnty); } // Calculates total order price when accessed
        public string OrderItemModel
        {
            get
            {
                if (OrderItem != null)
                {
                    return OrderItem.Model;
                }
                else
                {
                    return null;
                }
            }
        }
    }

}
