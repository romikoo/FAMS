using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Helpers
{
    public class MyGridHandler : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
    {
        public MyGridHandler(GridView gridView) : base(gridView) { }

    }
}
