using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class BatchMap : NopEntityTypeConfiguration<Batch>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable(nameof(Batch));
            builder.HasKey(batch => batch.Id);

            builder.Property(batch => batch.Name).HasMaxLength(400).IsRequired();

            builder.Ignore(batch => batch.BatchStatus);

            base.Configure(builder);
        }

        #endregion
    }
}
