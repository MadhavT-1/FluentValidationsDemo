using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class BusinessUnit
    {
        [JsonIgnore]
        [ForeignKey("Id")]
        public Guid Id { get; set; }
        public string  Description { get; set; }
    }
}
