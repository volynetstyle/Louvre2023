using Microsoft.AspNetCore.Identity;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IUserRepository<TUser> : IUserStore<TUser>,
                                             IUserEmailStore<TUser>,
                                             IUserPhoneNumberStore<TUser>,
                                             IUserTwoFactorStore<TUser>,
                                             IUserPasswordStore<TUser>,
                                             IUserRoleStore<TUser>,
                                             IUserAuthenticatorKeyStore<TUser>
      where TUser : class
    {
        // Additional custom methods or properties specific to your repository can be added here.
    }
}
