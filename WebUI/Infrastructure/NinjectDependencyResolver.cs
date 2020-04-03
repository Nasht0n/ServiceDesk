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
            kernel.Bind<IAccountPermissionLogic>().To<AccountPermissionLogic>();

            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IAccountLogic>().To<AccountLogic>();

            kernel.Bind<IBranchRepository>().To<BranchRepository>();
            kernel.Bind<IBranchLogic>().To<BranchLogic>();

            kernel.Bind<ICampusRepository>().To<CampusRepository>();
            kernel.Bind<ICampusLogic>().To<CampusLogic>();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryLogic>().To<CategoryLogic>();

            kernel.Bind<IComponentRepository>().To<ComponentRepository>();
            kernel.Bind<IComponentLogic>().To<ComponentLogic>();

            kernel.Bind<IConsumableRepository>().To<ConsumableRepository>();
            kernel.Bind<IConsumableLogic>().To<ConsumableLogic>();

            kernel.Bind<IEquipmentRepository>().To<EquipmentRepository>();
            kernel.Bind<IEquipmentLogic>().To<EquipmentLogic>();

            kernel.Bind<IEquipmentTypeRepository>().To<EquipmentTypeRepository>();
            kernel.Bind<IEquipmentTypeLogic>().To<EquipmentTypeLogic>();

            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IEmployeeLogic>().To<EmployeeLogic>();
            
            kernel.Bind<IExecutorGroupMembersRepository>().To<ExecutorGroupMembersRepository>();
            kernel.Bind<IExecutorGroupMemberLogic>().To<ExecutorGroupMemberLogic>();

            kernel.Bind<IExecutorGroupRepository>().To<ExecutorGroupRepository>();
            kernel.Bind<IExecutorGroupLogic>().To<ExecutorGroupLogic>();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();

            kernel.Bind<IServiceRepository>().To<ServiceRepository>();
            kernel.Bind<IServiceLogic>().To<ServiceLogic>();

            kernel.Bind<IServicesExecutorGroupsRepository>().To<ServicesExecutorGroupsRepository>();
            kernel.Bind<IServicesExecutorGroupsLogic>().To<ServicesExecutorGroupsLogic>();

            kernel.Bind<IServicesApproversRepository>().To<ServicesApproversRepository>();
            kernel.Bind<IServicesApproversLogic>().To<ServicesApproversLogic>();

            kernel.Bind<ISubdivisionExecutorsRepository>().To<SubdivisionExecutorsRepository>();
            kernel.Bind<ISubdivisionExecutorLogic>().To<SubdivisionExecutorLogic>();

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