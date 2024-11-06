using System.Collections.Generic;
using System.Linq;
using Common.Infrastructure.Services.AssetsManagement;
using Common.StaticData;

namespace Common.Infrastructure.Services.StaticData
{
    public sealed class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        
        private Dictionary<string, ItemStaticData> _itemsStaticData = new();
        

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadData()
        {
            _itemsStaticData.Clear();
            var itemsData = _assetProvider.loadItemsStaticData();
            _itemsStaticData = itemsData.ToDictionary(key => key.Name, value => value);
        }
    }
}