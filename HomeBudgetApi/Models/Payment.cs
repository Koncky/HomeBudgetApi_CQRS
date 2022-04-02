using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string TransferTitle { get; set; }
        public bool Realized { get; set; }

        public int FeeId { get; set; }
        public Fee Fee { get; set; }
    }
}
