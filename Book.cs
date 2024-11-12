using System.Text.Json.Serialization;

namespace LibraryManagmentAdnvanced
{
    public class Book
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("author")]
        public string  Author { get; set; }
        [JsonPropertyName("publishyear")]
        public int PublishYear { get; set; }
        [JsonPropertyName("genre")]
        public string Genre { get; set; }
        [JsonPropertyName("isbn")]
        public int Isbn { get; set; }
        [JsonPropertyName("review")]
        public double Review { get; set; }


        public Book(string title, string author, string genre, int publishYear, int isbn, double review = 0.0)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublishYear = publishYear;
            Isbn = isbn;
            Review = review;
        }

    }
}
