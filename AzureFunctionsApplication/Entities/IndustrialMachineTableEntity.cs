using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsApplication.Entities
{
    public class IndustrialMachineTableEntity : BaseTableEntity
    {
        
        public string Text { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }

    public class BaseTableEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = TableNames.PartionKey;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
}
