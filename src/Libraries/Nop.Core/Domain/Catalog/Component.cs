using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    public partial class Component : BaseEntity, ILocalizedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UnitTypeId { get; set; }

        public UnitType UnitType { get; set; }

    }
}
