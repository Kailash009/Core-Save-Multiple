using CoreSaveMultiple.Models;
using CoreSaveMultiple.Repo.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace CoreSaveMultiple.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudent _stu;
        public StudentsController(IStudent stu)
        {
            _stu = stu;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _stu.GetAllStudentsAsync();
            return View(students);
        }

        //Model Binding Limitations:-
        //The default model binding in ASP.NET Core might not always handle complex types or nested collections from form data as expected.
        //For advanced scenarios, you might need to use different approaches Like:-
        // a) IFormCollection. [Key-Value Pair]
        // b) Custom Model Binder. [IModelBinder]

        [HttpPost]
        public async Task<IActionResult> updateStudents(IFormCollection form)
        {
            var Students = new List<Student>();
            foreach (var key in form.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {form[key]}");
                if (key.StartsWith("Students["))
                {
                    var parts = key.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 3) continue; // Ensure the key is in the expected format
                    var index = int.Parse(parts[1]);
                    string[] property = parts[2].Split(new[] { '.' });
                    var data = property[1];

                    // Initialize product if not already done
                    if (Students.Count <= index)
                    {
                        Students.Add(new Student());
                    }
                    var student = Students[index-1];
                    switch (data)
                    {
                        case "id":
                            student.id = int.Parse(form[key]);
                            break;
                        case "name":
                            student.name = form[key];
                            break;
                        case "age":
                            student.age = int.Parse(form[key]);
                            break;
                        case "address":
                            student.address = form[key];
                            break;
                        case "mobileno":
                            student.mobileno = form[key];
                            break;
                        case "city":
                            student.city = form[key];
                            break;
                        case "fees":
                            student.fees = decimal.Parse(form[key]);
                            break;
                    }
                }
            }
            await _stu.updateStudentAsync(Students);
            return RedirectToAction(nameof(Index));
        }

    }
}
