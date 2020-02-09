using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Events;

namespace Nop.Services.Catalog
{
    public partial class BatchService : IBatchService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Batch> _batchRepository;
        private readonly ICacheManager _cacheManager;


        public BatchService(
                IEventPublisher eventPublisher,
                IRepository<Batch> batchRepository
            )
        {
            _eventPublisher = eventPublisher;
            _batchRepository = batchRepository;
        }

        public void InsertBatch(Batch batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch));

            if (batch is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            _batchRepository.Insert(batch);

            // TODO cache activities


            //event notification
            _eventPublisher.EntityInserted(batch);

        }

        public void UpdateBatch(Batch batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch));

            if (batch is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            _batchRepository.Update(batch);

            // TODO cache activities

            //event notification
            _eventPublisher.EntityUpdated(batch);
        }

        public void DeleteBatch(Batch batch)
        {
            if (batch == null)
                throw new ArgumentNullException(nameof(batch));

            if (batch is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            _batchRepository.Delete(batch);

            // TODO cache activities

            //event notification
            _eventPublisher.EntityDeleted(batch);
        }

        public IPagedList<Batch> GetBatchesByProductId(int productId,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            if (productId == 0)
                return new PagedList<Batch>(new List<Batch>(), pageIndex, pageSize);

            var key = string.Format(NopCatalogDefaults.BatchesByProductIdCacheKey, productId);
            return _cacheManager.Get(key, () => {

                // TODO query

                var productBatches = new PagedList<Batch>(new List<Batch>(), pageIndex, pageSize);
                return productBatches;
            });
        }

        public Batch GetBatchById(int batchId)
        {
            if (batchId == 0)
                return null;

            var key = string.Format(NopCatalogDefaults.BatchesByIdCacheKey, batchId);
            return _cacheManager.Get(key, () => _batchRepository.GetById(batchId));
        }
    }
}
