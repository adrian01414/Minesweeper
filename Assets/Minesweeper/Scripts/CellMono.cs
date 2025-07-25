using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper
{
    [RequireComponent(typeof(Button))]
    public class CellMono : MonoBehaviour
    {
        public static Action<CellMono> OnCellClicked;

        [SerializeField] private Image OverImage = null;
        [SerializeField] private TMP_Text NCountText = null;

        public int I {  get; private set; }
        public int J { get; private set; }

        private Button Button = null;

        private void Awake()
        {
            Button = GetComponent<Button>();
            Button.interactable = true;
            Button.onClick.AddListener(CellClick);
        }

        private void CellClick()
        {
            OnCellClicked?.Invoke(this);
            Button.interactable = false;
        }

        public void SetIndex(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}