using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    public partial class BatchComponent : BaseEntity, ILocalizedEntity
    {
        public int BatchId { get; set; }

        public int ComponentId { get; set; }

        public int LimitTypeId { get; set; }

        public decimal Limit { get; set; }

        public BatchComponentLimitType LimitType
        {
            get => (BatchComponentLimitType)LimitTypeId;
            set => LimitTypeId = (int)value;
        }

        public int DisplayOrder { get; set; }

        public virtual Batch Batch { get; set; }

        public virtual Component Component { get; set; }

    }
}
