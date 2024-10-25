namespace ManuelMap;

public readonly record struct StudentReadInfo(
    int Id,
    string FullName,
    int Age,
    string Email);
    
    
public readonly record struct StudentCreateInfo(
    string FullName,
    int Age,
    string Email);
    
    
public readonly record struct StudentUpdateInfo(
    int Id,
    string FullName,
    int Age,
    string Email);