using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCShopUWPCustomer
{
    public static class ServiceClient
    {

        internal async static Task<List<clsCategory>> GetCategoryListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsCategory>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/clspcshop/GetCategoryList/"));
        }

        internal async static Task<clsCategory> GetCategoryAsync(int prCategoryID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsCategory>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/clspcshop/GetCategory?ID=" + prCategoryID));
        }



        internal async static Task<clsAllItem> GetItemAsync(int prItemID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAllItem>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/clspcshop/GetItem?ID=" + prItemID));
        }



        internal async static Task<List<clsOrder>> GetOrderListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/clspcshop/GetOrderList/"));
        }

        internal async static Task<clsOrder> GetOrderAsync(int prOrderNo)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/clspcshop/GetOrder?OrderNo=" + prOrderNo));
        }

        internal async static Task<string> InsertOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/clspcshop/PostOrder", "POST");
        }







        internal async static Task<string> InsertItemAsync(clsAllItem prItem)
        {
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/clspcshop/PostItem", "POST");
        }
        internal async static Task<string> UpdateItemAsync(clsAllItem prItem)
        {
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/clspcshop/PutItem", "PUT");
        }



        
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }


        internal async static Task<string> DeleteItemAsync(clsAllItem prItem)
        {
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/clspcshop/DeleteItem", "DELETE");
        }
        internal async static Task<string> DeleteOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/clspcshop/DeleteOrder", "DELETE");
        }
    }
}
