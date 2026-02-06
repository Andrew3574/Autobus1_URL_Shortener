using System;
using System.Collections.Generic;
using Autobus1_Burlakov.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Autobus1_Burlakov.Data;

public partial class Autobus1dbContext : DbContext
{
    public Autobus1dbContext()
    {
    }

    public Autobus1dbContext(DbContextOptions<Autobus1dbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Urlsdatum> Urlsdata { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Urlsdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("urlsdata");

            entity.HasIndex(e => e.ShortUrl)
                .IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FullUrl)
                .HasColumnType("text")
                .HasColumnName("FullURL");
            entity.Property(e => e.PassageCounter).HasColumnType("int(11)");
            entity.Property(e => e.ShortUrl)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15)
                .HasColumnName("ShortURL");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasDefaultValueSql("CURRENT_DATE()")
                .ValueGeneratedOnAdd();

            entity.ToTable(t=>t.HasCheckConstraint("CONSTRAINT_1", "PassageCounter >= 0"));
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
