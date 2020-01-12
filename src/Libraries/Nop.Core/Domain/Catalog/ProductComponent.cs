using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductComponent : BaseEntity, ILocalizedEntity
    {
        public int ProductId { get; set; }

        public int ComponentId { get; set; }

        public decimal Units { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Product Product { get; set; }

        public virtual Component Component { get; set; }


    }
}
