
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryManagmentAdnvanced
{
    public class MyLittleDb
    {
        [JsonPropertyName("books")]
        public List<Book> Books { get; set; } = new List<Book>();

        [JsonPropertyName("authors")]
        public List<Author?> Authors { get; set; } = new List<Author?>();

        // Statisk metod för att ladda data från fil
        public static MyLittleDb LoadData(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<MyLittleDb>(jsonData) ?? new MyLittleDb();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return new MyLittleDb(); // Returnera en tom instans vid fel
            }
        }

        // Statisk metod för att spara data till fil

        public static void SaveDataIfNotNull(MyLittleDb? myLittleDb, string filePath)
        {
            if (myLittleDb != null)
            {
                try
                {
                    string updatedJsonData = JsonSerializer.Serialize(myLittleDb, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, updatedJsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving file: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Failed to save data as no valid data was loaded.");
            }
        }
    }


    }

