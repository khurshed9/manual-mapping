using ManuelMap.Entities;

namespace ManuelMap.Mappers;

public static class StudentMapperExtension
{

    public static StudentReadInfo CourseToReadInfo(this Student student)
    {
        return new StudentReadInfo()
        {
            Id = student.Id,
            FullName = student.FullName,
            Age = student.Age,
        };
    }

    public static Student UpdateInfoToStudent(this Student student, StudentUpdateInfo updateInfo)
    {
        student.Id = updateInfo.Id;
        student.FullName = updateInfo.FullName;
        student.Age = updateInfo.Age;
        student.Email = updateInfo.Email;
        student.Version += 1;
        student.UpdatedAt = DateTime.UtcNow;
        return student;
    }

    public static Student CreateInfoToStudent(this StudentCreateInfo studentCreateInfo)
    {
        return new Student
        {
            FullName = studentCreateInfo.FullName,
            Age = studentCreateInfo.Age,
            Email = studentCreateInfo.Email,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static Student DeleteInfoToStudent(this Student student)
    {
        student.IsDeleted = true;
        student.DeletedAt = DateTime.UtcNow;
        student.Version += 1;
        student.UpdatedAt = DateTime.UtcNow;
        return student;
    }
}