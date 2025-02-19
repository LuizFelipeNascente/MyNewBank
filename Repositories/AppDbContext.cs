using System;
using Microsoft.EntityFrameworkCore;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class AppDbContext : DbContext
{
    public string DbPath { get; }

    public DbSet<AccountBankModel> AccountBank { get; set; }

    public DbSet<TransactionModel> Transactions { get; set; }

    public AppDbContext()
    {
        DbPath = "DataBase/Mybank.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
}
