using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField, Range(10, 100)] public int GridSize { get; private set; } = 10;
    [field: SerializeField, Range(1, 99)] public int MinesCount { get; private set; } = 10;
}
