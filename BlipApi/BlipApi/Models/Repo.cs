namespace BlipApi.Models
{
    public class Repo
    {
        public int Id { get; set; }
        public string? Full_name { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public string? Created_at { get; set; }
        public Owner? Owner { get; set; }
    }
}
