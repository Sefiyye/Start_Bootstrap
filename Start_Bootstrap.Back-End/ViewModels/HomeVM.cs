using Start_Bootstrap.Back_End.Models;
using System.Collections.Generic;

namespace Start_Bootstrap.Back_End.ViewModels
{
    public class HomeVM
    {
        public List<Card> Cards  { get; set; }
        public MainPart MainParts { get; set; }
        public About Abouts { get; set; }
        public Setting Settings { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
