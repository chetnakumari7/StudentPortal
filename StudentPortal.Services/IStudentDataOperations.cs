using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortal.Services
{
    public interface IStudentDataOperations
    {
        Task<Student> Add(AddStudentViewModel viewmodel);
        Task<Student> Edit(Guid id);
        Task<Student> Edit(Student student); // For updating an existing student
        Task<List<Student>> List();
        Task<Student> Delete(Guid id); // Use Guid for delete
    }
}
