using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NascarAPI.Models;

public partial class NascarDbContext : DbContext
{
    public NascarDbContext()
    {
    }

    public NascarDbContext(DbContextOptions<NascarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RaceWinner> RaceWinners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nascar;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RaceWinner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceWinn__3214EC27DCB95765");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
