using Communal1.ViewModels;

namespace Communal1.Services
{
    public interface ISecurityService
    {
        void SaveUserToDB(RegisterViewModel model);
        
        bool IsValidUser(LogonViewModel model);
    }
}