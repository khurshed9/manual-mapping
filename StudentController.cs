using ManuelMap.Filters;
using ManuelMap.Response;
using ManuelMap.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManuelMap;

[ApiController]
[Route("api/students")]

public sealed class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents([FromQuery] StudentFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<StudentReadInfo>>>.Success(null, studentService.GetStudents(filter)));

    [HttpGet("get/{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        StudentReadInfo? info = studentService.GetStudentById(id);
        return info != null
            ? Ok(ApiResponse<StudentReadInfo?>.Success(null, info)) 
            : NotFound(ApiResponse<StudentReadInfo?>.Fail(null, info));
    }

    [HttpPost]
    public IActionResult CreateStudent(StudentCreateInfo createInfo)
    {
        bool res = studentService.CreateStudent(createInfo);
        return res != null
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }

    [HttpPut]
    public IActionResult UpdateStudent(StudentUpdateInfo updateInfo)
    {
        bool res = studentService.UpdateStudent(updateInfo);
        return res != null
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }

    [HttpDelete("delete/{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        bool res = studentService.DeleteStudent(id);
        return res!= null
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}