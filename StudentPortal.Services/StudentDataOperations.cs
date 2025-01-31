
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

using StudentPortal.Web.Models;

using StudentPortal.Web.data;

namespace StudentPortal.Services
{
    public class StudentDataOperations : IStudentDataOperations
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentDataOperations(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // POST method to add a new student
        public async Task<Student> Add(AddStudentViewModel viewmodel)
        {
            var student = new Student
            {
                Email = viewmodel.Email,
                Phone = viewmodel.Phone,
                Subscribed = viewmodel.Subscribed
            };

            await _applicationDbContext.Students.AddAsync(student);
            await _applicationDbContext.SaveChangesAsync();

            return student;
        }

        // GET method to list all students
        public async Task<List<Student>> List()
        {
            return await _applicationDbContext.Students.ToListAsync();
        }

        // GET method to fetch a student by ID
        public async Task<Student> Edit(Guid id)
        {
            var student = await _applicationDbContext.Students.FindAsync(id);
            return student;
        }

        // POST method to update an existing student
        public async Task<Student> Edit(Student student)
        {
            var existingStudent = await _applicationDbContext.Students.FindAsync(student.Id);

            if (existingStudent != null)
            {
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                existingStudent.Subscribed = student.Subscribed;

                _applicationDbContext.Students.Update(existingStudent);  // Use Update instead of AddAsync
                await _applicationDbContext.SaveChangesAsync();
            }

            return existingStudent;
        }

        // DELETE method to delete a student by ID
        public async Task<Student> Delete(Guid id)
        {
            var student = await _applicationDbContext.Students.FindAsync(id);
            if (student != null)
            {
                _applicationDbContext.Students.Remove(student);
                await _applicationDbContext.SaveChangesAsync();
            }
            return student;
        }
    }
}
