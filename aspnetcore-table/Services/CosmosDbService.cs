using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_table.Models;
using Microsoft.Azure.Cosmos.Table;

namespace aspnetcore_table.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private CloudStorageAccount _account;

        public CosmosDbService(string connectionString)
        {
            _account = CloudStorageAccount.Parse(connectionString);
        }

        public async Task AddItemAsync(MyItem item)
        {
            CloudTableClient tableClient = _account.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference("MyItem");

            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(item);
            await table.ExecuteAsync(insertOrMergeOperation).ConfigureAwait(false);
        }

        //public async Task DeleteItemAsync(string id)
        //{
        //    await this._container.DeleteItemAsync<MyItem>(id, new PartitionKey(id));
        //}

        //public async Task<MyItem> GetItemAsync(string id)
        //{
        //    try
        //    {
        //        ItemResponse<MyItem> response = await this._container.ReadItemAsync<MyItem>(id, new PartitionKey(id));
        //        return response.Resource;
        //    }
        //    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        return null;
        //    }

        //}

        public async Task<IEnumerable<MyItem>> GetItemsAsync()
        {
            CloudTableClient tableClient = _account.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference("MyItem");
            //IEnumerable<dynamic> ie = table.ExecuteQuery(new TableQuery<dynamic>());
            //foreach (var a in ie)
            //{
            //    Console.WriteLine(a);
            //}


            List<MyItem> items = table.ExecuteQuery(new TableQuery<MyItem>()).ToList();
            return items;
        }

        //public async Task UpdateItemAsync(string id, MyItem item)
        //{
        //    await this._container.UpsertItemAsync<MyItem>(item, new PartitionKey(id));
        //}
    }
}
