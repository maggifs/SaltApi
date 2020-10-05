
using System;
using System.Collections.Generic;
using Salt.WebApi.DataAccess;
using Salt.WebApi.Models;

namespace Salt.WebApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDataAccessTransaction _dataAccess;
        public TransactionService(IDataAccessTransaction dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IEnumerable<TransactionDto> GetAllMerchants()
        {
            return _dataAccess.GetAllMerchants();
        }
        public IEnumerable<TransactionDto> GetMerchantTransactionsByDate(string merchantId, DateTime date) 
        {
            return _dataAccess.GetMerchantTransactionsByDate(merchantId, date);
        }
        public TotalAmountDto GetMerchantPaymentByDate(string merchantId, DateTime date)
        {
            return _dataAccess.GetMerchantPaymentByDate(merchantId, date);
        }
        public TransactionDto PatchMerchantVoidTransactionsById(string merchantId, Guid transactionId)
        {
            return _dataAccess.PatchMerchantVoidTransactionsById(merchantId, transactionId);
        }
    }
}