using DataAccess.Abstract;
using Domain;
using Domain.Models;
using Domain.Models.Requests.Equipment;
using Domain.Views;
using System;

namespace DataAccess.Concrete
{
    public class ServiceDesk : IDisposable
    {
        private ServiceDeskContext context = new ServiceDeskContext();

        private GenericRepository<EquipmentInstallationRequest> equipmentInstallationRequestRepository;
        private GenericRepository<EquipmentInstallationRequestLifeCycle> equipmentInstallationRequestLifeCycleRepository;
        private GenericRepository<InstallationEquipments> installationEquipmentsRepository;

        private GenericRepository<EquipmentReplaceRequest> equipmentReplaceRequestRepository;
        private GenericRepository<EquipmentReplaceRequestLifeCycle> equipmentReplaceRequestLifeCycleRepository;
        private GenericRepository<ReplaceEquipments> replaceEquipmentsRepository;

        private GenericRepository<EquipmentRefillRequest> equipmentRefillRequestRepository;
        private GenericRepository<EquipmentRefillRequestLifeCycle> equipmentRefillRequestLifeCycleRepository;
        private GenericRepository<RefillEquipments> refillEquipmentsRepository;

        private GenericRepository<EquipmentRepairRequest> equipmentRepairRequestRepository;
        private GenericRepository<EquipmentRepairRequestLifeCycle> equipmentRepairRequestLifeCycleRepository;
        private GenericRepository<RepairEquipments> repairEquipmentsRepository;

        private GenericRepository<ComponentReplaceRequest> componentReplaceRequestRepository;
        private GenericRepository<ComponentReplaceRequestLifeCycle> componentReplaceRequestLifeCycleRepository;
        private GenericRepository<ReplaceComponents> replaceComponentRepository;

        private GenericRepository<RefuelingLimits> refuelingLimitRepository;

        private GenericRepository<Requests> requestsRepository;

        private GenericRepository<Subdivision> subdivisionRepository;
        private GenericRepository<Status> statusRepository;
        private GenericRepository<Service> serviceRepository;
        private GenericRepository<RefuelingLimits> refuelingLimitsRepository;
        private GenericRepository<Priority> priorityRepository;
        private GenericRepository<Permission> permissionRepository;
        private GenericRepository<ExecutorGroup> executorGroupRepository;
        private GenericRepository<EquipmentType> equipmentTypeRepository;
        private GenericRepository<Equipment> equipmentRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Consumable> consumableRepository;
        private GenericRepository<Component> componentRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Campus> campusRepository;
        private GenericRepository<Branch> branchRepository;
        private GenericRepository<Attachment> attachmentRepository;
        private GenericRepository<Account> accountRepository;

        private bool disposed = false;
        
        public GenericRepository<RefuelingLimits> RefuelingLimitRepository
        {
            get
            {
                if(refuelingLimitRepository == null)
                {
                    refuelingLimitRepository = new GenericRepository<RefuelingLimits>(context);
                }
                return refuelingLimitRepository;
            }
        }

        public GenericRepository<Requests> RequestsRepository
        {
            get
            {
                if (requestsRepository == null)
                {
                    requestsRepository = new GenericRepository<Requests>(context);
                }
                return requestsRepository;
            }
        }

        public GenericRepository<ComponentReplaceRequest> ComponentReplaceRequestRepository
        {
            get
            {
                if (componentReplaceRequestRepository == null)
                {
                    componentReplaceRequestRepository = new GenericRepository<ComponentReplaceRequest>(context);
                }
                return componentReplaceRequestRepository;
            }
        }

        public GenericRepository<ComponentReplaceRequestLifeCycle> ComponentReplaceRequestLifeCycleRepository
        {
            get
            {
                if (componentReplaceRequestLifeCycleRepository == null)
                {
                    componentReplaceRequestLifeCycleRepository = new GenericRepository<ComponentReplaceRequestLifeCycle>(context);
                }
                return componentReplaceRequestLifeCycleRepository;
            }
        }

