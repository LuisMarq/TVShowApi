namespace TVShowApi.Entities
{
    public class TVShow
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
