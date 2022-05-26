using FluentValidationsDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        MyDbContext dbContext = new MyDbContext();
        [HttpPost]
        public ActionResult Create(Batch batch)
        {
            //CustomValidations validations = new CustomValidations();
            //if (validations.validData())
            //{

            if (ModelState.IsValid)
            {
                dbContext.Batches.Add(batch);
                dbContext.SaveChanges();
                return Ok(new { batchId = batch.Id });
            }
            else
            {
                var obj = @"{
                    'correlationId':'String'
                }";

                return BadRequest(obj);
            }


            //}
            //else
            //{
            //    return BadRequest();
            //}            
        }

        [HttpGet("{id}")]
        public ActionResult GetOne(Guid id)
        {
            // var batch = dbContext.Batches.Find(id);
            // dbContext.BusinessUnits.Find(id);
            // dbContext.ReadUsers.Find(id);
            //dbContext.ReadGroups.Find(id);
            // dbContext.Attributes.Find(id);
            // dbContext.FileAttributes.Find(id);
            // dbContext.Files.Find(id);
            var batch = dbContext.Batches.Include(nameof(BusinessUnit))
                                         .Include(nameof(ReadUsers))
                                         .Include(nameof(ReadGroups))

                                         .Include(nameof(Files))
                                         .FirstOrDefault(x => x.Id == id);


            return Ok(batch);
        }
    }
}