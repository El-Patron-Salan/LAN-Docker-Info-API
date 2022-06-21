using System.Xml;
using System.Xml.Serialization;

namespace LANDockerInfoAPI.Controllers
{
    internal class SerializationController<T>
    {
        private readonly XmlSerializer xmlSerializer = new(typeof(T));

        internal void Serialize<T>(T obj, string path)
        {
            StreamWriter streamWriter = new(path);
            xmlSerializer.Serialize(streamWriter, obj);
            streamWriter.Close();
        }

        internal void Deserialize<T>(T obj, string path)
        {
            using XmlReader read = XmlReader.Create(path);
            obj = (T?)xmlSerializer.Deserialize(read) ?? throw new InvalidOperationException("SerializationController.sc: invalid operation exception line 20");
        }
    }
}