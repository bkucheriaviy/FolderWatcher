using Autofac;
using FolderWatcher.BusinessLayer.FileReaders.TextStockFileReader;
using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.FileReaders.TextStockFileReader;

namespace FolderWatcher.Infrastructure.Modules
{
    public class TextStockFileReaderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextStockFileReader>().As<IFileReader>();
            builder.RegisterType<TextStockFileMapper>().As<ITextStockFileMapper>();
        }
    }
}
