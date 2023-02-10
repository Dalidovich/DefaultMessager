using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class RelationAccountConfig : IEntityTypeConfiguration<RelationAccount>
    {
        public const string Table_name = "relations";
        public void Configure(EntityTypeBuilder<RelationAccount> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("Id");

            builder.Property(e => e.AccountId1)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account1_id");

            builder.Property(e => e.AccountId2)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account2_id");

            builder.Property(e => e.Status)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("status");
        }
    }
}
