using System.Text;
using UnityEngine;

namespace Minesweeper {
    public class Bootstrap : MonoBehaviour
    {
        private int size = 10;
        private int mineCount = 10;

        private void Awake()
        {
            bool[,] mines = MineGenerator.Generate(size, size, mineCount);

            
        }
    }
}