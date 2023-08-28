using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Common;

public class ResultDto : IDto
{
    public ResultDto(string message)
    {
        this.message = message;
    }

    public ResultDto(bool success,string message)
    {
        this.message= message;
        this.success = success;
    }
    public ResultDto(int statusCode, bool success, string message)
    {
        this.statusCode = statusCode;
        this.success = success;
        this.message = message;
    }
    public ResultDto(int statusCode,string message)
    {
        this.statusCode=statusCode;
        this.message    =(string)message;
    }

    public int? statusCode { get; init; }
    public bool success { get; init; } = true;
    public string message { get; init; } = "Successfully";


        
        
        
}

