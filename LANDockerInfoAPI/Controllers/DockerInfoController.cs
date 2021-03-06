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
            try
            {
                var deserialized = SerializationController<List<ContainerProperties>>.Deserialize("ContainersInformation.json");
                return deserialized.FirstOrDefault(_ => _.Image == image);
            }catch(Exception ex)
            {
                return null;
            }
        }


        [HttpGet("ImagesInformation")]
        public List<ImageProperties> GetImagesInformation()
        {
            return SerializationController<List<ImageProperties>>.Deserialize("ImagesInformation.json");
        }

        [HttpGet("ImagesInformation/{repo}")]
        public ImageProperties GetImageByRepo([FromRoute] string repo)
        {
            try
            {
                var deserialized = SerializationController<List<ImageProperties>>.Deserialize("ImagesInformation.json");
                return deserialized.FirstOrDefault(_ => _.Repository == repo);
            }catch(Exception ex)
            {
                return null;
            }
}
    }
}
