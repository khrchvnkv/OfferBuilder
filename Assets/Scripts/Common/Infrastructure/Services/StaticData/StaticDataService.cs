using Common.Infrastructure.Services.AssetsManagement;
using Common.StaticData;

namespace Common.Infrastructure.Services.StaticData
{
    public sealed class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        
        public ItemStaticData[] ItemsStaticData { get; private set; }
        

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadData() => ItemsStaticData = _assetProvider.LoadItemsStaticData();
    }
}