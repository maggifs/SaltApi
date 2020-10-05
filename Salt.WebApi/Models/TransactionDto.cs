using System;

namespace Salt.WebApi.Models
{
    public class TransactionDto
    {
        public Guid id { get; set; }
        public DateTime transdate { get; set; }
        public string merchant { get; set; }
        public Decimal amount { get; set; }
	    public string currency { get; set; }	    
        public string pan{ get; set; }
	    public bool voided  { get; set; }

    }
}