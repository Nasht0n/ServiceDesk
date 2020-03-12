﻿using DataAccess.Abstract;
using Domain;
using Domain.Models;
using System;

namespace DataAccess.Concrete
{
    public class ServiceDesk : IDisposable
    {
        private ServiceDeskContext context = new ServiceDeskContext();

        private GenericRepository<Subdivision> subdivisionRepository;
        private GenericRepository<Status> statusRepository;
        private GenericRepository<Service> serviceRepository;
        private GenericRepository<RefuelingLimits> refuelingLimitsRepository;
        private GenericRepository<Priority> priorityRepository;
        private GenericRepository<Permission> permissionRepository;
        private GenericRepository<Organization> organizationRepository;
        private GenericRepository<ExecutorGroup> executorGroupRepository;
        private GenericRepository<EquipmentType> equipmentTypeRepository;
        private GenericRepository<Equipment> equipmentRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Consumable> consumableRepository;
        private GenericRepository<Component> componentRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Campus> campusRepository;
        private GenericRepository<Cabinet> cabinetRepository;
        private GenericRepository<Branch> branchRepository;
        private GenericRepository<Attachment> attachmentRepository;
        private GenericRepository<Account> accountRepository;

        private bool disposed = false;

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

        public GenericRepository<Organization> OrganizationRepository
        {
            get
            {
                if (organizationRepository == null)
                {
                    organizationRepository = new GenericRepository<Organization>(context);
                }
                return organizationRepository;
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

        public GenericRepository<Cabinet> CabinetRepository
        {
            get
            {
                if (cabinetRepository == null) cabinetRepository = new GenericRepository<Cabinet>(context);
                return cabinetRepository;
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

        public void Save()
        {
            context.SaveChanges();
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