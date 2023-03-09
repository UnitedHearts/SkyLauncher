namespace SkyLauncher;
public class RegisterResponse : Error
{
    public RegisterResponse()
    {
    }

    public RegisterResponse(Error error) : base(error.Message, error.Id.Value)
    {
    }
}