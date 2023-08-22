using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Map;

namespace Helpers
{
    public class mapIcon : MapCustomElement
    {
        public enum MyPinType
        {
            gsm, portable, radiocom, rel_fixed, rel_mobile, rel_passive       
        }

        private GeoPoint _location;
        public GeoPoint location
        {
            get { return _location; }
        }

        public mapIcon(GeoPoint loc, MyPinType type)
        {
            _location = loc;

            switch (type)
            {
                case MyPinType.gsm: setImage(""); break;
                case MyPinType.portable: setImage(""); break;
                case MyPinType.radiocom: setImage(""); break;
                case MyPinType.rel_fixed: setImage(""); break;
                case MyPinType.rel_mobile: setImage(""); break;
                case MyPinType.rel_passive: setImage(""); break;
            }
        }

        private void setImage(string imageLocation)
        {
            /*this.Content = new Image() { Source = new BitmapImage(new Uri("Image/pushpin.png", UriKind.RelativeOrAbsolute)),
                                         Margin = new Thickness(-7, -28, 0, 0)
            };*/
             
        }

    }
}
