using Krunal_Final_Test_Repository.Repository;
using Krunal_Final_Test_Repository.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Krunal_Final_Test
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUser, UserServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}