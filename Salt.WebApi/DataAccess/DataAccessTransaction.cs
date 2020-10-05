
using System;
using System.Collections.Generic;
using System.Linq;
using Salt.WebApi.Models;

namespace Salt.WebApi.DataAccess 
{
    public class DataAccessTransaction : IDataAccessTransaction
    {
        private readonly DataContext _context;

        public DataAccessTransaction(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<TransactionDto> GetAllMerchants()
        {
            return _context.transactions.ToList();
        }
        public IEnumerable<TransactionDto> GetMerchantTransactionsByDate(string merchantId, DateTime date)
        {
            return _context.transactions.Where(m => (m.merchant == merchantId && m.transdate.Date == date));
        }
        public TotalAmountDto GetMerchantPaymentByDate(string merchantId, DateTime date)
        {
            decimal total = 0;
            var transaction = _context.transactions.Where(m => (m.merchant == merchantId && m.transdate.Date == date && m.voided == false));
            if(transaction.Any())
            {
                foreach (var item in transaction)
                {
                    total += item.amount;
                }
            
                TotalAmountDto totalAmountByDate = new TotalAmountDto(merchantId, date, total, transaction.First().currency);

                return totalAmountByDate;
            }
            return null;  
        }
        public TransactionDto PatchMerchantVoidTransactionsById(string merchantId, Guid transactionId)
        {
            var voidTransaction = _context.transactions.Find(transactionId);
            if(voidTransaction != null)
            {
                voidTransaction.voided = true;
                _context.SaveChanges();
            }
            return voidTransaction;
        }
    }
}