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

        [SerializeField] public Image OverImage { get; private set; } = null;
        [SerializeField] public TMP_Text NCountText { get; private set; } = null;

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