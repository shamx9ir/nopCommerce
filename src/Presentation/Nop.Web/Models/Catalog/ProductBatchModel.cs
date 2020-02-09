using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    public partial class ProductBatchModel : BaseNopModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BatchStatusId { get; set; }

        public string StatusMessage { get; set; }

    }
}
