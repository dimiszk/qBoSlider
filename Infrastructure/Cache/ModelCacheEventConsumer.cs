﻿using Nop.Core.Caching;
using Nop.Core.Domain.Configuration;
using Nop.Core.Events;
using Nop.Services.Events;

namespace Nop.Plugin.Widgets.qBoSlider.Infrastructure.Cache
{
    /// <summary>
    /// Model cache event consumer (used for caching of presentation layer models)
    /// </summary>
    public partial class ModelCacheEventConsumer: 
        IConsumer<EntityInsertedEvent<Setting>>,
        IConsumer<EntityUpdatedEvent<Setting>>,
        IConsumer<EntityDeletedEvent<Setting>>
    {
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// </remarks>
        public const string PICTURE_URL_MODEL_KEY = "Nop.plugins.widgets.qBoSlider.pictureurl-{0}";
        public const string PICTURE_URL_PATTERN_KEY = "Nop.plugins.widgets.qBoSlider";

        private readonly IStaticCacheManager _staticCacheManager;

        public ModelCacheEventConsumer(IStaticCacheManager staticCacheManager)
        {
            //TODO inject static cache manager using constructor
            this._staticCacheManager = staticCacheManager;
        }

        public void HandleEvent(EntityInsertedEvent<Setting> eventMessage)
        {
            _staticCacheManager.RemoveByPrefix(PICTURE_URL_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdatedEvent<Setting> eventMessage)
        {
            _staticCacheManager.RemoveByPrefix(PICTURE_URL_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeletedEvent<Setting> eventMessage)
        {
            _staticCacheManager.RemoveByPrefix(PICTURE_URL_PATTERN_KEY);
        }
    }
}