        public GenericRepository<ReplaceComponents> ReplaceComponentRepository
        {
            get
            {
                if (replaceComponentRepository == null)
                {
                    replaceComponentRepository = new GenericRepository<ReplaceComponents>(context);
                }
                return replaceComponentRepository;
            }
        }


        public GenericRepository<EquipmentRepairRequest> EquipmentRepairRequestRepository
        {
            get
            {
                if (equipmentRepairRequestRepository == null)
                {
                    equipmentRepairRequestRepository = new GenericRepository<EquipmentRepairRequest>(context);
                }
                return equipmentRepairRequestRepository;
            }
        }

        public GenericRepository<EquipmentRepairRequestLifeCycle> EquipmentRepairRequestLifeCycleRepository
        {
            get
            {
                if (equipmentRepairRequestLifeCycleRepository == null)
                {
                    equipmentRepairRequestLifeCycleRepository = new GenericRepository<EquipmentRepairRequestLifeCycle>(context);
                }
                return equipmentRepairRequestLifeCycleRepository;
            }
        }

        public GenericRepository<RepairEquipments> RepairEquipmentsRepository
        {
            get
            {
                if (repairEquipmentsRepository == null)
                {
                    repairEquipmentsRepository = new GenericRepository<RepairEquipments>(context);
                }
                return repairEquipmentsRepository;
            }
        }


        public GenericRepository<EquipmentRefillRequest> EquipmentRefillRequestRepository
        {
            get
            {
                if (equipmentRefillRequestRepository == null)
                {
                    equipmentRefillRequestRepository = new GenericRepository<EquipmentRefillRequest>(context);
                }
                return equipmentRefillRequestRepository;
            }
        }

        public GenericRepository<EquipmentRefillRequestLifeCycle> EquipmentRefillRequestLifeCycleRepository
        {
            get
            {
                if (equipmentRefillRequestLifeCycleRepository == null)
                {
                    equipmentRefillRequestLifeCycleRepository = new GenericRepository<EquipmentRefillRequestLifeCycle>(context);
                }
                return equipmentRefillRequestLifeCycleRepository;
            }
        }

        public GenericRepository<RefillEquipments> RefillEquipmentsRepository
        {
            get
            {
                if (refillEquipmentsRepository == null)
                {
                    refillEquipmentsRepository = new GenericRepository<RefillEquipments>(context);
                }
                return refillEquipmentsRepository;
            }
        }

        public GenericRepository<EquipmentReplaceRequest> EquipmentReplaceRequestRepository
        {
            get
            {
                if(equipmentReplaceRequestRepository == null)
                {
                    equipmentReplaceRequestRepository = new GenericRepository<EquipmentReplaceRequest>(context);
                }
                return equipmentReplaceRequestRepository;
            }
        }

        public GenericRepository<EquipmentReplaceRequestLifeCycle> EquipmentReplaceRequestLifeCycleRepository
        {
            get
            {
                if (equipmentReplaceRequestLifeCycleRepository == null)
                {
                    equipmentReplaceRequestLifeCycleRepository = new GenericRepository<EquipmentReplaceRequestLifeCycle>(context);
                }
                return equipmentReplaceRequestLifeCycleRepository;
            }
        }

        public GenericRepository<ReplaceEquipments> ReplaceEquipmentsRepository
        {
            get
            {
                if (replaceEquipmentsRepository == null)
                {
                    replaceEquipmentsRepository = new GenericRepository<ReplaceEquipments>(context);
                }
                return replaceEquipmentsRepository;
            }
        }

        public GenericRepository<InstallationEquipments> InstallationEquipmentsRepository
        {
            get
            {
                if (installationEquipmentsRepository == null)
                {
                    installationEquipmentsRepository = new GenericRepository<InstallationEquipments>(context);
                }
                return installationEquipmentsRepository;
            }
        }

        public GenericRepository<EquipmentInstallationRequest> EquipmentInstallationRequestRepository
        {
            get 
            {
                if (equipmentInstallationRequestRepository == null)
                { 
                    equipmentInstallationRequestRepository = new GenericRepository<EquipmentInstallationRequest>(context);
                }
                return equipmentInstallationRequestRepository;
            }
        }

