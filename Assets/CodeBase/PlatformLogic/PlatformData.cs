using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/Platforms/PlatformConfig", fileName = "PlatformConfig", order = 54)]
public class PlatformData : ScriptableObject
{
    [field: SerializeField] public PlatformType Type { get; private set; }
    [field: SerializeField] public Platform PlatformPrefab { get; private set; }
}
