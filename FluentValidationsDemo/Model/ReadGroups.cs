using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class ReadGroups
    {
        [JsonIgnore]
        [ForeignKey("Id")]
        public Guid Id { get; set; }
        public string GroupName { get; set; }
    }
}