        public GenericRepository<EquipmentInstallationRequestLifeCycle> EquipmentInstallationRequestLifeCycleRepository
        {
            get
            {
                if(equipmentInstallationRequestLifeCycleRepository == null)
                {
                    equipmentInstallationRequestLifeCycleRepository = new GenericRepository<EquipmentInstallationRequestLifeCycle>(context);
                }
                return equipmentInstallationRequestLifeCycleRepository;
            }
        }

        public GenericRepository<Subdivision> SubdivisionRepository
        {
            get
            {
                if (subdivisionRepository == null)
                {
                    subdivisionRepository = new GenericRepository<Subdivision>(context);
                }
                return subdivisionRepository;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {
                if (statusRepository == null)
                {
                    statusRepository = new GenericRepository<Status>(context);
                }
                return statusRepository;
            }
        }

        public GenericRepository<Service> ServiceRepository
        {
            get
            {
                if (serviceRepository == null)
                {
                    serviceRepository = new GenericRepository<Service>(context);
                }
                return serviceRepository;
            }
        }

        public GenericRepository<RefuelingLimits> RefuelingLimitsRepository
        {
            get
            {
                if (refuelingLimitsRepository == null)
                {
                    refuelingLimitsRepository = new GenericRepository<RefuelingLimits>(context);
                }
                return refuelingLimitsRepository;
            }
        }

        public GenericRepository<Priority> PriorityRepository
        {
            get
            {
                if (priorityRepository == null)
                {
                    priorityRepository = new GenericRepository<Priority>(context);
                }
                return priorityRepository;
            }
        }

        public GenericRepository<Permission> PermissionRepository
        {
            get
            {
                if (permissionRepository == null)
                {
                    permissionRepository = new GenericRepository<Permission>(context);
                }
                return permissionRepository;
            }
        }
        
        public GenericRepository<ExecutorGroup> ExecutorGroupRepository
        {
            get
            {
                if (executorGroupRepository == null)
                {
                    executorGroupRepository = new GenericRepository<ExecutorGroup>(context);
                }
                return executorGroupRepository;
            }
        }

        public GenericRepository<EquipmentType> EquipmentTypeRepository
        {
            get
            {
                if (equipmentTypeRepository == null)
                {
                    equipmentTypeRepository = new GenericRepository<EquipmentType>(context);
                }
                return equipmentTypeRepository;
            }
        }

        public GenericRepository<Equipment> EquipmentRepository
        {
            get
            {
                if (equipmentRepository == null)
                {
                    equipmentRepository = new GenericRepository<Equipment>(context);
                }
                return equipmentRepository;
            }
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepository<Employee>(context);
                }
                return employeeRepository;
            }
        }

        public GenericRepository<Consumable> ConsumableRepository
        {
            get
            {
                if (consumableRepository == null)
                {
                    consumableRepository = new GenericRepository<Consumable>(context);
                }
                return consumableRepository;
            }
        }

        public GenericRepository<Component> ComponentRepository
        {
            get
            {
                if (componentRepository == null)
                {
                    componentRepository = new GenericRepository<Component>(context);
                }
                return componentRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<Campus> CampusRepository
        {
            get
            {
                if (campusRepository == null) campusRepository = new GenericRepository<Campus>(context);
                return campusRepository;
            }
        }

        public GenericRepository<Branch> BranchRepository
        {
            get
            {
                if (branchRepository == null) branchRepository = new GenericRepository<Branch>(context);
                return branchRepository;
            }
        }

        public GenericRepository<Attachment> AttachmentRepository
        {
            get
            {
                if (attachmentRepository == null) attachmentRepository = new GenericRepository<Attachment>(context);
                return attachmentRepository;
            }
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {
                if (accountRepository == null) accountRepository = new GenericRepository<Account>(context);
                return accountRepository;
            }
        }

        public int Save()
        {
           return context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
