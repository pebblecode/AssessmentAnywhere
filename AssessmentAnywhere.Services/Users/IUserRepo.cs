namespace AssessmentAnywhere.Services.Users
{
    public interface IUserRepo
    {
        IUser Create(string username, string password);

        bool Exists(string username);

        IUser Open(string username);

        IUser OpenCurrentUser();
    }
}