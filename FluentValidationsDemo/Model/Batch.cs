using FluentValidation;
using FluentValidationsDemo.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FluentValidationsDemo.Model
{
    public class Batch
    {
        [JsonIgnore]
        [Key]
        public Guid Id { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public List<ReadUsers> ReadUsers { get; set; }
        public List<ReadGroups> ReadGroups { get; set; }
        public List<Model.Attributes> Attribute { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Files> Files { get; set; }
    }
    public class BatchValidator: AbstractValidator<Batch>
    {
        public BatchValidator()
        {
            RuleFor(x => x.BusinessUnit.Description).NotNull().NotEmpty()
            .WithMessage("Description is mandatory")
            .MinimumLength(4)
            .WithMessage("Description is needs at least 4 characters");


            //RuleForEach(p => p.Attributes).ChildRules(child =>
            //{
            //    child.RuleFor(x => x.key).NotEmpty().WithMessage("required").NotNull();

            //});




            //RuleForEach(p => p.Attribute).ChildRules(child =>
            //{
            //    child.RuleFor(x => x.value).NotEmpty().WithMessage("required").NotNull();



            //});


            RuleFor(x=> x.ExpiryDate).NotEmpty().WithMessage("required").NotNull();

          


            RuleForEach(p => p.ReadUsers).ChildRules(child =>
            {
                child.RuleFor(x => x.UserName).NotEmpty().WithMessage("required").NotNull();

            });




            RuleForEach(p => p.ReadGroups).ChildRules(child =>
            {
                child.RuleFor(x => x.GroupName).NotEmpty().WithMessage("required").NotNull();
               
            });




            RuleForEach(p => p.Files).ChildRules(child =>
            {
                child.RuleFor(x => x.filename).NotEmpty().WithMessage("FileName is needs at least 7 characters").NotNull();
               
            });



            RuleForEach(p => p.Files).ChildRules(child =>
            {
                child.RuleFor(x => x.fileSize).NotEmpty().WithMessage("File size is larger than allowed").NotNull().LessThanOrEqualTo(100);

            });



            RuleForEach(p => p.Files).ChildRules(child =>
            {
                child.RuleFor(x => x.mimeType).NotEmpty().WithMessage("MimeType is needs at least 3 characters").NotNull();

            });



            RuleForEach(p => p.Files).ChildRules(child =>
            {
                child.RuleFor(x => x.hash).NotEmpty().WithMessage("Hash is needs at least 5 characters").NotNull();
            });
        }
    }
}
