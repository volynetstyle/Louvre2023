using Microsoft.AspNetCore.Identity;

namespace Museum.App.Services.Interfaces.Repositories
{
    internal interface IUserRepository<TUser> : IUserStore<TUser>,
                                                IUserEmailStore<TUser>,
                                                IUserPhoneNumberStore<TUser>,
                                                IUserTwoFactorStore<TUser>,
                                                IUserPasswordStore<TUser>,
                                                IUserRoleStore<TUser>
        where TUser : class
    {
       
    }
}
