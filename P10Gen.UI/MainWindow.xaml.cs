using System.Threading.Tasks;
using System.Windows;

namespace P10Gen.UI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = 
                new MainWindowViewModel();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel) DataContext).NewPhases();
        }
    }
}
