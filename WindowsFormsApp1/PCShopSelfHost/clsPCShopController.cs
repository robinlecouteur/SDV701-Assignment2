using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PCShopSelfHost
{
    public class clsPCShopController : ApiController
    {
        // ####################################################################################
        // ################################     CATEGORY     ##################################
        // ####################################################################################

        public List<clsCategory> GetCategoryList()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Category", null);
            List<clsCategory> lcCategoryList = new List<clsCategory>();
            foreach (DataRow dr in lcResult.Rows)
                lcCategoryList.Add(dataRow2Category(dr));
            return lcCategoryList;
        }
        public clsCategory GetCategory(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM Category WHERE ID = @ID", par);
            if (lcResult.Rows.Count > 0)
                return new clsCategory()
                {
                    ID = (int)lcResult.Rows[0]["ID"],
                    Name = (string)lcResult.Rows[0]["Name"],
                    Description = (string)lcResult.Rows[0]["Description"],
                    ItemsList = getCategoryItems(ID)
                };
            else
                return null;
        }
       

        // ####################################################################################
        // ##################################     ITEM     ####################################
        // ####################################################################################
        public string DeleteItem(clsAllItem prItem)
        { // delete
            try
            {
                DataTable lcOrders = clsDbConnection.GetDataTable("SELECT * FROM [Order] Where ItemID = @ID", prepareItemParameters(prItem));
                if (lcOrders.Rows.Count == 0)
                {
                    int lcRecCount = clsDbConnection.Execute(
                       "DELETE FROM Item " +
                       "WHERE ID = @ID AND CategoryID = @CategoryID",
                       prepareItemParameters(prItem));
                    if (lcRecCount == 1)
                    {
                        clsMQTTClient.Instance.MqttPublish("DBChange");
                        return "One item deleted";  
                    }
                    else return "Unexpected item delete count: " + lcRecCount;
                }
                else
                    return "Cannot delete item while it has active orders. Remove all orders for this item before attempting to delete it";
               
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        public string PutItem(clsAllItem prItem)
        { // update 
            try
            {
                if (prItem.LastModified == (GetItem(prItem.ID)).LastModified)
                {
                    prItem.LastModified = DateTime.Now;

                    int lcRecCount = clsDbConnection.Execute(
                    "UPDATE Item " +
                    "SET Model = @Model, Description = @Description, OperatingSystem = @OperatingSystem, Price = @Price, QtyInStock = @QtyInStock, LastModified = @LastModified, " +
                    "NewOrUsed = @NewOrUsed,Condition = @Condition, ManufactureDate = @ManufactureDate, ImportCountry = @ImportCountry, CategoryID = @CategoryID " +
                    "WHERE ID = @ID AND CategoryID = @CategoryID",
                    prepareItemParameters(prItem));
                    if (lcRecCount == 1)
                    {
                        clsMQTTClient.Instance.MqttPublish("DBChange");
                        return "One item updated";
                    }
                    else return "Unexpected item update count: " + lcRecCount;
                }
                else
                {
                    throw new Exception("DateModifiedMismatch");
                }

            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        public string PostItem(clsAllItem prItem)
        { // insert 
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Item "
                    + "(Model, Description, OperatingSystem, Price, QtyInStock, LastModified, NewOrUsed, Condition, ManufactureDate, ImportCountry, CategoryID) "
                    + "VALUES (@Model, @Description, @OperatingSystem, @Price, @QtyInStock, @LastModified, @NewOrUsed, @Condition, @ManufactureDate, @ImportCountry, @CategoryID)"
                    , prepareItemParameters(prItem));
                if (lcRecCount == 1)
                {
                    clsMQTTClient.Instance.MqttPublish("DBChange");
                    return "One item inserted";
                }
                else return "Unexpected item insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        //CATEGORY ITEMS
        private List<clsAllItem> getCategoryItems(int ID) // Get all items related to the category ID passed in
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Item WHERE CategoryID = @ID", par);
            List<clsAllItem> lcItems = new List<clsAllItem>();
            foreach (DataRow dr in lcResult.Rows) lcItems.Add(dataRow2AllItem(dr));
            return lcItems;
        }

        //ITEM
        public clsAllItem GetItem(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Item WHERE ID = @ID", par);
            clsAllItem lcItems = new clsAllItem();
            if (lcResult.Rows.Count > 0)
            {
                DataRow dr = lcResult.Rows[0];
                return dataRow2AllItem(dr);
            }
            else
                return null;
        }


        // ####################################################################################
        // #################################     ORDER     ####################################
        // ####################################################################################
        public List<clsOrder> GetOrderList()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM [Order]", null);
            List<clsOrder> lcOrderList = new List<clsOrder>();
            foreach (DataRow dr in lcResult.Rows)
            {
                clsOrder lcOrder = dataRow2Order(dr);
                lcOrder.OrderItem = GetItem(lcOrder.ItemID);
                lcOrderList.Add(lcOrder);
            }
                
            return lcOrderList;
        }
        public clsOrder GetOrder(int OrderNo)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("OrderNo", OrderNo);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM [Order] WHERE OrderNo = @OrderNo", par);
            if (lcResult.Rows.Count > 0)
            {
                DataRow dr = lcResult.Rows[0];
                clsOrder lcOrder = dataRow2Order(dr);
                lcOrder.OrderItem = GetItem(lcOrder.ItemID);
                return lcOrder;
            }
            else
                return null;
        }


        public string DeleteOrder(clsOrder prOrder)
        { // delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM [Order] " +
                "WHERE OrderNo = @OrderNo",
                prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                {
                    clsMQTTClient.Instance.MqttPublish("DBChange");
                    return "One order deleted";
                }
                else return "Unexpected order delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        /// <summary>
        /// Inserts an order into the database
        /// </summary>
        /// <param name="prOrder"></param>
        /// <returns></returns>
        public string PostOrder(clsOrder prOrder)
        { 
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO [Order] "
                    + "(Qnty, PricePerItem, CustName, CustPh, TimeOrdered, ItemID) "
                    + "VALUES (@Qnty, @PricePerItem, @CustName, @CustPh, @TimeOrdered, @ItemID)"
                    , prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                {
                    clsMQTTClient.Instance.MqttPublish("DBChange");
                    return "One order inserted";
                }
                else return "Unexpected order insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }     










        // ####################################################################################
        // #########################    CONVERT DATAROW TO OBJECT    ##########################
        // ####################################################################################
        private clsAllItem dataRow2AllItem(DataRow prDataRow)
        {
            return new clsAllItem()
            {
                ID = Convert.ToInt32(prDataRow["ID"]),
                Model = Convert.ToString(prDataRow["Model"]),
                Description = Convert.ToString(prDataRow["Description"]),
                OperatingSystem = Convert.ToString(prDataRow["OperatingSystem"]),
                Price = Convert.ToDecimal(prDataRow["Price"]),
                QtyInStock = Convert.ToInt32(prDataRow["QtyInStock"]),
                LastModified = Convert.ToDateTime(prDataRow["LastModified"]),
                NewOrUsed = Convert.ToChar(prDataRow["NewOrUsed"]),
                Condition = Convert.ToString(prDataRow["Condition"]),
                ManufactureDate = Convert.ToDateTime(prDataRow["ManufactureDate"]),
                ImportCountry = Convert.ToString(prDataRow["ImportCountry"]),
                CategoryID = Convert.ToInt32(prDataRow["CategoryID"])
            };
        }
        private clsCategory dataRow2Category(DataRow prDataRow)
        {
            return new clsCategory()
            {
                ID = Convert.ToInt32(prDataRow["ID"]),
                Name = Convert.ToString(prDataRow["Name"]),
                Description = Convert.ToString(prDataRow["Description"]),
            };
        }
        private clsOrder dataRow2Order(DataRow prDataRow)
        {
            return new clsOrder()
            {
                OrderNo = Convert.ToInt32(prDataRow["OrderNo"]),
                Qnty = Convert.ToInt32(prDataRow["Qnty"]),
                PricePerItem = Convert.ToDecimal(prDataRow["PricePerItem"]),
                CustName = Convert.ToString(prDataRow["CustName"]),
                CustPh = Convert.ToString(prDataRow["CustPh"]),
                TimeOrdered = Convert.ToDateTime(prDataRow["TimeOrdered"]),
                ItemID = Convert.ToInt32(prDataRow["ItemID"])
            };
        }



        // ####################################################################################
        // #############################    PREPARE PARAMETERS    #############################
        // ####################################################################################
        /// <summary>
        /// Prepares the Order parameters for database operations
        /// </summary>
        /// <param name="prOrder"></param>
        /// <returns></returns>
        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(7);
            par.Add("OrderNo", prOrder.OrderNo);
            par.Add("Qnty", prOrder.Qnty);
            par.Add("PricePerItem", prOrder.PricePerItem);
            par.Add("CustName", prOrder.CustName);
            par.Add("CustPh", prOrder.CustPh);
            par.Add("TimeOrdered", prOrder.TimeOrdered);
            par.Add("ItemID", prOrder.ItemID);
            return par;
        }

        /// <summary>
        /// Prepares the item parameters for database operations
        /// </summary>
        /// <param name="prItem"></param>
        /// <returns></returns>
        private Dictionary<string, object> prepareItemParameters(clsAllItem prItem)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(12);
            par.Add("ID", prItem.ID);
            par.Add("Model", prItem.Model);
            par.Add("Description", prItem.Description);
            par.Add("OperatingSystem", prItem.OperatingSystem);
            par.Add("Price", prItem.Price);
            par.Add("QtyInStock", prItem.QtyInStock);
            par.Add("LastModified", prItem.LastModified);
            par.Add("NewOrUsed", prItem.NewOrUsed);
            par.Add("Condition", prItem.Condition);
            par.Add("ManufactureDate", prItem.ManufactureDate);
            par.Add("ImportCountry", prItem.ImportCountry);
            par.Add("CategoryID", prItem.CategoryID);
            return par;
        }

    }
}
