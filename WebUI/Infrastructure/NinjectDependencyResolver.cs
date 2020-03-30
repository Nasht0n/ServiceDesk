using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using Ninject;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IAccountPermissionRepository>().To<AccountPermissionRepository>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IAccountLogic>().To<AccountLogic>();

            kernel.Bind<IBranchRepository>().To<BranchRepository>();
            kernel.Bind<IBranchLogic>().To<BranchLogic>();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryLogic>().To<CategoryLogic>();

            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IEmployeeLogic>().To<EmployeeLogic>();
            kernel.Bind<IExecutorGroupMembersRepository>().To<ExecutorGroupMembersRepository>();
            kernel.Bind<IExecutorGroupRepository>().To<ExecutorGroupRepository>();
            kernel.Bind<IExecutorGroupLogic>().To<ExecutorGroupLogic>();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();

            kernel.Bind<IServiceRepository>().To<ServiceRepository>();
            kernel.Bind<IServiceLogic>().To<ServiceLogic>();
            kernel.Bind<IServicesApproversRepository>().To<ServicesApproversRepository>();

            kernel.Bind<ISubdivisionExecutorsRepository>().To<SubdivisionExecutorsRepository>();

            kernel.Bind<ISubdivisionRepository>().To<SubdivisionRepository>();
            kernel.Bind<ISubdivisionLogic>().To<SubdivisionLogic>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}