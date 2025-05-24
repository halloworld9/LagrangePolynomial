using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagrangePolynomial.model
{
    internal class Lagrange
    {
        private readonly Point[] _coords;
        private Func<double, int, double>[] l;
        public Lagrange(params Point[] coords)
        {
            if (coords.Length < 2) throw new ArgumentException("input 2 or more coords");
            l = new Func<double, int, double>[coords.Length];
            this._coords = coords;

            for (int i = 0; i < coords.Length; i++)
            {
                l[i] = (double x, int i) =>
                {
                    double res = 1;
                    for (int j = 0; j < coords.Length; j++)
                    {
                        if (j == i) continue;
                        res *= (x - coords[j].X) / (coords[i].X - coords[j].X);
                    }
                    return res;
                };
            }

            _coords = coords;
        }

        public Point ComputePolynomial(double x)
        {
            double y = 0;
            for (int i = 0; i < l.Length; i++)
            {
                y += l[i](x, i) * this._coords[i].Y;
            }

            return new Point(x, y);
        }

        public Point[] ComputePolynomial(double[] x)
        {
            var points = new Point[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                points[i] = ComputePolynomial(x[i]);
            }
            return points;
        }
    }
}
