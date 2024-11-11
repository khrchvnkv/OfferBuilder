using Common.StaticData;
using UnityEngine;

namespace Common.Infrastructure.Services.AssetsManagement
{
    public interface IAssetProvider
    {
        ItemStaticData[] LoadItemsStaticData();
        T Load<T>(in string path) where T : Object;
    }
}