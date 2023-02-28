using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Övning_16___Industriell_maskinpark__.Shared.Entities;
using AzureFunctionsApplication.Entities;

namespace AzureFunctionsApplication.Extensions
{
    public static class Mapper
    {
        public static IndustrialMachineTableEntity ToTableEntity(this IndustrialMachine item)
        {
            return new IndustrialMachineTableEntity
            {
                Completed = item.Completed,
                Text = item.Text,
                RowKey = item.Id
            };
        }

        public static IndustrialMachine ToItem(this IndustrialMachineTableEntity itemTable)
        {
            return new IndustrialMachine
            {
                Id = itemTable.RowKey,
                Text = itemTable.Text,
                Completed = itemTable.Completed
            };
        }
    }
}
