using DevExpress.XtraGrid.Tab;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab.Registrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTab.Drawing;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System.Drawing;
using DevExpress.Utils.Drawing;

namespace Helpers
{
    public class MyViewTab : ViewTab
    {
        public MyViewTab(BaseView view) : base(view) { 

        }

        protected override DevExpress.XtraTab.Registrator.BaseViewInfoRegistrator GetView()
        {
            return new MySkinViewInfoRegistrator();
        }

        public override void Draw(DXPaintEventArgs e, GraphicsCache cache)
        {
            base.Draw(e, cache);
        }

    }

    public class MySkinViewInfoRegistrator : SkinViewInfoRegistrator
    {
        public MySkinViewInfoRegistrator() : base() { }
        public override BaseTabPainter CreatePainter(IXtraTab tabControl)
        {
            return new MySkinTabPainter(tabControl);
        }

        public override BaseTabHeaderViewInfo CreateHeaderViewInfo(BaseTabControlViewInfo viewInfo)
        {
            return new MySkinTabHeaderViewInfo(viewInfo);
        }

        public override BaseTabControlViewInfo CreateViewInfo(IXtraTab tabControl)
        {
            return new MySkinTabControlViewInfo(tabControl);
        }
    }

    public class MySkinTabControlViewInfo : SkinTabControlViewInfo
    {
        public MySkinTabControlViewInfo(IXtraTab tabControl)
            : base(tabControl)
        {
        }

        public override BaseTabPageViewInfo SelectedTabPageViewInfo
        {
            get
            {
                //return null;// 
                return base.SelectedTabPageViewInfo;
            }
        }
    }

    public class MySkinTabHeaderViewInfo : SkinTabHeaderViewInfo
    {
        public MySkinTabHeaderViewInfo(BaseTabControlViewInfo viewInfo) : base(viewInfo){
        }

        protected override int BorderToTabHeadersIndent
        {
            get
            {
                return base.BorderToTabHeadersIndent;
                //return 0;
            }
        }

        protected override int CalcBorderSideSize()
        {
            return base.CalcBorderSideSize();
        }

        protected override Size CalcPageClientSize(BaseTabPageViewInfo info)
        {
            return base.CalcPageClientSize(info);
            //return new Size(150, 20);
        }

        protected override BaseTabPageViewInfo CreatePage(IXtraTabPage page)
        {
            return new MyBaseTabPageViewInfo(page);
        }
        public override DevExpress.Utils.Drawing.ObjectState CalcPageState(IXtraTabPage page)
        {

            ObjectState state = base.CalcPageState(page);
            if (state == ObjectState.Selected)
            {
                state = ObjectState.Normal;
            }
            if (state == (ObjectState.Selected | ObjectState.Hot))
            {
                state = ObjectState.Hot;
            }
            return state;
        }


    }
    
    public class MyBaseTabPageViewInfo : BaseTabPageViewInfo
    {
        public MyBaseTabPageViewInfo(IXtraTabPage page) : base(page){
        }
    }
  

    public class MySkinTabPainter : SkinTabPainter
    {
        public MySkinTabPainter(IXtraTab tabControl)
            : base(tabControl)
        {
        }

        public override void Draw(TabDrawArgs e)
        {
            base.Draw(e);
            //e.Graphics.DrawLine(new Pen(Brushes.LightSkyBlue, 3), new Point(e.ViewInfo.HeaderInfo.Bounds.X, e.ViewInfo.HeaderInfo.Bounds.Bottom - 1), new Point(e.ViewInfo.HeaderInfo.Bounds.Right, e.ViewInfo.HeaderInfo.Bounds.Bottom - 1));
        }

    }


}
