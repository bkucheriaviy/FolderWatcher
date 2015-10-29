using System;
using System.Configuration;
using Autofac;
using FolderWatcher.BusinessLayer.FolderWatcher.Interfaces;
using FolderWatcher.ViewModels;
using FolderWatcher.Views;

namespace FolderWatcher.Infrastructure.Modules
{
    public class MainModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessLayer.FolderWatcher.FolderWatcher>().As<IFolderWatcher>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.Register(c =>
            {
                var lookupFreq = ConfigurationManager.AppSettings["lookupFrequency"];
                var lookupFolder = ConfigurationManager.AppSettings["lookupFolderPath"];

                var mainVm = c.Resolve<IMainViewModel>();
                mainVm.StartLookup(TimeSpan.FromSeconds(int.Parse(lookupFreq)), lookupFolder);

                return new MainView(mainVm);
            }).As<MainView>();
        }
    }
}
