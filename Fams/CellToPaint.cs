using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Fams
{
    class CellPaintHelper : IDisposable
    {
        private GridView view;
        private GridColumn column;
        private int rowHandle;
        private Timer timer;

        private CellPaintHelper(GridView gridView, int rowHandle, GridColumn column)
        {
            this.view = gridView;
            view.CustomDrawCell += new RowCellCustomDrawEventHandler(OnCustomDrawCell);

            this.rowHandle = rowHandle;
            this.column = column;

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(OnTimer);

            timer.Start();
        }

        public static CellPaintHelper CreateCellPaintHelper(GridView gridView, int rowHandle, GridColumn column)
        {
            return new CellPaintHelper(gridView, rowHandle, column);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            timer.Stop();
            view.InvalidateRowCell(rowHandle, column);
        }

        private void OnCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column == column && e.RowHandle == rowHandle)
                if (timer.Enabled)
                    e.Appearance.BackColor = Color.Red;
                else
                    e.Appearance.BackColor = view.Appearance.Row.BackColor;
        }

        public void Dispose()
        {
            view.CustomDrawCell -= OnCustomDrawCell;
            timer.Dispose();
        }
    }
}