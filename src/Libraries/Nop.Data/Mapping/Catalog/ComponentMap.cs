using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class ComponentMap : NopEntityTypeConfiguration<Component>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.ToTable(nameof(Component));
            builder.HasKey(component => component.Id);

            builder.Property(component => component.Name).HasMaxLength(400).IsRequired();

            builder.Ignore(component => component.UnitType);

            base.Configure(builder);
        }

        #endregion
    }
}
