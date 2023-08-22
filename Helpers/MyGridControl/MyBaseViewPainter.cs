using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class MyBaseViewPainter : GridPainter
    {
        public MyBaseViewPainter(MyGridView view)
            : base(view)
        {
        }
        public override void Draw(ViewDrawArgs ee)
        {
            base.Draw(ee);
        }

        protected override void DrawBorder(ViewDrawArgs e, System.Drawing.Rectangle r)
        {
            if (!e.ViewInfo.ShowTabControl)
                base.DrawBorder(e, r);
            else
                base.DrawTabControl(e);
        }
        protected override void DrawTabControl(ViewDrawArgs e)
        {
            base.DrawTabControl(e);
        }
    }
}
