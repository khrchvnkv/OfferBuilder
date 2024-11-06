using Common.StaticData;
using UnityEngine;

namespace Common.Infrastructure.Services.AssetsManagement
{
    public interface IAssetProvider
    {
        ItemStaticData[] LoadItemsStaticData();
        GameObject Load(in string path);
    }
}