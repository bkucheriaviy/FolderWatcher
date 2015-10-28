using System.IO;
using System.Windows;
using FolderWatcher.BusinessLayer.FileReaders;
using FolderWatcher.ViewModels;
using FolderWatcher.Views;

namespace FolderWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var vm =
                new MainViewModel(new BusinessLayer.FolderWatcher.FolderWatcher(new[] {new TextFileReader()},
                    new FileSystemWatcher()));
            var mainView = new MainView
            {
                DataContext = vm
            };
            vm.StartLookup();
            mainView.Show();
        }
    }
}
