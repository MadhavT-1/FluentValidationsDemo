using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class FileAttributes
    {
        [JsonIgnore]
        [ForeignKey("Id")]
        public Guid Id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
}
