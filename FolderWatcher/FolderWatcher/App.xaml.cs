using System.Windows;
using Autofac;
using FolderWatcher.Infrastructure;
using FolderWatcher.Views;

namespace FolderWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContainer _container;

        public App()
        {
            _container = new IocContainerBuilder().Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainView = _container.Resolve<MainView>();
            mainView.ShowDialog();
        }
    }
}
