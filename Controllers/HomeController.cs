using Microsoft.AspNetCore.Mvc;
using Multiple_Images_Upload_WebApp.IRepositories;
using Practice_WebApp_MVC_Venkat_TT.IRepositories;
using Practice_WebApp_MVC_Venkat_TT.Models;
using Practice_WebApp_MVC_Venkat_TT.ViewModels;
using System.Diagnostics;
using System.IO;

namespace Practice_WebApp_MVC_Venkat_TT.Controllers
{
    [Route("[Controller]/[Action]")]
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment _hoisting;
        private readonly SqlEmployeeRepository _sqlRepostoryclass;
        //private readonly IHostEnvironment _hoisting;


        public HomeController(IWebHostEnvironment hoisting, SqlEmployeeRepository sqlRepostoryclass)
        {
            //_repository = employeeCodeRepository;
            _hoisting = hoisting;
            _sqlRepostoryclass = sqlRepostoryclass;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<Employee> empdetails = _sqlRepostoryclass.GetEmployeeDetails();
                return View(empdetails);
            }
            catch(Exception)
            {
                throw;
            }
        }



        [Route("{id}")]
        public IActionResult EmployeeDetailById(int? id)
        {
            try
            {
                
                var empdetails = _sqlRepostoryclass.EmployeeDetailById(id);

                if (empdetails == null)
                {
                    Response.StatusCode = 404;
                    return View("EmployeeNotFound", id.Value);
                }
                return View(empdetails);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult AddEmployeeDetails()
        {
            try
            {
                return View();
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddEmployeeDetails(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Isvalid = _sqlRepostoryclass.AddEmployee(model);
                    if (Isvalid>=1)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                return View(ModelState);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Employee employee = _sqlRepostoryclass.EmployeeDetailById(id);
                EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    existingpath = employee.PhotoPath
                };
                return View(employeeEditViewModel);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _sqlRepostoryclass.UpdateEmployee(model);
                    return RedirectToAction("Index", "Home");
                }
                return View(ModelState);
            }
            catch(Exception)
            {
                throw;
            }   
        }

        public IActionResult DeleteDetails(int id)
        {
            try
            {
                var Isvalid=_sqlRepostoryclass.DeleteEmployee(id);

                if(Isvalid>=1)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(ModelState);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}