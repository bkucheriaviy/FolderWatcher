using Autofac;
using FolderWatcher.Core.Interfaces.FileReaders;
using XmlStockFileReader;
using XmlStockFileReader.Interfaces;

namespace ModuleXmlReader
{
    public class XmlStockFileReaderModule : Module
    {
        public XmlStockFileReaderModule()
        { }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<XmlStockFileReader.XmlStockFileReader>().As<IFileReader>();
            builder.RegisterType<XmlStockFileMapper>().As<IXmlStockFileMapper>();
            builder.RegisterType<XmlStockFileReaderHelper>().As<IXmlStockFileReaderHelper>();
        }
    }
}
