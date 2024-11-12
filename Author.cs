using System.Text.Json.Serialization;


namespace LibraryManagmentAdnvanced
{
    public class Author 
    {
        // properties
        [JsonPropertyName("name")]
         public string Name {  get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }

        public Author(string name, string country)
        {
            Name = name;
            Country = country;
        }



    }


}
