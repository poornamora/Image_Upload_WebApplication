using Practice_WebApp_MVC_Venkat_TT.IRepositories;
using Practice_WebApp_MVC_Venkat_TT.Models;
using Practice_WebApp_MVC_Venkat_TT.ViewModels;

namespace Multiple_Images_Upload_WebApp.IRepositories
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hoisting;
        public SqlEmployeeRepository(AppDbContext context, IWebHostEnvironment hoisting)
        {
            _context = context;
            _hoisting = hoisting;
        }


        public int AddEmployee(EmployeeViewModel model)
        {
            try
            {
                string filepath = "";
                string filename = "";
                if (model.Photos != null && model.Photos.Count > 0)
                {
                    foreach (IFormFile photo in model.Photos)
                    {
                        string uploadFile = Path.Combine(_hoisting.WebRootPath, "Images");

                        // Create the directory if it doesn't exist
                        if (!Directory.Exists(uploadFile))
                        {
                            Directory.CreateDirectory(uploadFile);
                        }


                        filename = Path.GetFileName(photo.FileName);
                        filepath = Path.Combine(uploadFile, filename);

                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            photo.CopyTo(fileStream);
                        }

                        var ImageEntity = new Employee
                        {
                            PhotoName = filename,
                            PhotoPath = filepath
                        };

                    }
                }

                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = filepath,
                    PhotoName = filename
                };


                _context.EmployeeTable.Add(newEmployee);
                var Isuccess = _context.SaveChanges();
                return Isuccess;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteEmployee(int id)
        {
            try
            {
                var employeedetails = _context.EmployeeTable.FirstOrDefault(i => i.Id == id);
                if (employeedetails != null)
                {
                    employeedetails.IsDeleted = false;
                    var IsDeleted = _context.SaveChanges();
                    return IsDeleted;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee EmployeeDetailById(int? id)
        {

            var ViewDetails = GetEmployeeDetails().FirstOrDefault(i => i.Id == id);
            if (ViewDetails != null)
            {
                return ViewDetails;
            }
            return null;
        }

        public IEnumerable<Employee> GetEmployeeDetails()
        {
            try
            {
                IEnumerable<Employee> employeelist = _context.EmployeeTable.Where(IDdetails => IDdetails.IsDeleted == true);
                _context.SaveChanges();
                return employeelist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmployee(EmployeeEditViewModel model)
        {
            try
            {
                string filename = "";
                string filepath = "";
                if (model.Photos != null)
                {
                    if (model.existingpath != null)
                    {
                        filepath = Path.Combine(_hoisting.ContentRootPath, "Images", model.existingpath);
                        File.Delete(model.existingpath);
                    }

                    if (model.Photos != null && model.Photos.Count > 0)
                    {
                        foreach (IFormFile photo in model.Photos)
                        {
                            string uploadFile = Path.Combine(_hoisting.WebRootPath, "Images");

                            // Create the directory if it doesn't exist
                            if (!Directory.Exists(uploadFile))
                            {
                                Directory.CreateDirectory(uploadFile);
                            }

                            filename = Path.GetFileName(photo.FileName);
                            filepath = Path.Combine(uploadFile, filename);

                            using (var fileStream = new FileStream(filepath, FileMode.Create))
                            {
                                photo.CopyTo(fileStream);
                            }
                        }
                    }
                }

                Employee updatedEmployee = new Employee()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = filepath,
                    PhotoName = filename,
                };
                _context.Update(updatedEmployee);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
