using Microsoft.AspNetCore.Mvc;
using SamplePRojectOverleap.DatabaseConnection;
using SamplePRojectOverleap.Models;

namespace SamplePRojectOverleap.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new EmployeeListViewModel();
            using (var con = new AppDbContext())
            {
                model.TblEmployees = con.TblEmployees.ToList();
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var con = new AppDbContext())
                    {
                        TblEmployee tblEmployee = new()
                        {
                            Name = model.Name,
                            WorkingDays = model.Workingdays
                        };
                        con.TblEmployees.Add(tblEmployee);
                        con.SaveChanges();
                    };
                    return RedirectToAction("Index", "Employee");
                }


            }
            catch (Exception)
            {

                throw;
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var GetEmplooyeeData = new TblEmployee();
            using (var con = new AppDbContext())
            {
                GetEmplooyeeData = con.TblEmployees.Where(d => d.ID.Equals(id)).SingleOrDefault();
            };
            var model = new EditEmployeeViewModel()
            {
                Id = id,
                Name = GetEmplooyeeData.Name,
                Workingdays = GetEmplooyeeData.WorkingDays,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            using (var con = new AppDbContext())
            {
                var Getdata = con.TblEmployees.Where(d => d.ID.Equals(model.Id)).SingleOrDefault();
                Getdata.Name = model.Name;
                Getdata.WorkingDays = model.Workingdays;

                con.SaveChanges();
            };
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Delete(int id)
        {
            using (var con = new AppDbContext())
            {
                var Getdata = con.TblEmployees.Where(d => d.ID.Equals(id)).SingleOrDefault();
                con.Remove(Getdata);
                con.SaveChanges();

            };

            return RedirectToAction("Index", "Employee");

        }
    }
}
