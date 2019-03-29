using FinancialAPI.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    public class FinMods
    {
        /// <summary>
         /// 
        /// </summary>
        public class HouseHolds
        {
            /// <summary>
            /// House id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Description of the house
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Name of the house itself
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// A warm welcome the user has set to greet new members
            /// </summary>
            public string Greeting { get; set; }
        }
        /// <summary>
        ///
        /// </summary>
        public class Transactions
        {
            /// <summary>
            /// Id of transaction
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Id of the account that the transaction is linked to
            /// 
            /// </summary>
            public int AccountId { get; set; }
            /// <summary>
            /// Describe the transaction
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Date that the transaction was made
            /// </summary>
            public DateTime Date { get; set; }
            /// <summary>
            /// Amount of the transaction
            /// </summary>
            public decimal Amount { get; set; }
            /// <summary>
            /// Was the Transaction a Withdrawal or a Deposit
            /// </summary>
            public TransactionType Type { get; set; }
            /// <summary>
            /// Id of the User who entered the transaction
            /// </summary>
            public string EnteredById { get; set; }
            /// <summary>
            /// Was the transaction Edited
            /// </summary>
            public bool Reconciled { get; set; }
            /// <summary>
            /// If the transaction was edited then how much was the amount
            /// 
            /// </summary>
            public decimal ReconciledAmount { get; set; }
            /// <summary>
            /// Id of the budget item that the transaction is linked to
            /// </summary>
            public int? BudgetItemId { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class Account
        { 
            /// <summary>
            /// Id of the Account
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Name of the Account 
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// House Hold Id that the Account is linked to
            ///
            /// </summary>
            public int HouseHoldId { get; set; }
            /// <summary>
            /// Starting Balance of the Account
            /// </summary>
            public decimal InitialBalance { get; set; }
            /// <summary>
            /// /Current balance of the Account
            /// </summary>
            public decimal CurrentBalance { get; set; }
            /// <summary>
            /// Was the balance edited?
            /// </summary>
            public decimal ReconciledBalance { get; set; }
            /// <summary>
            /// Low balance amount that the user has set for a specific reason
            /// </summary>
            public decimal LowBalanceLimit { get; set; }

        }
        /// <summary>
        /// 
        /// </summary>
        public class Budget
        {
            /// <summary>
            /// Id of Budget
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Name of Budget
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Description of what the Budget itself is
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Goal of Budget that is set 
            /// </summary>
            public decimal TargetTotal { get; set; }
            /// <summary>
            /// Current Budget Total
            /// </summary>
            public decimal CurrentTotal { get; set; }


        }
        /// <summary>
        /// 
        /// </summary>
        public class BudgetItem
        {
            /// <summary>
            /// Id of Budget Item
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Name of the Budget Item
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Description of Budget Item 
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Total Target that the Budget Item has
            /// </summary>
            public decimal TargetTotal { get; set; }
            /// <summary>
            /// Current Total of the Budget Item
            /// </summary>
            public decimal CurrentTotal { get; set; }
            /// <summary>
            /// Id of the Budget that is linked to the Budget Item
            /// </summary>
            public int BudgetId { get; set; }

           


        }
    }
}