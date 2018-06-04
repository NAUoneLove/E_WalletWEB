using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Mvc;
using E_Wallet.BLL.Services;
using E_Wallet.BLL.Interfaces;

namespace E_Wallet.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IAccountService>().To<AccountService>();
        }
    }
}