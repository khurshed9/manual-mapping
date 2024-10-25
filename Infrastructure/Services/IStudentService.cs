using ManuelMap.Entities;
using ManuelMap.Filters;
using ManuelMap.Response;

namespace ManuelMap.Services;

public interface IStudentService
{
    PaginationResponse<IEnumerable<StudentReadInfo>> GetStudents(StudentFilter filter);
    StudentReadInfo? GetStudentById(int id);
    bool CreateStudent(StudentCreateInfo createInfo);
    bool UpdateStudent(StudentUpdateInfo updateInfo);
    bool DeleteStudent(int id);
}