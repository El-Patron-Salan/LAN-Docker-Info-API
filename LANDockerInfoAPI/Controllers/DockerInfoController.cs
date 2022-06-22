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
            return SerializationController<List<SystemProperties>>.Deserialize("SystemInformation.json");
        }


        [HttpGet("ContainersInformation")]
        public List<ContainerProperties> GetContainersInformation()
        {
            return SerializationController<List<ContainerProperties>>.Deserialize("ContainersInformation.json");
        }

        [HttpGet("ContainersInformation/{image}")]
        public ContainerProperties GetContainerByImage([FromRoute] string image)
        {
            var deserialized = SerializationController<List<ContainerProperties>>.Deserialize("ContainersInformation.json");
            return deserialized.FirstOrDefault(_ => _.Image == image) ?? throw new Exception("Container not found");
        }


        [HttpGet("ImagesInformation")]
        public List<ImageProperties> GetImagesInformation()
        {
            return SerializationController<List<ImageProperties>>.Deserialize("ImagesInformation.json");
        }

        [HttpGet("ImagesInformation/{repo}")]
        public ImageProperties GetImageByRepo([FromRoute] string repo)
        {
            var deserialized = SerializationController<List<ImageProperties>>.Deserialize("ImagesInformation.json");
            return deserialized.FirstOrDefault(_ => _.Repository == repo) ?? throw new Exception("Image not found");
        }
    }
}
