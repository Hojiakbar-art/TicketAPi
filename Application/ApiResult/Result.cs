public class Result<T>
{
    public bool IsSuccess{get;set;}
    public T? Data{get;set;}
    public string ErrorMessage{get;set;}=string.Empty;
    public ErrorType? ErrorType{get;set;}
    protected Result(T data)
    {
        IsSuccess=true;
        Data=data;
    }
    protected Result(string errorMessage, ErrorType errortype)
    {
        IsSuccess=false;
        ErrorMessage=errorMessage;
        ErrorType=errortype;
    }
    public static Result<T> Success(T data)
    {
        return new Result<T>(data);
    }
    public static Result<T> Fail(string errorMessage, ErrorType errorType)
    {
        return new Result<T>(errorMessage, errorType);
    }
}