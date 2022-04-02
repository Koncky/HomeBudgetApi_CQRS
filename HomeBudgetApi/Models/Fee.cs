using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Models
{
    public class Fee
    {
        public int Id { get; set; }        
        public DateTime CreateDate { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string NoAccount { get; set; }
        [MaxLength(100)]
        public string RecipientName { get; set; }
        [MaxLength(100)]
        public string RecipientAddress { get; set; }
        public bool IsArchival { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
