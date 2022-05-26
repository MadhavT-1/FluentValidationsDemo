using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class Files
    {
        [JsonIgnore]
        [ForeignKey("Id")]
        public Guid Id { get; set; }
        public string filename { get; set; }
        public int fileSize { get; set; }
        public string mimeType { get; set; }
        public string hash { get; set; }

        public List<FileAttributes> FileAttributes{ get; set; }
    }
}
