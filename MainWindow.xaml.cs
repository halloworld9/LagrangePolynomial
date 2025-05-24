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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            Dots.ItemsSource = _vm.Dots;
            Lines.ItemsSource = _vm.Lines;
            this.Resources.Add("CircleSize", _vm.CircleSize);
        }

     
        private void MainCanvas_MouseClicked(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(MainCanvas);
            _vm.MouseClicked.Execute(e.GetPosition(MainCanvas));
        }
    }
}