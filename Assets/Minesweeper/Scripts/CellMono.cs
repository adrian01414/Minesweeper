using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Minesweeper
{
    [RequireComponent(typeof(Image))]
    public class CellMono : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TMP_Text _minesCountText = null;

        public int I { get; private set; } = 0;
        public int J { get; private set; } = 0;

        public bool IsFlag = false;

        private bool _isOpened = false;
        private bool _mouseOnCell = false;
        private Image _image = null;
        private IGridView _gridView = null;

        private void Awake()
        {
            _isOpened = false;
            _image = GetComponent<Image>();
            _image.raycastTarget = true;
            _minesCountText.gameObject.SetActive(false);
        }

        public void Initialize(int i, int j, IGridView gridView)
        {
            I = i;
            J = j;
            _gridView = gridView;
        }

        public void OpenSell()
        {
            _isOpened = true;
            _image.raycastTarget = false;
        }

        public void SetSprite(Sprite sprite)
        {
            if(!_isOpened)
                _image.sprite = sprite;
        }

        public void SetMinesCount(string mineCountText)
        {
            if (!_isOpened)
            {
                _minesCountText.text = mineCountText;
                _minesCountText.gameObject.SetActive(true);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _mouseOnCell = true;
            _gridView.CellMouseEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _mouseOnCell = false;
            _gridView.CellMouseExit(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                _gridView.CellRightMouseDown(this);
            }
            _gridView.CellMouseDown(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_mouseOnCell)
            {
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    _gridView.CellLeftMouseUp(this);
                }
                _gridView.CellMouseUp(this);
            }
        }
    }
}