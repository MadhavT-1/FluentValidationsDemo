using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class ReadUsers
    {
        [JsonIgnore]
        [ForeignKey("Id")]
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
