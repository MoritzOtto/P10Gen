using System.Windows;
using P10Gen.Core.Services;
using P10Gen.Core.UtilAdapter;

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
                new MainWindowViewModel(
                    new CreateTenPhases(new CreatePhaseService(new RandomAdapter(),
                        new CreateCombinationService(new RandomAdapter()))));
            InitializeComponent();
        }
    }
}
