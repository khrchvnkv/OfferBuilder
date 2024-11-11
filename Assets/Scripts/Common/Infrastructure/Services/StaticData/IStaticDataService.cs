using Common.StaticData;

namespace Common.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        ItemStaticData[] ItemsStaticData { get; }
        void LoadData();
    }
}