using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagrangePolynomial
{
    internal class Line
    {
        double _x1, _x2, _y1, _y2;
        public double X1 => _x1;
        public double Y1 => _y1;
        public double X2 => _x2;
        public double Y2 => _y2;
        public Line(double x1, double x2, double y1, double y2) { 
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;

        }
    }
}
