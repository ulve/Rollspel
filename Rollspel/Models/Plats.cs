using MongoDB.Bson;

namespace Rollspel.Models
{
    public class Plats
    {
        public ObjectId Id { get; set; }
        public string Titel { get; set; }
        public string Kommentar { get; set; }
        public string Historik { get; set; }
    }
}