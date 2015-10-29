using Autofac;
using FolderWatcher.BusinessLayer.FileReaders.CsvStockFileReader;
using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.FileReaders.CsvStockFileReader;

namespace FolderWatcher.Infrastructure.Modules
{
    public class CsvStockFileReaderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CsvStockFileReader>().As<IFileReader>();
            builder.RegisterType<CsvStockFileMapper>().As<ICsvStockFileMapper>();
        }
    }
}
