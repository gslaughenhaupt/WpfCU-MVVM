using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCU_MVVM.View;
using WpfCU_MVVM.ViewModel;
namespace WpfCU_MVVM
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string[] args { get; set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            args = e.Args;
            MainWindow wnd = new MainWindow();
            wnd.DataContext = new MainViewModel(e.Args);
            wnd.Show();
        }
    }
}
