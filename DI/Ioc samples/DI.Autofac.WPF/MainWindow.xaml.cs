using Autofac;
using DI.WPF.ViewModels;
using System.Windows;

namespace DI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IMainWindowViewModel viewModel
                = App.Container.Resolve<IMainWindowViewModel>();

            this.DataContext = viewModel;
        }
    }
}
