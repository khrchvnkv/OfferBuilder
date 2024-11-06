using Common.StaticData;
using UnityEngine;

namespace Common.Infrastructure.Services.AssetsManagement
{
    public interface IAssetProvider
    {
        ItemStaticData[] loadItemsStaticData();
        GameObject Load(in string path);
    }
}