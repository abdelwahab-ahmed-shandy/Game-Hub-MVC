namespace GameZone.Models
{
    public class Device 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}
