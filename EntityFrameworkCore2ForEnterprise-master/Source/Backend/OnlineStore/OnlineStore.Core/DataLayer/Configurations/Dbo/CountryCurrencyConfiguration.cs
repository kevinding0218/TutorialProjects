﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.EntityLayer.Dbo;

namespace OnlineStore.Core.DataLayer.Configurations.Dbo
{
    public class CountryCurrencyConfiguration : IEntityTypeConfiguration<CountryCurrency>
    {
        public void Configure(EntityTypeBuilder<CountryCurrency> builder)
        {
            // Mapping for table
            builder.ToTable("CountryCurrency", "dbo");

            // Set key for entity
            builder.HasKey(p => p.CountryCurrencyID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.CountryCurrencyID).UseSqlServerIdentityColumn();

            // Set mapping for columns
            builder.Property(p => p.CreationUser).HasColumnType("varchar(25)").IsRequired();
            builder.Property(p => p.CreationDateTime).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastUpdateUser).HasColumnType("varchar(25)");
            builder.Property(p => p.LastUpdateDateTime).HasColumnType("datetime");

            // Set concurrency token for entity
            builder.Property(p => p.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
        }
    }
}
