

public interface IJwtTokenGenerator
{
    string Generate(User user, IList<string> roles);
}