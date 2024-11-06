using UnityEngine;

namespace Common.StaticData
{
    [CreateAssetMenu(menuName = "Create ItemStaticData", fileName = "ItemStaticData")]
    public class ItemStaticData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}