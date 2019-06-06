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
        public List<string> GetCategoryNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Name FROM Category", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsCategory GetCategory(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM Category WHERE Name = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsCategory()
                {
                    Name = (string)lcResult.Rows[0]["Name"],
                    Description = (string)lcResult.Rows[0]["Description"],
                    ItemsList = getCategoryItems(Name)
                };
            else
                return null;
        }

        private List<clsAllItem> getCategoryItems(string prName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", prName);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Item WHERE CategoryName = @Name", par);
            List<clsAllItem> lcItems = new List<clsAllItem>();
            foreach (DataRow dr in lcResult.Rows) lcItems.Add(dataRow2AllItem(dr));
            return lcItems;
        }

        private clsAllItem dataRow2AllItem(DataRow prDataRow)
        {
            return new clsAllItem()
            {
                
                Model = Convert.ToString(prDataRow["Model"]),
                Description = Convert.ToString(prDataRow["Description"]),
                OperatingSystem = Convert.ToString(prDataRow["OperatingSystem"]),
                Price = Convert.ToDecimal(prDataRow["Price"]),
                QtyInStock = Convert.ToInt32(prDataRow["QtyInStock"]),
                LastModified = Convert.ToDateTime(prDataRow["DateModified"]),
                NewOrUsed = Convert.ToChar(prDataRow["NewOrUsed"]),
                Condition = Convert.ToString(prDataRow["Condition"]),
                ManufactureDate = Convert.ToDateTime(prDataRow["ManufactureDate"]),
                ImportCountry = Convert.ToString(prDataRow["ImportCountry"]),
                CategoryName = Convert.ToString(prDataRow["CategoryName"])
            };
        }

        //Old Artist Code
        //public string PutArtist(clsArtist prArtist)
        //{ // update
        //    try
        //    {
        //        int lcRecCount = clsDbConnection.Execute(
        //        "UPDATE Artist " +
        //        "SET Speciality = @Speciality, Phone = @Phone " +
        //        "WHERE Name = @Name",
        //        prepareArtistParameters(prArtist));
        //        if (lcRecCount == 1)
        //            return "One artist updated";
        //        else
        //            return "Unexpected artist update count: " + lcRecCount;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.GetBaseException().Message;
        //    }
        //}
        //public string PostArtist(clsArtist prArtist)
        //{ // insert
        //    try
        //    {
        //        int lcRecCount = clsDbConnection.Execute(
        //        "INSERT INTO Artist (Speciality, Phone, Name)" +
        //        "VALUES (@Speciality,@Phone,@Name)",
        //        prepareArtistParameters(prArtist));
        //        if (lcRecCount == 1)
        //            return "One artist added";
        //        else
        //            return "Unexpected artist insert count: " + lcRecCount;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.GetBaseException().Message;
        //    }
        //}
        //private Dictionary<string, object> prepareArtistParameters(clsArtist prArtist)
        //{
        //    Dictionary<string, object> par = new Dictionary<string, object>(3);
        //    par.Add("Name", prArtist.Name);
        //    par.Add("Speciality", prArtist.Speciality);
        //    par.Add("Phone", prArtist.Phone);
        //    return par;
        //}




        public string DeleteItem(clsAllItem prItem)
        { // delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM Item " +
                "WHERE Model = @Model AND CategoryName = @CategoryName",
                prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One item deleted";
                else return "Unexpected item delete count: " + lcRecCount;
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
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE Item " +
                "SET Model = @Model, Description = @Description, OperatingSystem = @OperatingSystem, Price = @Price, QtyInStock = @QtyInStock, LastModified = @LastModified, " +
                "NewOrUsed = @NewOrUsed,Condition = @Condition, ManufactureDate = @ManufactureDate, ImportCountry = @ImportCountry, CategoryName = @CategoryName" +
                "WHERE Model = @Model AND CategoryName = @CategoryName",
                prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One item updated";
                else return "Unexpected item update count: " + lcRecCount;
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
                    + "(Model, Description, OperatingSystem, Price,QtyInStock, LastModified, NewOrUsed, Condition, ManufactureDate, ImportCountry, CategoryName) "
                    + "VALUES (@Model, @Description, @OperatingSystem, @Price,QtyInStock, @LastModified, @NewOrUsed, @Condition, @ManufactureDate, @ImportCountry, @CategoryName)"
                    , prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One item inserted";
                else return "Unexpected item insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        /// <summary>
        /// Prepares the item parameters for database operations
        /// </summary>
        /// <param name="prItem"></param>
        /// <returns></returns>
        private Dictionary<string, object> prepareItemParameters(clsAllItem prItem)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
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
            par.Add("CategoryName", prItem.CategoryName);
            return par;
        }
    }
}
