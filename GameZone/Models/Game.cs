namespace GameZone.Models
{
    public class Game 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
    }
}
