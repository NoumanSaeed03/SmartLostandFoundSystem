using System;
using System.ComponentModel.DataAnnotations;

namespace SmartLostAndFound.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public string Color { get; set; } // Optional

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please specify if the item is lost or found")]
        public bool IsLost { get; set; }
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Contact information is required")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
