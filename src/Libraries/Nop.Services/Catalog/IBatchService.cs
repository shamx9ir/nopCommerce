using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    public partial interface IBatchService
    {

        // insert batch
        void InsertBatch(Batch batch);

        // update batch
        void UpdateBatch(Batch batch);

        // delete batch
        void DeleteBatch(Batch batch);

        // get batch
        Batch GetBatchById(int batchId);

        IPagedList<Batch> GetBatchesByProductId(int productId, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
