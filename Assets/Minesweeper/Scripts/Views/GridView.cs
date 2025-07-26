using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper
{
    public class GridView : MonoBehaviour, IGridView
    {
        public event Action<int, int> OnCellClick = null;

        [SerializeField] private GameObject _cellPrefab = null;
        [SerializeField] private RectTransform _gameArea = null;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup = null;

        private Theme _theme;
        private CellMono[,] _cells = null;

        private int _minSize = 10;
        private int _maxSize = 100;
        private float _gameAreaSize = 900.0f;
        private int _gridSize = 10;

        [Inject]
        private void Initialize(LevelConfig levelConfig, Theme theme)
        {
            _gridSize = levelConfig.GridSize;
            _gameAreaSize = _gameArea.sizeDelta.x;
            _cells = new CellMono[levelConfig.GridSize, levelConfig.GridSize];
            _theme = theme;
        }

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
                    var cell = Instantiate(_cellPrefab, _gameArea);
                    var cellMono = cell.GetComponent<CellMono>();
                    cellMono.SetSprite(_theme.DefaultCellImage);
                    cellMono.Initialize(i, j, this);
                    _cells[i, j] = cellMono;
                }
            }
        }

        public void CellMouseEnter(CellMono cell)
        {
            if(!cell.IsFlag)
                cell.SetSprite(_theme.SelectedCellImage);
        }

        public void CellMouseExit(CellMono cell)
        {
            if (!cell.IsFlag)
                cell.SetSprite (_theme.DefaultCellImage);
        }

        public void CellRightMouseDown(CellMono cell)
        {
            if (!cell.IsFlag)
            {
                cell.SetSprite(_theme.FlagImage);
                cell.IsFlag = true;
            } else
            {
                cell.SetSprite(_theme.DefaultCellImage);
                cell.IsFlag = false;
            }
        }

        public void CellLeftMouseUp(CellMono cell)
        {
            if (!cell.IsFlag)
            {
                OnCellClick?.Invoke(cell.I, cell.J);
            }
        }

        public void CellMouseUp(CellMono cell)
        {
            if (!cell.IsFlag)
                cell.SetSprite(_theme.DefaultCellImage);
        }

        public void CellMouseDown(CellMono cell)
        {
            if (!cell.IsFlag)
                cell.SetSprite(_theme.PressedCellImage);
        }

        public void OpenCell(int i, int j, int minesAroundCount, bool isMine)
        {
            if (isMine)
            {
                _cells[i, j].SetSprite(_theme.BombImage);
            } else
            {
                _cells[i, j].SetSprite(_theme.DisabledCellImage);
                if(minesAroundCount != 0)
                    _cells[i, j].SetMinesCount(minesAroundCount.ToString());
            }
            _cells[i, j].OpenSell();
        }
    }
}