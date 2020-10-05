using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Salt.WebApi.DataAccess;
using Salt.WebApi.Models;
using Salt.WebApi.Services;

namespace Salt.WebApi.Controllers
{
    [ApiController]
    [Route("api/merchants")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Retrieves a list of transactions by a specific date
        /// </summary>
        /// <remarks>Returns a list of transaction by specific date and specific merchant</remarks>
        /// <response code="200">List retrieved</response>
        /// <response code="404">No transactions found</response>
        [Route("{merchantId}/transactions")]
        [HttpGet]
        public IActionResult GetMerchantTransactionsByDate(string merchantId, [FromQuery, BindRequired] DateTime date)
        {
            var transactions = _transactionService.GetMerchantTransactionsByDate(merchantId, date);
            if(transactions.Any())
            {
                return Ok(transactions);
            }
            return NotFound();
        }

        /// <summary>
        /// Retrieves a payment for a specific date
        /// </summary>
        /// <remarks>Returns a payment object by specific date and specific merchant</remarks>
        /// <response code="200">Payment object retrieved</response>
        /// <response code="404">No transactions found</response>
        [Route("{merchantId}/payments")]
        [HttpGet]
        public IActionResult GetMerchantPaymentByDate(string merchantId, [FromQuery, BindRequired] DateTime date)
        {
            var payment = _transactionService.GetMerchantPaymentByDate(merchantId, date);
            if(payment != null)
            {
                return Ok(payment);
            }
            return NotFound();
        }

        /// <summary>
        /// Voides a transaction by id
        /// </summary>
        /// <remarks>Returns the transsaction that merchant voided</remarks>
        /// <response code="200">Transaction successfully voided</response>
        /// <response code="404">No transactions found</response>
        [Route("{merchantId}/transactions/{transactionId}")]
        [HttpPatch]
        public IActionResult MerchantVoidTransactionsById(string merchantId, Guid transactionId)
        {
            var transaction = _transactionService.PatchMerchantVoidTransactionsById(merchantId, transactionId);
            if(transaction != null)
            {
                return Ok(transaction);
            }
            return NotFound();
        }
    }
}
