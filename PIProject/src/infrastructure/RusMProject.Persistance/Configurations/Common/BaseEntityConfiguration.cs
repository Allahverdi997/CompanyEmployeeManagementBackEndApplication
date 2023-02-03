using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RusMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Configurations.Common
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity,IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatorUserId).HasColumnName("CreatorUserId");
            builder.Property(x => x.CreatorDate).HasColumnName("CreatorDate");
            builder.Property(x => x.EditorUserId).HasColumnName("EditorUserId");
            builder.Property(x => x.EditorDate).HasColumnName("EditorDate");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");

            builder.HasQueryFilter(x => x.IsActive==true);
        }
    }
}
