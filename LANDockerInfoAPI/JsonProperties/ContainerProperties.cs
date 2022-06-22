namespace LANDockerInfoAPI.JsonProperties
{
    public class ContainerProperties
    {
        public string? ID { get; set; }
        public string? Image { get; set; }
        public string? Size { get; set; }
        public string? State { get; set; }
        public string? Status { get; set; }
        public string? CreatedAt { get; set; }
        public string? RunningFor { get; set; }
    }
}
