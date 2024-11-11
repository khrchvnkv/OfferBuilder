using Common.StaticData;

namespace Common.UnityLogic.UI.Components
{
    public sealed class OfferItem
    {
        public readonly ItemStaticData Item;
        public readonly int Count;

        public OfferItem(ItemStaticData item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}