public class RegisterDTO
{
    public string FirstName{get;set;}=string.Empty;
    public string LastName{get;set;}=string.Empty;
    public string Email{get;set;}=null!;
    public string Password{get;set;}=null!;
    public DateTime BirthDate{get;set;}
}