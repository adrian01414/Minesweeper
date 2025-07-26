namespace Minesweeper
{
    public interface IGridView
    {
        public void CellMouseEnter(CellMono cell);
        public void CellMouseExit(CellMono cell);
        public void CellRightMouseDown(CellMono cell);
        public void CellLeftMouseUp(CellMono cell);
        public void CellMouseUp(CellMono cell);
        public void CellMouseDown(CellMono cell);
    }
}