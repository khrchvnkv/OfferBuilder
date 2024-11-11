using Common.StaticData;
using UnityEngine;

namespace Common.Infrastructure.Services.AssetsManagement
{
    public sealed class AssetProvider : IAssetProvider
    {
        private const string ITEMS_STATIC_DATA_PATH = "StaticData";

        public ItemStaticData[] LoadItemsStaticData() => LoadAll<ItemStaticData>(ITEMS_STATIC_DATA_PATH);
        
        public T Load<T>(in string path) where T : Object => Resources.Load<T>(path);
        
        private T[] LoadAll<T>(in string path) where T : Object => Resources.LoadAll<T>(path);
    }
}