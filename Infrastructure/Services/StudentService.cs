using ManuelMap.Entities;
using ManuelMap.Filters;
using ManuelMap.Mappers;
using ManuelMap.Response;

namespace ManuelMap.Services;

public class StudentService(StudentDBContext context) : IStudentService
{
    public PaginationResponse<IEnumerable<StudentReadInfo>> GetStudents(StudentFilter filter)
    {
        IQueryable<Student> students = context.Students;
        if (filter.FullName != null)
            students = context.Students.Where(x => x.IsDeleted == false && x.FullName.ToLower() == filter.FullName.ToLower());
        if (filter.Age > 0)
            students = context.Students.Where(x => x.IsDeleted == false && x.Age == filter.Age);

        IQueryable<StudentReadInfo> result = students.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x=>x.CourseToReadInfo());

        int totalRecords = context.Students.Count();

        return PaginationResponse<IEnumerable<StudentReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords,
            result);
    }

    public StudentReadInfo? GetStudentById(int id)
    {
        StudentReadInfo? studentReadInfo = context.Students.Where(x => x.IsDeleted == false && x.Id == id)
            .Select(x => x.CourseToReadInfo()).FirstOrDefault();
        
        return studentReadInfo ?? null;
    }

    public bool CreateStudent(StudentCreateInfo createInfo)
    {
        bool existingStudent = context.Students.Any(x => x.Email.ToLower() == createInfo.Email.ToLower());
        if (existingStudent) return false;

        context.Students.Add(createInfo.CreateInfoToStudent());
        return context.SaveChanges() > 0;
    }

    public bool UpdateStudent(StudentUpdateInfo updateInfo)
    {
        Student? student = context.Students.FirstOrDefault(x => x.IsDeleted == false && x.Id == updateInfo.Id);
        if (student == null) return false;
        context.Students.Update(student.UpdateInfoToStudent(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteStudent(int id)
    {
        Student? student = context.Students.FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
        if (student == null) return false;
        context.Students.Remove(student.DeleteInfoToStudent());
        return context.SaveChanges() > 0;
    }
}