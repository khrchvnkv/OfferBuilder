using UnityEngine;

namespace Common.StaticData
{
    [CreateAssetMenu(menuName = "Create ItemStaticData", fileName = "ItemStaticData")]
    public class ItemStaticData : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, Min(1)] public int LimitInSlot { get; private set; }
    }
}