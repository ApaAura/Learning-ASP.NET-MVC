using WebAppFirst.Models;
namespace WebAppFirst.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public DateTime Added { get; set; }
        public DateTime Released { get; set; }
        public int NumberInStock { get; set; }
    }
}
