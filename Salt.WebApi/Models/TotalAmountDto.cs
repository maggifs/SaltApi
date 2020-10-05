using System;

namespace Salt.WebApi.Models
{
    public class TotalAmountDto
    {
        public string merchant { get; set; }
        public DateTime transdate { get; set; }
        public Decimal totalAmount { get; set; }
	    public string currency { get; set; }
        public TotalAmountDto() {}
        public TotalAmountDto(string merchant, DateTime transdate, Decimal totalAmount, string currency)
        {
            this.merchant = merchant;
            this.transdate = transdate;
            this.totalAmount = totalAmount;
            this.currency = currency;
        }
    }
}