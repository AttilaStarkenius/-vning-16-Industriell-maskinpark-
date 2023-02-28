using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_16___Industriell_maskinpark__.Shared.Entities
{
    public class IndustrialMachine
{
    public string Id { get; set; } = Guid.NewGuid().ToString("n");
    public string Text { get; set; } = string.Empty;
    public bool Completed { get; set; }

    public bool Online { get; set; }
    public string latestDataSentFromMachine { get; set; }

    }
}
