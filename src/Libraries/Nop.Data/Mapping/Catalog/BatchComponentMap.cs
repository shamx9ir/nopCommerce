using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class BatchComponentMap : NopEntityTypeConfiguration<BatchComponent>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<BatchComponent> builder)
        {
            builder.ToTable(NopMappingDefaults.BatchComponentTable);
            builder.HasKey(batchComponent => batchComponent.Id);

            builder.HasOne(batchComponent => batchComponent.Batch)
                .WithMany(batch => batch.BatchComponents)
                .HasForeignKey(batchComponent => batchComponent.BatchId)
                .IsRequired();

            builder.HasOne(batchComponent => batchComponent.Component)
                .WithMany()
                .HasForeignKey(batchComponent => batchComponent.ComponentId)
                .IsRequired();

            builder.Property(batchComponent => batchComponent.Limit).HasColumnType("decimal(18, 4)");
            builder.Ignore(batchComponent => batchComponent.LimitType);

            base.Configure(builder);
        }

        #endregion
    }
}
