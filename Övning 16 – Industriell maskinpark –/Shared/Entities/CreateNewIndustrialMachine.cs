using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_16___Industriell_maskinpark__.Shared.Entities
{
    public class CreateNewIndustrialMachine
{
    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string Text { get; set; } = string.Empty;
}
}
