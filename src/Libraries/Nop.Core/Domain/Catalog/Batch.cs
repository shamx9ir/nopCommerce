using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    public partial class Batch : BaseEntity, ILocalizedEntity
    {
        private ICollection<BatchComponent> _batchComponents;

        public string Name { get; set; }

        public string Description { get; set; }

        public int BatchStatusId { get; set; }

        public BatchStatus BatchStatus
        {
            get => (BatchStatus)BatchStatusId;
            set => BatchStatusId = (int)value;
        }

        /// <summary>
        /// Parent product - Grouped product
        /// </summary>
        public int ParentProductId { get; set; }


        public virtual ICollection<BatchComponent> BatchComponents
        {
            get => _batchComponents ?? (_batchComponents = new List<BatchComponent>());
            protected set => _batchComponents = value;
        }
    }
}
