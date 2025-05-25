using LagrangePolynomial.viewmodel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LagrangePolynomial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm = new ViewModel();
        private System.Windows.Shapes.Line _axisX;
        private System.Windows.Shapes.Line _axisY;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            Dots.ItemsSource = _vm.Dots;
            Lines.ItemsSource = _vm.Lines;
            this.Resources.Add("CircleSize", _vm.CircleSize);

            _axisX = new System.Windows.Shapes.Line() { X1 = 0, X2 = 1000, Y1 = 500, Y2 = 500, 
                Stroke = new SolidColorBrush(Colors.Black), StrokeThickness = 2};
            _axisY = new System.Windows.Shapes.Line() { X1 = 500, X2 = 500, Y1 = 0, Y2 = 1000,
                Stroke = new SolidColorBrush(Colors.Black), StrokeThickness = 2};
            this.SizeChanged += MainWindow_SizeChanged;
            MainCanvas.Children.Add(_axisX);
            MainCanvas.Children.Add(_axisY);
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this._axisX.X2 = e.NewSize.Width;
            this._axisY.Y2 = e.NewSize.Height;
        }

        private void MainCanvas_MouseClicked(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(MainCanvas);
            _vm.MouseClicked.Execute(e.GetPosition(MainCanvas));
        }
    }
}