using System.IO;
using System.Threading.Tasks;

namespace RTLDemo
{
    public interface ISave
    {
        void Save(string filename, string contentType, MemoryStream stream);
    }
    public interface ISaveWindowsPhone
    {
        Task Save(string filename, string contentType, MemoryStream stream);
    }

    public interface IAndroidVersionDependencyService
    {
        int GetAndroidVersion();
    }
    public interface IMailService
    {
        void ComposeMail(string fileName, string[] recipients, string subject, string messagebody, MemoryStream documentStream);
    }
}
