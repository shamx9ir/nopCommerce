using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class ProductComponentMap : NopEntityTypeConfiguration<ProductComponent>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<ProductComponent> builder)
        {
            builder.ToTable(NopMappingDefaults.ProductComponentTable);
            builder.HasKey(productComponent => productComponent.Id);

            builder.HasOne(productComponent => productComponent.Product)
                .WithMany(product => product.ProductComponents)
                .HasForeignKey(productComponent => productComponent.ProductId)
                .IsRequired();

            builder.HasOne(productComponent => productComponent.Component)
                .WithMany()
                .HasForeignKey(productComponent => productComponent.ComponentId)
                .IsRequired();

            builder.Property(productComponent => productComponent.Units).HasColumnType("decimal(18, 4)");

            base.Configure(builder);
        }

        #endregion
    }
}
