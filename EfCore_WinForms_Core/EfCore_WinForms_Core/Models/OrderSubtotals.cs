using System;
using System.Collections.Generic;

namespace EfCore_WinForms_Core.Models
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
