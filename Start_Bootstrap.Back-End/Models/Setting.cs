using System.Collections.Generic;

namespace Start_Bootstrap.Back_End.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        public string CardLogo { get; set; }
        public string Link { get; set; }
        public string FacebookIcon { get; set; }
        public string TwitterIcon { get; set; }
        public string LinkedinIcon { get; set; }
        public string BasketIcon { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
