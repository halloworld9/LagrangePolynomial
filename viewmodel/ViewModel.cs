using LagrangePolynomial.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LagrangePolynomial.viewmodel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Line> Lines;
        public ObservableCollection<Point> Dots { get; set; }
        private HashSet<Point> _dots = new HashSet<Point>();
        private MouseCommand? _mouseCommand = null;
        private double _circleSize = 12;
        public double CircleSize => _circleSize;
        public MouseCommand MouseClicked
        {
            get
            {
                return _mouseCommand ?? (
                _mouseCommand = new MouseCommand(p =>
                {
                    Dots.Add(new Point(p.Value.X - _circleSize / 2, p.Value.Y - _circleSize / 2));
                    _dots.Add(new Point(p.Value.X, p.Value.Y));
                    if (Dots.Count < 2) return; 
                    Lines.Clear();
                    double max = 0;
                    double min = 0;
                    foreach (var item in _dots)
                    {
                        max = Math.Max(max, item.X);
                        min = Math.Min(min, item.X);
                    }
                    
                    var l = new Lagrange(_dots.ToArray());
                    var step = (max - min) / 500;
                    var lastDot = l.ComputePolynomial(min);
                    for (double i = min + step; i <= max + step; i+=step)
                    {
                        var dot = l.ComputePolynomial(i);
                        Lines.Add(new Line(lastDot.X, dot.X, lastDot.Y, dot.Y));
                        lastDot = dot;
                    }

                }));
            }
        }
        public ViewModel()
        {
            Dots = new ObservableCollection<Point>();

            Lines = new ObservableCollection<Line>();
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
