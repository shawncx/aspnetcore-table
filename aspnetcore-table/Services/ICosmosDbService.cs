using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore_table.Models;

namespace aspnetcore_table.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<MyItem>> GetItemsAsync();
        //Task<MyItem> GetItemAsync(string id);
        //Task AddItemAsync(MyItem item);
        //Task UpdateItemAsync(string id, MyItem item);
        //Task DeleteItemAsync(string id);
    }
}
