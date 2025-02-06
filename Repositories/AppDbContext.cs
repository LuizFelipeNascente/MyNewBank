using System;
using Microsoft.EntityFrameworkCore;

namespace MyNewBank.Repositories;

public class AppDbContext : DbContext
{
    public string DbPath { get; }

    public DbSet<AccountBankRepository> AccountBank { get; set; }

    //public DbSet<Transactions> Transactions { get; set; }

    public AppDbContext()
    {
        DbPath = "DataBase/Mybank.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
}
