using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contacts
{
    public interface IUserCommentService
    {
        bool Create(string userName, string email, string comment);

        List<UserComment> GetAllComments();
    }
}
