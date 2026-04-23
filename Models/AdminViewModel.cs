using SmartLostAndFound.Models;

namespace SmartLostandFoundSystem.Models
{
    public class AdminViewModel
    {
        public int TotalUser { get; set; }
        public int ActiveUser { get; set; }

        public int TotalLostItem { get; set; }
        public int TotalFoundItem { get; set; }
        public List<Item> Items { get; set; }
    }
}