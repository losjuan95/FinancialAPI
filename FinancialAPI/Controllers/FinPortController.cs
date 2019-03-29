using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static FinancialAPI.Models.FinMods;

namespace FinancialAPI.Controllers
{
    public class FinPortController : ApiController
    {
        // GET api/values
        private FinancialDB db = new FinancialDB();
        /// <summary>
        /// This endpoint is for retreiving all household data
        /// </summary>
        /// <remarks>implementaion notes</remarks>
        /// <returns>Returns a list of household data</returns>
        [Route("GetAllHouseHolds")]
        public async Task<List<HouseHolds>> GetAllHouseHolds()
        {
            return await db.GetAllHouseHolds();
        }
        /// <summary>
        /// Gets Specific HouseHolds Information
        /// </summary>
        /// <param name="id">id of household</param>
        /// <returns> Gets Specific HouseHolds Id, Greeting, and Description</returns>
        [Route("GetSpecifiedHouseHold")]
        public async Task <HouseHolds> GetSpecifiedHouseHold(int id)
        {
            return await db.GetSpecifiedHouseHold(id);
        }


        /// <summary>
        ///This EndPoint Retrieves All Accounts Within the Project
        /// </summary>
        /// <param name="houseid">House Id of Account </param>
        /// <returns> </returns>
        [Route("api/Accounts")]
        public async Task<List<Account>> GetAccounts(int houseid)
        {
            return await db.GetAccounts(houseid);
        }
        /// <summary>
        /// This Retrieves Accounts Details and information
        /// </summary>
        /// <param name="houseid"></param>
        /// <returns>returns a house hold id</returns>
        [Route("GetAccountDetails")]
        public async Task<Account>GetAccountDetails(int houseid)
        {
            return await db.GetAccountDetails(houseid);
        }
        /// <summary>
        /// Add a new account to a given HouseHold
        /// </summary>
        /// <param name="Name">Name of Account</param>
        /// <param name="HouseId">id of house that the account is linked in</param>
        /// <param name="InitialBalance">balance that the account started at</param>
        /// <param name="CurrentBalance">balance that account is currently at</param>
        /// <param name="ReconiledBalance">edits in accounts</param>
        /// <param name="LowBalanceLimit">limit that the account owner has set for specific reasons</param>
        /// <returns></returns>
        [Route("AddAccounts")]
        public IHttpActionResult AddAccounts(string Name, int HouseId, decimal InitialBalance, decimal CurrentBalance, decimal ReconiledBalance, decimal LowBalanceLimit)
        {
            return Ok(db.AddAccounts(Name, HouseId, InitialBalance, CurrentBalance, ReconiledBalance, LowBalanceLimit));
        }

        /// <summary>
        /// Retrieve all Transaction data for a given Account
        /// </summary>
        /// <param name="transacionid">Specific id of a transaction</param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<List<Transactions>>GetTransactions(int transacionid)
        {
            return await db.GetTransactions(transacionid);
        }

       /// <summary>
       /// Retrieve all Transaction data for a given Account
       /// </summary>
       /// <param name="Transid">retrieves details of this transaction id</param>
       /// <returns></returns>
        [Route("GetTransactionDetail")]
        public async Task<Transactions> GetTransactionDetails(int Transid)
        {
            return await db.GetTransactionDetails(Transid);
        }
        /// <summary>
        /// Add a new Transaction to a given Account
        /// </summary>
        /// <param name="accountid">Account that the transaction is linked to</param>
        /// <param name="description">Describes what the transaction is</param>
        /// <param name="amount">Amount that the transaction was</param>
        /// <param name="type">Withdrawal or Deposit</param>
        /// <param name="user">The user who entered the transaction</param>
        /// <param name="reconciled">Was the transaction edited</param>
        /// <param name="reconciledamount">If so how much was the amount</param>
        /// <param name="bud">Budget Id linked to this transaction</param>
        /// <returns></returns>
        [Route("AddTransactions")]
        public async Task<IHttpActionResult> AddTransactions(int accountid, string description, decimal amount, int type, string user, bool reconciled, decimal reconciledamount, int bud)
        {
            return Ok(await db.AddTransactions(accountid, description, amount, type,user,reconciled,reconciledamount,bud));
        }
        /// <summary>
        /// Delete the information towards a specific transaction
        /// </summary>
        /// <param name="Transid">Id of transaction</param>
        /// <returns></returns>
        [Route("DeleteTransactions")]
        public async Task<int> DeleteTransactions(int Transid)
        {
            return await db.DeleteTransactions(Transid);
        }

        /// <summary>
        /// Retrieve all Budget Item data that rolls up under a Budget
        /// </summary>
        /// <param name="houseid">Id of house that the budget item is linked to</param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<Budget>> GetBudgets(int houseid)
        {
            return await db.GetBudgets(houseid);
        }
        /// <summary>
        /// Retrieve specific Budget detail data
        /// </summary>
        /// <param name="budgetid">Budget id </param>
        /// <returns></returns>
        [Route("GetBudgetsDetails")]
        public async Task<Budget> GetBudgetDetails(int budgetid)
        {
            return await db.GetBudgetDetails(budgetid);
        }

        /// <summary>
        /// Add a new Budget to a given Household
        /// </summary>
        /// <param name="Name">Name of the Budget </param>
        /// <param name="Description">Describe what the budget is </param>
        /// <param name="TargetTotal">Type in the goal that you aim to hit </param>
        /// <param name="CurrentTotal">Type in the current total of your budget now</param>
        /// <param name="Houseid">Id of the household that is linked in to the budget</param>
        /// <returns></returns>
        [Route("AddBudget")]
        public async Task<IHttpActionResult>AddBudget(string Name, string Description, decimal TargetTotal, decimal CurrentTotal, int Houseid)
        {
            return Ok(await db.AddBudget(Name, Description, TargetTotal, CurrentTotal, Houseid));
        }

        /// <summary>
        /// Retrieve all Budget Item data that rolls up under a Budget
        /// </summary>
        /// <param name="BudgetId">Budget id of the budget item</param>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems(int BudgetId)
        {
            return await db.GetBudgetItems(BudgetId);
        }
        /// <summary>
        /// Retrieve speific Budget Item Detail data
        /// </summary>
        /// <param name="Itemid"> Id of the budget item that you are trying to retrieve</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItem> GetBudgetItemDetails(int Itemid)
        {
            return await db.GetBudgetItemDetails(Itemid);
        }
       
       
    }
}
