using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using BusinessLogic.Abstract.Branches.IT.Equipments;
using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using BusinessLogic.Abstract.Branches.IT.Networks;
using BusinessLogic.Abstract.Branches.IT.Networks.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Networks.Requests;
using BusinessLogic.Concrete;
using BusinessLogic.Concrete.Branches.IT.Accounts.Attachments;
using BusinessLogic.Concrete.Branches.IT.Accounts.LifeCycles;
using BusinessLogic.Concrete.Branches.IT.Accounts.Requests;
using BusinessLogic.Concrete.Branches.IT.Equipments;
using BusinessLogic.Concrete.Branches.IT.Equipments.LifeCycles;
using BusinessLogic.Concrete.Branches.IT.Equipments.Requests;
using BusinessLogic.Concrete.Branches.IT.Networks;
using BusinessLogic.Concrete.Branches.IT.Networks.LifeCycles;
using BusinessLogic.Concrete.Branches.IT.Networks.Requests;
using Ninject;
using Repository.Abstract;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using Repository.Abstract.Branches.IT.Accounts.Requests;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using Repository.Abstract.Branches.IT.Communication.Requests;
using Repository.Abstract.Branches.IT.Email.LifeCycles;
using Repository.Abstract.Branches.IT.Email.Requests;
using Repository.Abstract.Branches.IT.Equipments;
using Repository.Abstract.Branches.IT.Equipments.LifeCycles;
using Repository.Abstract.Branches.IT.Equipments.Requests;
using Repository.Abstract.Branches.IT.Network;
using Repository.Abstract.Branches.IT.Network.LifeCycles;
using Repository.Abstract.Branches.IT.Network.Requests;
using Repository.Abstract.Branches.IT.Software.Attachments;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using Repository.Abstract.Branches.IT.Software.Requests;
using Repository.Concrete;
using Repository.Concrete.Branches.IT.Accounts.Attachments;
using Repository.Concrete.Branches.IT.Accounts.LifeCycles;
using Repository.Concrete.Branches.IT.Accounts.Requests;
using Repository.Concrete.Branches.IT.Communication.LifeCycles;
using Repository.Concrete.Branches.IT.Communication.Requests;
using Repository.Concrete.Branches.IT.Email.LifeCycles;
using Repository.Concrete.Branches.IT.Email.Requests;
using Repository.Concrete.Branches.IT.Equipments;
using Repository.Concrete.Branches.IT.Equipments.LifeCycles;
using Repository.Concrete.Branches.IT.Equipments.Requests;
using Repository.Concrete.Branches.IT.Network;
using Repository.Concrete.Branches.IT.Network.LifeCycles;
using Repository.Concrete.Branches.IT.Network.Requests;
using Repository.Concrete.Branches.IT.Software.Attachments;
using Repository.Concrete.Branches.IT.Software.LifeCycles;
using Repository.Concrete.Branches.IT.Software.Requests;
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
            AddRepositoryBindings();
            AddLogicBindings();
        }

        private void AddRepositoryBindings()
        {
            kernel.Bind<IAccountPermissionRepository>().To<AccountPermissionRepository>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IBranchRepository>().To<BranchRepository>();
            kernel.Bind<ICampusRepository>().To<CampusRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IComponentRepository>().To<ComponentRepository>();
            kernel.Bind<IConsumableRepository>().To<ConsumableRepository>();
            kernel.Bind<IEquipmentRepository>().To<EquipmentRepository>();
            kernel.Bind<IEquipmentTypeRepository>().To<EquipmentTypeRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IExecutorGroupMembersRepository>().To<ExecutorGroupMembersRepository>();
            kernel.Bind<IExecutorGroupRepository>().To<ExecutorGroupRepository>();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();
            kernel.Bind<IServiceRepository>().To<ServiceRepository>();
            kernel.Bind<IServicesExecutorGroupsRepository>().To<ServicesExecutorGroupsRepository>();
            kernel.Bind<IServicesApproversRepository>().To<ServicesApproversRepository>();
            kernel.Bind<ISubdivisionExecutorsRepository>().To<SubdivisionExecutorsRepository>();
            kernel.Bind<ISubdivisionRepository>().To<SubdivisionRepository>();
            kernel.Bind<IPriorityRepository>().To<PriorityRepository>();
            kernel.Bind<IInstallationEquipmentsRepository>().To<InstallationEquipmentsRepository>();
            kernel.Bind<IRefillEquipmentsRepository>().To<RefillEquipmentsRepository>();
            kernel.Bind<IRepairEquipmentsRepository>().To<RepairEquipmentsRepository>();
            kernel.Bind<IReplaceComponentsRepository>().To<ReplaceComponentsRepository>();
            kernel.Bind<IReplaceEquipmentsRepository>().To<ReplaceEquipmentsRepository>();
            kernel.Bind<IConnectionEquipmentsRepository>().To<ConnectionEquipmentsRepository>();
            kernel.Bind<IRequestRepository>().To<RequestRepository>();
            kernel.Bind<IRefuelingLimitRepository>().To<RefuelingLimitRepository>();
            kernel.Bind<IAttachmentRepository>().To<AttachmentRepository>();

            AddLifeCyclesRepositoriesBindings();
            AddRequestsRepositoriesBindings();
            AddAttachmentsRepositoriesBindings();            
        }

        private void AddAttachmentsRepositoriesBindings()
        {
            kernel.Bind<IAccountCancellationRequestAttachmentsRepository>().To<AccountCancellationRequestAttachmentsRepository>();
            kernel.Bind<IAccountDisconnectRequestAttachmentsRepository>().To<AccountDisconnectRequestAttachmentsRepository>();
            kernel.Bind<IAccountLossRequestAttachmentsRepository>().To<AccountLossRequestAttachmentsRepository>();
            kernel.Bind<IAccountRegistrationRequestAttachmentsRepository>().To<AccountRegistrationRequestAttachmentsRepository>();

            kernel.Bind<ISoftwareDevelopmentRequestAttachmentsRepository>().To<SoftwareDevelopmentRequestAttachmentsRepository>();
            kernel.Bind<ISoftwareReworkRequestAttachmentsRepository>().To<SoftwareReworkRequestAttachmentsRepository>();
        }

        private void AddRequestsRepositoriesBindings()
        {
            kernel.Bind<IComponentReplaceRequestRepository>().To<ComponentReplaceRequestRepository>();
            kernel.Bind<IEquipmentInstallationRequestRepository>().To<EquipmentInstallationRequestRepository>();
            kernel.Bind<IEquipmentRefillRequestRepository>().To<EquipmentRefillRequestRepository>();
            kernel.Bind<IEquipmentRepairRequestRepository>().To<EquipmentRepairRequestRepository>();
            kernel.Bind<IEquipmentReplaceRequestRepository>().To<EquipmentReplaceRequestRepository>();

            kernel.Bind<IAccountCancellationRequestRepository>().To<AccountCancellationRequestRepository>();
            kernel.Bind<IAccountDisconnectRequestRepository>().To<AccountDisconnectRequestRepository>();
            kernel.Bind<IAccountLossRequestRepository>().To<AccountLossRequestRepository>();
            kernel.Bind<IAccountRegistrationRequestRepository>().To<AccountRegistrationRequestRepository>();

            kernel.Bind<IHoldingPhoneLineRequestRepository>().To<HoldingPhoneLineRequestRepository>();
            kernel.Bind<IPhoneLineRepairRequestRepository>().To<PhoneLineRepairRequestRepository>();
            kernel.Bind<IPhoneNumberAllocationRequestRepository>().To<PhoneNumberAllocationRequestRepository>();
            kernel.Bind<IPhoneRepairRequestRepository>().To<PhoneRepairRequestRepository>();
            kernel.Bind<IVideoCommunicationRequestRepository>().To<VideoCommunicationRequestRepository>();

            kernel.Bind<IEmailRegistrationRequestRepository>().To<EmailRegistrationRequestRepository>();
            kernel.Bind<IEmailSizeIncreaseRequestRepository>().To<EmailSizeIncreaseRequestRepository>();

            kernel.Bind<INetworkConnectionRequestRepository>().To<NetworkConnectionRequestRepository>();

            kernel.Bind<ISoftwareDevelopmentRequestRepository>().To<SoftwareDevelopmentRequestRepository>();
            kernel.Bind<ISoftwareReworkRequestRepository>().To<SoftwareReworkRequestRepository>();
        }

        private void AddLifeCyclesRepositoriesBindings()
        {
            kernel.Bind<IComponentReplaceRequestLifeCycleRepository>().To<ComponentReplaceRequestLifeCycleRepository>();
            kernel.Bind<IEquipmentInstallationRequestLifeCycleRepository>().To<EquipmentInstallationRequestLifeCycleRepository>();
            kernel.Bind<IEquipmentRefillRequestLifeCycleRepository>().To<EquipmentRefillRequestLifeCycleRepository>();
            kernel.Bind<IEquipmentRepairRequestLifeCycleRepository>().To<EquipmentRepairRequestLifeCycleRepository>();
            kernel.Bind<IEquipmentReplaceRequestLifeCycleRepository>().To<EquipmentReplaceRequestLifeCycleRepository>();

            kernel.Bind<IAccountCancellationRequestLifeCycleRepository>().To<AccountCancellationRequestLifeCycleRepository>();
            kernel.Bind<IAccountDisconnectRequestLifeCycleRepository>().To<AccountDisconnectRequestLifeCycleRepository>();
            kernel.Bind<IAccountLossRequestLifeCycleRepository>().To<AccountLossRequestLifeCycleRepository>();
            kernel.Bind<IAccountRegistrationRequestLifeCycleRepository>().To<AccountRegistrationRequestLifeCycleRepository>();

            kernel.Bind<IHoldingPhoneLineRequestLifeCycleRepository>().To<HoldingPhoneLineRequestLifeCycleRepository>();
            kernel.Bind<IPhoneLineRepairRequestLifeCycleRepository>().To<PhoneLineRepairRequestLifeCycleRepository>();
            kernel.Bind<IPhoneNumberAllocationRequestLifeCycleRepository>().To<PhoneNumberAllocationRequestLifeCycleRepository>();
            kernel.Bind<IPhoneRepairRequestLifeCycleRepository>().To<PhoneRepairRequestLifeCycleRepository>();
            kernel.Bind<IVideoCommunicationRequestLifeCycleRepository>().To<VideoCommunicationRequestLifeCycleRepository>();

            kernel.Bind<IEmailRegistrationRequestLifeCycleRepository>().To<EmailRegistrationRequestLifeCycleRepository>();
            kernel.Bind<IEmailSizeIncreaseRequestLifeCycleRepository>().To<EmailSizeIncreaseRequestLifeCycleRepository>();

            kernel.Bind<INetworkConnectionRequestLifeCycleRepository>().To<NetworkConnectionRequestLifeCycleRepository>();

            kernel.Bind<ISoftwareDevelopmentRequestLifeCycleRepository>().To<SoftwareDevelopmentRequestLifeCycleRepository>();
            kernel.Bind<ISoftwareReworkRequestLifeCycleRepository>().To<SoftwareReworkRequestLifeCycleRepository>();
        }

        private void AddLogicBindings()
        {
            kernel.Bind<IAccountPermissionLogic>().To<AccountPermissionLogic>();
            kernel.Bind<IAccountLogic>().To<AccountLogic>();
            kernel.Bind<IBranchLogic>().To<BranchLogic>();
            kernel.Bind<ICampusLogic>().To<CampusLogic>();
            kernel.Bind<ICategoryLogic>().To<CategoryLogic>();
            kernel.Bind<IComponentLogic>().To<ComponentLogic>();
            kernel.Bind<IConsumableLogic>().To<ConsumableLogic>();
            kernel.Bind<IEquipmentLogic>().To<EquipmentLogic>();
            kernel.Bind<IEquipmentTypeLogic>().To<EquipmentTypeLogic>();
            kernel.Bind<IEmployeeLogic>().To<EmployeeLogic>();
            kernel.Bind<IExecutorGroupMemberLogic>().To<ExecutorGroupMemberLogic>();
            kernel.Bind<IExecutorGroupLogic>().To<ExecutorGroupLogic>();
            kernel.Bind<IServiceLogic>().To<ServiceLogic>();            
            kernel.Bind<IServicesExecutorGroupsLogic>().To<ServicesExecutorGroupsLogic>();
            kernel.Bind<IServicesApproversLogic>().To<ServicesApproversLogic>();
            kernel.Bind<ISubdivisionExecutorLogic>().To<SubdivisionExecutorLogic>();
            kernel.Bind<ISubdivisionLogic>().To<SubdivisionLogic>();
            kernel.Bind<IPriorityLogic>().To<PriorityLogic>();
            kernel.Bind<IRequestsLogic>().To<RequestsLogic>();
            kernel.Bind<IRefuelingLimitsLogic>().To<RefuelingLimitsLogic>();
            kernel.Bind<IAttachmentLogic>().To<AttachmentLogic>();

            kernel.Bind<IInstallationEquipmentsLogic>().To<InstallationEquipmentsLogic>();
            kernel.Bind<IRefillEquipmentsLogic>().To<RefillEquipmentsLogic>();
            kernel.Bind<IRepairEquipmentsLogic>().To<RepairEquipmentsLogic>();
            kernel.Bind<IReplaceComponentsLogic>().To<ReplaceComponentsLogic>();
            kernel.Bind<IReplaceEquipmentsLogic>().To<ReplaceEquipmentsLogic>();

            kernel.Bind<IConnectionEquipmentsLogic>().To<ConnectionEquipmentsLogic>();

            AddLifeCyclesLogicBindings();
            AddRequestsLogicBindings();
            AddRequestAttachmentsLogicBindings();
        }

        private void AddRequestAttachmentsLogicBindings()
        {
            kernel.Bind<IAccountCancellationRequestAttachmentLogic>().To<AccountCancellationRequestAttachmentLogic>();
            kernel.Bind<IAccountRegistrationRequestAttachmentLogic>().To<AccountRegistrationRequestAttachmentLogic>();
            kernel.Bind<IAccountLossRequestAttachmentLogic>().To<AccountLossRequestAttachmentLogic>();
            kernel.Bind<IAccountDisconnectRequestAttachmentLogic>().To<AccountDisconnectRequestAttachmentLogic>();
        }

        private void AddRequestsLogicBindings()
        {
            kernel.Bind<IComponentReplaceRequestLogic>().To<ComponentReplaceRequestLogic>();
            kernel.Bind<IEquipmentInstallationRequestLogic>().To<EquipmentInstallationRequestLogic>();
            kernel.Bind<IEquipmentRefillRequestLogic>().To<EquipmentRefillRequestLogic>();
            kernel.Bind<IEquipmentRepairRequestLogic>().To<EquipmentRepairRequestLogic>();
            kernel.Bind<IEquipmentReplaceRequestLogic>().To<EquipmentReplaceRequestLogic>();

            kernel.Bind<IAccountCancellationRequestLogic>().To<AccountCancellationRequestLogic>();
            kernel.Bind<IAccountRegistrationRequestLogic>().To<AccountRegistrationRequestLogic>();
            kernel.Bind<IAccountLossRequestLogic>().To<AccountLossRequestLogic>();
            kernel.Bind<IAccountDisconnectRequestLogic>().To<AccountDisconnectRequestLogic>();

            kernel.Bind<INetworkConnectionRequestLogic>().To<NetworkConnectionRequestLogic>();
        }

        private void AddLifeCyclesLogicBindings()
        {
            kernel.Bind<IComponentReplaceRequestLifeCycleLogic>().To<ComponentReplaceRequestLifeCycleLogic>();
            kernel.Bind<IEquipmentInstallationRequestLifeCycleLogic>().To<EquipmentInstallationRequestLifeCycleLogic>();
            kernel.Bind<IEquipmentRefillRequestLifeCycleLogic>().To<EquipmentRefillRequestLifeCycleLogic>();
            kernel.Bind<IEquipmentRepairRequestLifeCycleLogic>().To<EquipmentRepairRequestLifeCycleLogic>();
            kernel.Bind<IEquipmentReplaceRequestLifeCycleLogic>().To<EquipmentReplaceRequestLifeCycleLogic>();

            kernel.Bind<IAccountCancellationRequestLifeCycleLogic>().To<AccountCancellationRequestLifeCycleLogic>();
            kernel.Bind<IAccountRegistrationRequestLifeCycleLogic>().To<AccountRegistrationRequestLifeCycleLogic>();
            kernel.Bind<IAccountLossRequestLifeCycleLogic>().To<AccountLossRequestLifeCycleLogic>();
            kernel.Bind<IAccountDisconnectRequestLifeCycleLogic>().To<AccountDisconnectRequestLifeCycleLogic>();

            kernel.Bind<INetworkConnectionRequestLifeCycleLogic>().To<NetworkConnectionRequestLifeCycleLogic>();
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