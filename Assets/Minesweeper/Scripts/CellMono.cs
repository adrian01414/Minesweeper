using System.Collections;
using UnityEngine;

namespace Minesweeper
{
    public class CellMono : MonoBehaviour
    {
        public int I {  get; private set; }
        public int J { get; private set; }

        private void Awake()
        {
            
        }

        public void SetIndex(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}