using System;
using System.Collections.Generic;
using Salt.WebApi.Models;

namespace Salt.WebApi.DataAccess
{
    public interface IDataAccessTransaction
    {
        IEnumerable<TransactionDto> GetAllMerchants();
        IEnumerable<TransactionDto> GetMerchantTransactionsByDate(string merchantId, DateTime date);
        TotalAmountDto GetMerchantPaymentByDate(string merchantId, DateTime date);
        TransactionDto PatchMerchantVoidTransactionsById(string merchantId, Guid transactionId);
    }
}