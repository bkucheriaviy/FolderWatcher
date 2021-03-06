﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using FolderWatcher.BusinessLayer.FolderWatcher.Interfaces;
using FolderWatcher.Infrastructure.Modules;
using FolderWatcher.ViewModels;
using FolderWatcher.Views;

namespace FolderWatcher.Infrastructure
{
    public class IocContainerBuilder
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            RegisterModules(builder);
            RegisterPluggedInReaderModules(builder);

            builder.RegisterType<BusinessLayer.FolderWatcher.FolderWatcher>().As<IFolderWatcher>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.Register(c =>
            {
                var mainVm = c.Resolve<IMainViewModel>();
                var lookupFreq = ConfigurationManager.AppSettings["lookupFrequency"];
                var lookupFolder = ConfigurationManager.AppSettings["lookupFolderPath"];
                mainVm.StartLookup(TimeSpan.FromSeconds(int.Parse(lookupFreq)), lookupFolder);
                return new MainView(mainVm);
            }).As<MainView>();

            return builder.Build();
        }

        private void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new TextStockFileReaderModule());
            builder.RegisterModule(new CsvStockFileReaderModule());
           
        }

        private void RegisterPluggedInReaderModules(ContainerBuilder builder)
        {
            var path = Path.GetDirectoryName(ConfigurationManager.AppSettings["pluginsPath"]);
            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }

            var assemblies = Directory.GetFiles(path, "Module*.dll", SearchOption.TopDirectoryOnly)
                .Select(Assembly.LoadFrom);

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }
    }
}
