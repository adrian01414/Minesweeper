using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField, Range(5, 30)] public int GridSize { get; private set; } = 5;
    [field: SerializeField, Range(1, 900)] public int MinesCount { get; private set; } = 1;
}
