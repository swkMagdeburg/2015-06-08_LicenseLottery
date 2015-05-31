using System.Windows;

namespace LicenseLottery.UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = new MainViewModel();
            var view = new MainWindow { DataContext = mainViewModel };
            view.Show();
        }
    }
}
