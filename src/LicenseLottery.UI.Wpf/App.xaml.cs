using System.Windows;
using Microsoft.Practices.Unity;

namespace LicenseLottery.UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = Bootstrapper.GenerateContainer();

            var mainViewModel = container.Resolve(typeof(MainViewModel));
            var view = new MainWindow { DataContext = mainViewModel };
            view.Show();
        }
    }
}
