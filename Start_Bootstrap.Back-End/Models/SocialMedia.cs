namespace Start_Bootstrap.Back_End.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}
