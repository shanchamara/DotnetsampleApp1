using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamplePRojectOverleap.DatabaseConnection;
using System.Formats.Asn1;

namespace SamplePRojectOverleap.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public IActionResult GetClass()
        {

            using (var con = new AppDbContext())
            {
                var model = con.TblClasses.ToList();
                return Ok(model);
            };
        }
        [HttpPost]
        public IActionResult CreateData(TblClass ClassData)
        {
            using (var con = new AppDbContext())
            {
                TblClass tblClass = new()
                {
                    Name = ClassData.Name,
                    Greade = ClassData.Greade,
                };
                con.TblClasses.Add(tblClass);
                con.SaveChanges();
                return Ok("Succesfully insert data");
            };
        }

        [HttpPut]
        public IActionResult Update(TblClass tblClass)
        {
            using (var con = new AppDbContext())
            {
                var updateValue = con.TblClasses.Where(s => s.Id == tblClass.Id).SingleOrDefault();
                updateValue.Name = tblClass.Name;
                updateValue.Greade = tblClass.Greade;

                con.SaveChanges();
            };
            return Ok("Succesfully Update data");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using(var con = new AppDbContext())
            {
                var updateValue = con.TblClasses.Where(s => s.Id == id).SingleOrDefault();

                con.Remove(updateValue);
                con.SaveChanges();


            };

            return Ok("Succesfully Delete data");
        }
    }
}
