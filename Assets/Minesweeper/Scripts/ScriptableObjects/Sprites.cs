using UnityEngine;

[CreateAssetMenu(fileName = "Sprites", menuName = "Scriptable Objects/Sprites")]
public class Sprites : ScriptableObject
{
    [field: SerializeField] public Sprite DefaultCellImage { get; private set; } = null;
    [field: SerializeField] public Sprite DisabledCellImage { get; private set; } = null;
    [field: SerializeField] public Sprite SelectedCellImage { get; private set; } = null;
    [field: SerializeField] public Sprite PressedCellImage { get; private set; } = null;
    [field: SerializeField] public Sprite BombImage { get; private set; } = null;
    [field: SerializeField] public Sprite FlagImage { get; private set; } = null;
}
