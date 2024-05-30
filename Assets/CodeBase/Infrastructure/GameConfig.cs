using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "StaticData/GameConfig", order = 54)]
public class GameConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 10)] public int PlatformsMarginY = 4;
}