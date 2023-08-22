using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Helpers
{
    public class Screen
    {
        private int _minY = 0;
        public int minY
        {
            set
            {
                if (value>0) _minY = -value-200;
                else _minY = 0;
            } 
        }

        private int _maxY = 0;


        private float _x = 0;
        public float X
        {
            get { Debug.WriteLine(_x, "_x"); return _x; }
        }

        private float _y = 0;
        public float Y
        {
            get { Debug.WriteLine(_y, "_y"); return _y; }
        }

        public float width;
        public float height;

        private float _zoom = 1;
        public float zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                _worldArea = new Rectangle((int)(_x / value), (int)(_y / value), (int)(width / value), (int)(height / value));
            }
        }


        private Rectangle _worldArea = Rectangle.Empty;
        public Rectangle WorldArea
        {
            get {  return _worldArea; }
        }

        public Screen(float w, float h)
        {
            width = (int)w;
            height = (int)h;
            _worldArea = new Rectangle((int)(_x ), (int)(_y ), (int)(width / _zoom), (int)(height / _zoom));
            _maxY = (int)(height / 2);

            Debug.WriteLine(width.ToString()+ " " + height.ToString(), "Screen");
        }

        public void Coords(float XX, float YY)
        {
            if (XX > 0) _x = 0; else _x = XX;
            if (YY < _minY) _y = _minY;
            else if (YY > _maxY) _y = _maxY;
            else _y = YY;
            _worldArea = new Rectangle((int)(_x ), (int)(_y ), (int)(width / _zoom), (int)(height / _zoom));
            _maxY = (int)(height / 2);

            Debug.WriteLine(XX.ToString() + ":" + _x.ToString() + " " + YY.ToString() + ":" + _y.ToString(), "Coords");
        }

        public Vector2 worldCoordinates(Vector2 currentMouse)
        {
            return new Vector2((currentMouse.X) / zoom + _worldArea.X, (currentMouse.Y) / zoom + _worldArea.Y);
        }
    }
}
