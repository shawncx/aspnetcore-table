using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace aspnetcore_table.Models
{
    public class MyItem : TableEntity
    {

        public string ItemId { get; set; }

        public string Name { get; set; }

        public object Value { get; set; }

        public MyItem()
        {

        }

        public MyItem(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        //public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        //{
        //    base.ReadEntity(properties, operationContext);
        //}

        //public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        //{
        //    return base.WriteEntity(operationContext);
        //}
    }
}
