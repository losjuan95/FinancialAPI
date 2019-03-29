using FinancialAPI.Enumerations;
using FinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static FinancialAPI.Models.FinMods;

namespace FinancialAPI
{
    public class FinancialDB : DbContext

    {
        public FinancialDB()
            : base("DefaultConnection")
        { }


        public static FinancialDB Create()
        {
            return new FinancialDB();
        }

        public DbSet<HouseHolds> houseHolds { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transactions> transactions { get; set; }
        public DbSet<Budget> budgets { get; set; }
        public DbSet<BudgetItem> budgetItems { get; set; }

        //using the parameters in sql to make a method where you can run it in your controllers
        public Task<List<HouseHolds>> GetAllHouseHolds()
        {
            return Database.SqlQuery<HouseHolds>("GetAllHouseHolds").ToListAsync();
        }

        public async Task<HouseHolds> GetSpecifiedHouseHold(int houseid)
        {
            return await Database.SqlQuery<HouseHolds>("GetSpecifiedHouseHold @id",
                new SqlParameter("id", houseid)).FirstOrDefaultAsync();
        }


        public async Task<List<Account>> GetAccounts(int houseid)
        {
            return await Database.SqlQuery<Account>("GetAccounts @houseid",
                new SqlParameter("houseid", houseid)).ToListAsync();
        }

        public Task<Account> GetAccountDetails(int houseid)
        {
            return Database.SqlQuery<Account>("GetAccountDetails @houseid",
                new SqlParameter("houseid", houseid)).FirstOrDefaultAsync();
        }
       
        
        public Task<List<Transactions>>GetTransactions(int transactionid)
        {
            return Database.SqlQuery<Transactions>("GetTransactions @transactionid",
                new SqlParameter("transactionid", transactionid)).ToListAsync();
        }

        public Task<Transactions> GetTransactionDetails(int Transid)
        {
            return Database.SqlQuery<Transactions>("GetTransactionDetails @Transid",
                 new SqlParameter("Transid", Transid)).FirstOrDefaultAsync();
        }


        public Task<List<Budget>> GetBudgets(int houseid)
        {
            return Database.SqlQuery<Budget>("GetBudgets @houseid",
                new SqlParameter("houseid", houseid)).ToListAsync();
        }

        public Task<Budget> GetBudgetDetails(int budgetid)
        {
            return Database.SqlQuery<Budget>("GetBudgetDetails @budgetid",
                new SqlParameter("budgetid", budgetid)).FirstOrDefaultAsync();
        }


        public Task<BudgetItem> GetBudgetItemDetails(int Itemid)
        {
            return Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @Itemid",
                new SqlParameter("Itemid", Itemid)).FirstOrDefaultAsync();
        }

        public Task<List<BudgetItem>> GetBudgetItems(int BudgetId)
        {
            return Database.SqlQuery<BudgetItem>("GetBudgetItems @BudgetId",
                            new SqlParameter("BudgetId", BudgetId)).ToListAsync();
        }


        public int AddAccounts(string Name, int HouseId, decimal InitialBalance, decimal CurrentBalance, decimal ReconciledBalance, decimal LowBalanceLimit)
        {
            return Database.ExecuteSqlCommand("AddAccounts @Name, @HouseId, @InitialBalance, @CurrentBalance, @ReconciledBalance, @LowBalanceLimit",
                new SqlParameter ("Name", Name),
                new SqlParameter("HouseId", HouseId),
                new SqlParameter("InitialBalance", InitialBalance),
                new SqlParameter("CurrentBalance", CurrentBalance),
                new SqlParameter("ReconciledBalance", ReconciledBalance),
                new SqlParameter("LowBalanceLimit", LowBalanceLimit)
                 
                );
        }

        public async Task<int> AddBudget(string Name,string Description, decimal TargetTotal, decimal CurrentTotal, int Houseid)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @Name, @Description, @TargetTotal, @CurrentTotal, @Houseid",
                new SqlParameter("Name", Name),
                new SqlParameter("Description", Description),
                new SqlParameter("TargetTotal", TargetTotal),
                new SqlParameter("CurrentTotal", CurrentTotal),
                new SqlParameter("Houseid", Houseid)
                );
        }


        public async Task<int> AddTransactions(int accountid, string descrip, decimal amount,int type, string Enteredby, bool reconciled, decimal reconciledAmount, int BudgetItem)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransactions @accountid, @Description, @Amount, @Type, @Enteredby, @Reconciled, @ReconciledAmount, @BudgetItem",
                new SqlParameter("accountid", accountid),
                new SqlParameter("Description", descrip),
                new SqlParameter("Amount", amount),
                new SqlParameter("Type", type),
                new SqlParameter("Enteredby", Enteredby),
                new SqlParameter("Reconciled", reconciled),
                new SqlParameter("ReconciledAmount", reconciledAmount),
                new SqlParameter("BudgetItem", BudgetItem)
                                  
               );
        }

        public async Task<int>DeleteTransactions(int Transid)
        {
             return await Database.ExecuteSqlCommandAsync("DeleteTransactions @Transid",
                new SqlParameter("Transid", Transid));     
        }
        
    }
}