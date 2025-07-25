using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEngine.Rendering.DebugUI.Table;

namespace Minesweeper
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GridView _gridView;

        private void Awake()
        {
            _gridView.DrawGrid();
        }
    }
}