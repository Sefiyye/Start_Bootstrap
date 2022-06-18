using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Start_Bootstrap.Back_End.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
