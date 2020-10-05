using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salt.WebApi.DataAccess;
using System.Collections.Generic;
using Salt.WebApi.Models;
using Salt.WebApi.Services;
using System;
using Moq;

namespace Salt.Tests.RepositoryTests
{
    [TestClass]
    public class DataAccessTests
    {
        private readonly TransactionService _service;
        private readonly Mock<IDataAccessTransaction> _transactionDataMock = new Mock<IDataAccessTransaction>();
        public DataAccessTests()
        {
            _service = new TransactionService(_transactionDataMock.Object);
        }

        [TestMethod]
        public void GetMerchantTransactionsByDate_ShouldReturnEnumoratorOf3()
        {
            var merchantId = "9876501";
            DateTime date = new DateTime(2020, 07, 01, 19, 44, 04);
            var transactionsList  = GetMockData();
            
            _transactionDataMock.Setup(x => x.GetMerchantTransactionsByDate(merchantId, date)).Returns(transactionsList);
            
            var transaction = _service.GetMerchantTransactionsByDate(merchantId, date);
            var getEnum = transaction.GetEnumerator();

            Assert.AreEqual(transactionsList.GetEnumerator(), getEnum);
        }

        [TestMethod]
        public void GetMerchantPaymentByDate_ShouldReturnTotalAmountOf68562()
        {
            var merchantId = "9876501";
            DateTime date = new DateTime(2020, 07, 01, 19, 44, 04);
            var transactionsList  = GetMockData();
            decimal total = 0;
            string curr = null;
            foreach(var item in transactionsList)
            {
                total += item.amount;
                curr = item.currency;
            };
            var totalDto = new TotalAmountDto 
            {
                merchant = merchantId,
                transdate = date,
                totalAmount = total,
                currency = curr
            };
            _transactionDataMock.Setup(x => x.GetMerchantPaymentByDate(merchantId, date)).Returns(totalDto);

            var transaction = _service.GetMerchantPaymentByDate(merchantId, date);
            var getTotalAmount = transaction.totalAmount;

            Assert.AreEqual(totalDto.totalAmount, getTotalAmount);
        }
        [TestMethod]
        public void PatchMerchantVoidTransactionsById_ShouldReturn()
        {
            var merchantId = "9876501";
            var transactionId = new Guid("7edefa97-9d01-4d35-a3f1-27fbe7527331");
            var transactionsList  = GetMockData();
            var voidedTransaction = new TransactionDto
            { 
                id = new Guid("7edefa97-9d01-4d35-a3f1-27fbe7527331"),
                transdate = new DateTime(2020, 07, 01, 19, 44, 04),
                merchant = "9876501",
                amount = 32854,
                currency = "EUR",   
                pan = "347738******9430",
                voided = true
            };

            _transactionDataMock.Setup(x => x.PatchMerchantVoidTransactionsById(merchantId, transactionId)).Returns(voidedTransaction);
            
            var transaction = _service.PatchMerchantVoidTransactionsById(merchantId, transactionId);

            Assert.IsTrue(transaction.voided);
        }

        public List<TransactionDto> GetMockData()
        {
            return new List<TransactionDto>()
            {
                new TransactionDto
                { 
                    id = new Guid("7edefa97-9d01-4d35-a3f1-27fbe7527331"),
                    transdate = new DateTime(2020, 07, 01, 19, 44, 04),
                    merchant = "9876501",
                    amount = 32854,
                    currency = "EUR",   
                    pan = "347738******9430",
                    voided = false
                },
                new TransactionDto
                { 
                    id = new Guid("7edefa97-9d01-4d35-a3f1-27fbe7527335"),
                    transdate = new DateTime(2020, 07, 01, 20, 44, 04),
                    merchant = "9876501",
                    amount = 12854,
                    currency = "EUR",   
                    pan = "347738******9530",
                    voided = false
                },
                new TransactionDto
                { 
                    id = new Guid("7edefa97-9d01-4d35-a3f1-23fbe7527331"),
                    transdate = new DateTime(2020, 07, 01, 21, 44, 04),
                    merchant = "9876501",
                    amount = 22854,
                    currency = "EUR",   
                    pan = "347738******9630",
                    voided = false
                }
            };
        }
    }
}