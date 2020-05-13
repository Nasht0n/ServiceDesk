using Domain.Models;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Domain.Models.Requests.Communication;
using Domain.Models.Requests.Email;
using Domain.Models.Requests.Equipment;
using Domain.Models.Requests.Events;
using Domain.Models.Requests.Network;
using Domain.Models.Requests.Software;
using Domain.Views;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class ServiceDeskContext : DbContext
    {
        public ServiceDeskContext() : base() { }

        public virtual DbSet<AccountCancellationRequest> AccountCancellationRequests { get; set; }
        public virtual DbSet<AccountCancellationRequestLifeCycle> AccountCancellationRequestLifeCycles { get; set; }
        public virtual DbSet<AccountDisconnectRequest> AccountDisconnectRequests { get; set; }
        public virtual DbSet<AccountDisconnectRequestLifeCycle> AccountDisconnectRequestLifeCycles { get; set; }
        public virtual DbSet<AccountLossRequest> AccountLossRequests { get; set; }
        public virtual DbSet<AccountLossRequestLifeCycle> AccountLossRequestLifeCycles { get; set; }
        public virtual DbSet<AccountRegistrationRequest> AccountRegistrationRequests { get; set; }
        public virtual DbSet<AccountRegistrationRequestLifeCycle> AccountRegistrationRequestLifeCycles { get; set; }
        public virtual DbSet<HoldingPhoneLineRequest> HoldingPhoneLineRequests { get; set; }
        public virtual DbSet<HoldingPhoneLineRequestLifeCycle> HoldingPhoneLineRequestLifeCycles { get; set; }
        public virtual DbSet<PhoneLineRepairRequest> PhoneLineRepairRequests { get; set; }
        public virtual DbSet<PhoneLineRepairRequestLifeCycle> PhoneLineRepairRequestLifeCycles { get; set; }
        public virtual DbSet<PhoneNumberAllocationRequest> PhoneNumberAllocationRequests { get; set; }
        public virtual DbSet<PhoneNumberAllocationRequestLifeCycle> PhoneNumberAllocationRequestLifeCycles { get; set; }
        public virtual DbSet<PhoneRepairRequest> PhoneRepairRequests { get; set; }
        public virtual DbSet<PhoneRepairRequestLifeCycle> PhoneRepairRequestLifeCycles { get; set; }
        public virtual DbSet<VideoCommunicationRequest> VideoCommunicationRequests { get; set; }
        public virtual DbSet<VideoCommunicationRequestLifeCycle> VideoCommunicationRequestLifeCycles { get; set; }
        public virtual DbSet<EmailRegistrationRequest> EmailRegistrationRequests { get; set; }
        public virtual DbSet<EmailRegistrationRequestLifeCycle> EmailRegistrationRequestLifeCycles { get; set; }
        public virtual DbSet<EmailSizeIncreaseRequest> EmailSizeIncreaseRequests { get; set; }
        public virtual DbSet<EmailSizeIncreaseRequestLifeCycle> EmailSizeIncreaseRequestLifeCycles { get; set; }

        public virtual DbSet<ComponentReplaceRequest> ComponentReplaceRequests { get; set; }
        public virtual DbSet<ComponentReplaceRequestLifeCycle> ComponentReplaceRequestLifeCycles { get; set; }
        public virtual DbSet<ReplaceComponents> ReplaceComponents { get; set; }

        public virtual DbSet<EquipmentInstallationRequest> EquipmentInstallationRequests { get; set; }
        public virtual DbSet<EquipmentInstallationRequestLifeCycle> EquipmentInstallationRequestLifeCycles { get; set; }
        public virtual DbSet<InstallationEquipments> InstallationEquipments { get; set; }

        public virtual DbSet<EquipmentRefillRequest> EquipmentRefillRequests { get; set; }
        public virtual DbSet<EquipmentRefillRequestLifeCycle> EquipmentRefillRequestsLifeCycles { get; set; }
        public virtual DbSet<RefillEquipments> RefillEquipments { get; set; }

        public virtual DbSet<EquipmentRepairRequest> EquipmentRepairRequests { get; set; }
        public virtual DbSet<EquipmentRepairRequestLifeCycle> EquipmentRepairRequestLifeCycles { get; set; }
        public virtual DbSet<RepairEquipments> RepairEquipments { get; set; }

        public virtual DbSet<EquipmentReplaceRequest> EquipmentReplaceRequests { get; set; }
        public virtual DbSet<EquipmentReplaceRequestLifeCycle> EquipmentReplaceRequestLifeCycles { get; set; }
        public virtual DbSet<ReplaceEquipments> ReplaceEquipments { get; set; }

        public virtual DbSet<NetworkConnectionRequest> NetworkConnectionRequests { get; set; }
        public virtual DbSet<NetworkConnectionRequestLifeCycle> NetworkConnectionRequestLifeCycles { get; set; }
        public virtual DbSet<ConnectionEquipments> ConnectionEquipments { get; set; }
        public virtual DbSet<SoftwareDevelopmentRequest> SoftwareDevelopmentRequests { get; set; }
        public virtual DbSet<SoftwareDevelopmentRequestLifeCycle> SoftwareDevelopmentRequestLifeCycles { get; set; }
        public virtual DbSet<SoftwareReworkRequest> SoftwareReworkRequests { get; set; }
        public virtual DbSet<SoftwareReworkRequestLifeCycle> SoftwareReworkRequestLifeCycles { get; set; }

        public virtual DbSet<TechnicalSupportEventRequest> TechnicalSupportEventRequests { get; set; }
        public virtual DbSet<TechnicalSupportEventRequestLifeCycle> TechnicalSupportEventRequestLifeCycles { get; set; }
        public virtual DbSet<TechnicalSupportEventEquipments> TechnicalSupportEventEquipments { get; set; }
        public virtual DbSet<TechnicalSupportEventInfos> TechnicalSupportEventInfos { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<ExecutorGroup> ExecutorGroups { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<RefuelingLimits> RefuelingLimits { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        // many to many
        public virtual DbSet<AccountCancellationRequestAttachment> AccountCancellationRequestAttachments { get; set; }
        public virtual DbSet<AccountDisconnectRequestAttachment> AccountDisconnectRequestAttachments { get; set; }
        public virtual DbSet<AccountLossRequestAttachment> AccountLossRequestAttachments { get; set; }
        public virtual DbSet<AccountRegistrationRequestAttachment> AccountRegistrationRequestAttachments { get; set; }
        public virtual DbSet<SoftwareDevelopmentRequestAttachment> SoftwareDevelopmentRequestAttachments { get; set; }
        public virtual DbSet<SoftwareReworkRequestAttachment> SoftwareReworkRequestAttachments { get; set; }
        public virtual DbSet<AccountPermission> AccountPermissions { get; set; }
        public virtual DbSet<ExecutorGroupMember> ExecutorGroupMembers { get; set; }
        public virtual DbSet<ServicesApprover> ServicesApprovers { get; set; }
        public virtual DbSet<ServicesExecutorGroup> ServicesExecutorGroups { get; set; }
        public virtual DbSet<SubdivisionExecutor> SubdivisionExecutors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {     
            modelBuilder.Entity<AccountPermission>().HasKey(c => new { c.AccountId, c.PermissionId });

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Permissions)
                .WithRequired()
                .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Accounts)
                .WithRequired()
                .HasForeignKey(c => c.PermissionId);

            modelBuilder.Entity<AccountCancellationRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<AccountCancellationRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountCancellationRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<AccountDisconnectRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<AccountDisconnectRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountDisconnectRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<AccountLossRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<AccountLossRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountLossRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<AccountRegistrationRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<AccountRegistrationRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountRegistrationRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<SoftwareDevelopmentRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<SoftwareDevelopmentRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.SoftwareDevelopmentRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<SoftwareReworkRequestAttachment>().HasKey(c => new { c.RequestId, c.AttachmentId });

            modelBuilder.Entity<SoftwareReworkRequest>()
                .HasMany(e => e.Attachments)
                .WithRequired()
                .HasForeignKey(c => c.RequestId);

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.SoftwareReworkRequests)
                .WithRequired()
                .HasForeignKey(c => c.AttachmentId);

            modelBuilder.Entity<ServicesApprover>().HasKey(c => new { c.ServiceId, c.EmployeeId });

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Approvers)
                .WithRequired()
                .HasForeignKey(c => c.ServiceId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ApprovalServices)
                .WithRequired()
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<ExecutorGroupMember>().HasKey(c => new { c.ExecutorGroupId, c.EmployeeId });

            modelBuilder.Entity<ExecutorGroup>()
                .HasMany(e => e.Employees)
                .WithRequired()
                .HasForeignKey(c => c.ExecutorGroupId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExecutorGroups)
                .WithRequired()
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<SubdivisionExecutor>().HasKey(c => new { c.SubdivisionId, c.EmployeeId });

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.SubdivisionExecutors)
                .WithRequired()
                .HasForeignKey(c => c.SubdivisionId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExecutorSubdivisions)
                .WithRequired()
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<ServicesExecutorGroup>().HasKey(c => new { c.ServiceId, c.ExecutorGroupId });

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ExecutorGroups)
                .WithRequired()
                .HasForeignKey(c => c.ServiceId);

            modelBuilder.Entity<ExecutorGroup>()
                .HasMany(e => e.Services)
                .WithRequired()
                .HasForeignKey(c => c.ExecutorGroupId);

            modelBuilder.Entity<Requests>()
                .Property(r => r.Source)
                .IsUnicode(false);

            #region CascadeOnDelete Request
            #region Accounts
            modelBuilder.Entity<AccountCancellationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountCancellationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountDisconnectRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountDisconnectRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountLossRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountLossRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountRegistrationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountRegistrationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);
            #endregion
            #region Communications
            modelBuilder.Entity<HoldingPhoneLineRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoldingPhoneLineRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneLineRepairRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneLineRepairRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneNumberAllocationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneNumberAllocationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneRepairRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneRepairRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VideoCommunicationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VideoCommunicationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);
            #endregion
            #region Emails
            modelBuilder.Entity<EmailRegistrationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmailRegistrationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmailSizeIncreaseRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmailSizeIncreaseRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);
            #endregion
            #region Equipments
            modelBuilder.Entity<ComponentReplaceRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComponentReplaceRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentInstallationRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentInstallationRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentRefillRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentRefillRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentRepairRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentRepairRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentReplaceRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentReplaceRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);


            #endregion
            #region Networks
            modelBuilder.Entity<NetworkConnectionRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NetworkConnectionRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);
            #endregion
            #region Softwares
            modelBuilder.Entity<SoftwareDevelopmentRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoftwareDevelopmentRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoftwareReworkRequest>()
                .HasOptional(r => r.Client)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoftwareReworkRequest>()
                .HasOptional(r => r.Executor)
                .WithMany()
                .WillCascadeOnDelete(false);
            #endregion
            #endregion
        }
    }
}
