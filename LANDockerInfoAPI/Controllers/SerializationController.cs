using Newtonsoft.Json;

namespace LANDockerInfoAPI.Controllers
{
    internal class SerializationController<T>
    {
        ///Serialization is obsolete for now - it's a readonly API
        internal static List<T> Deserialize(string path)
        {
            String json;
            using (StreamReader streamReader = new(@$"S:\{path}", encoding: System.Text.Encoding.UTF8))
            {
                json = streamReader.ReadToEnd();
            }
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(json) ?? throw new Exception("SerializationController.sc: deserialization failed line 20");
            return obj;
        }
    }
}