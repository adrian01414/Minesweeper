using NaughtyAttributes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GridView : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab = null;
    [SerializeField] private RectTransform _gameArea = null;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup = null;

    private int _minSize = 10;
    private int _maxSize = 100;
    private float _gameAreaSize = 900.0f;
    private int _gridSize = 10;

    [Inject]
    public void Initialize(LevelConfig levelConfig)
    {
        _gridSize = levelConfig.GridSize;
        _gameAreaSize = _gameArea.sizeDelta.x;
    }

    [Button]
    public void DrawGrid()
    {
        if (_gridSize < _minSize)
        {
            throw new System.ArgumentOutOfRangeException("GridSize can not be less than " + _minSize);
        }
        else if (_gridSize > _maxSize)
        {
            throw new System.ArgumentOutOfRangeException("GridSize can not be more than " + _maxSize);
        }

        float cellSize = _gameAreaSize / _gridSize;

        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);

        for (int j = 0; j < _gridSize; j++)
        {
            for (int i = 0; i < _gridSize; i++)
            {
                Instantiate(_cellPrefab, _gameArea);
            }
        }
    }
}
