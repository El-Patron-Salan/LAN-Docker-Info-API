using LANDockerInfoAPI.JsonProperties;
using Microsoft.AspNetCore.Mvc;

namespace LANDockerInfoAPI.Controllers
{
    [ApiController]
    [Route("API/Docker")]
    public class DockerInfoController : Controller
    {
        [HttpGet("SystemInformation")]
        public List<SystemProperties> GetSystemInformation()
        {
            return SerializationController<SystemProperties>.Deserialize("SystemInformation.json");
        }

        [HttpGet("ContainersInformation")]
        public List<ContainerProperties> GetContainersInformation()
        {
            return SerializationController<ContainerProperties>.Deserialize("ContainersInformation.json");
        }

        [HttpGet("ImagesInformation")]
        public List<ImageProperties> GetImagesInformation()
        {
            return SerializationController<ImageProperties>.Deserialize("ImagesInformation.json");
        }
    }
}
