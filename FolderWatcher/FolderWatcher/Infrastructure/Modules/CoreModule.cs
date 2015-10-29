using Autofac;
using FolderWatcher.Core;
using FolderWatcher.Core.Interfaces.FileReaders;

namespace FolderWatcher.Infrastructure.Modules
{
    public class CoreModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileReaderHelper>().As<IFileReaderHelper>();
        }
    }
}
