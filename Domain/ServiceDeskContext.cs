using Domain.Models;
using Domain.Models.Requests.Accounts;
using Domain.Models.Requests.Communication;
using Domain.Models.Requests.Email;
using Domain.Models.Requests.Equipment;
using Domain.Models.Requests.Network;
using Domain.Models.Requests.Software;
using System.Data.Entity;

namespace Domain
{
    public class ServiceDeskContext:DbContext
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
        public virtual DbSet<EquipmentInstallationRequest> EquipmentInstallationRequests { get; set; }
        public virtual DbSet<EquipmentInstallationRequestLifeCycle> EquipmentInstallationRequestLifeCycles { get; set; }
        public virtual DbSet<EquipmentRefillRequest> EquipmentRefillRequests { get; set; }
        public virtual DbSet<EquipmentRefillRequestLifeCycle> EquipmentRefillRequestsLifeCycles { get; set; }
        public virtual DbSet<EquipmentRepairRequest> EquipmentRepairRequests { get; set; }
        public virtual DbSet<EquipmentRepairRequestLifeCycle> EquipmentRepairRequestLifeCycles { get; set; }
        public virtual DbSet<EquipmentReplaceRequest> EquipmentReplaceRequests { get; set; }
        public virtual DbSet<EquipmentReplaceRequestLifeCycle> EquipmentReplaceRequestLifeCycles { get; set; }
        public virtual DbSet<InstallationEquipments> InstallationEquipments { get; set; }
        public virtual DbSet<RefillEquipments> RefillEquipments { get; set; }
        public virtual DbSet<RepairEquipments> RepairEquipments { get; set; }
        public virtual DbSet<ReplaceComponents> ReplaceComponents { get; set; }
        public virtual DbSet<ReplaceEquipments> ReplaceEquipments { get; set; }
        public virtual DbSet<NetworkConnectionRequest> NetworkConnectionRequests { get; set; }
        public virtual DbSet<NetworkConnectionRequestLifeCycle> NetworkConnectionRequestLifeCycles { get; set; }
        public virtual DbSet<ConnectionEquipments> ConnectionEquipments { get; set; }
        public virtual DbSet<SoftwareDevelopmentRequest> SoftwareDevelopmentRequests { get; set; }
        public virtual DbSet<SoftwareDevelopmentRequestLifeCycle> SoftwareDevelopmentRequestLifeCycles { get; set; }
        public virtual DbSet<SoftwareReworkRequest> SoftwareReworkRequests { get; set; }
        public virtual DbSet<SoftwareReworkRequestLifeCycle> SoftwareReworkRequestLifeCycles { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Branch> Brunches { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<ExecutorGroup> ExecutorGroups { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<RefuelingLimits> RefuelingLimits { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Permissions)
                .WithMany(e => e.Accounts)
                .Map(m=>m.ToTable("AccountsPermissions").MapLeftKey("AccountId").MapRightKey("PermissionId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountCancellationRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("AccountCancellationRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountDisconnectRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("AccountDisconnectRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountLossRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("AccountLossRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.AccountRegistrationRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("AccountRegistrationRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.SoftwareDevelopmentRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("SoftwareDevelopmentRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.SoftwareReworkRequests)
                .WithMany(e => e.Attachments)
                .Map(m => m.ToTable("SoftwareReworkRequestAttachments").MapLeftKey("AttachmentId").MapRightKey("RequestId"));

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ApprovalServices)
                .WithMany(e => e.Approvers)
                .Map(m=>m.ToTable("ServicesApprovers").MapLeftKey("ServiceId").MapRightKey("EmployeeId"));

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExecutorGroups)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("ExecutorGroupMembers").MapLeftKey("ExecutorGroupId").MapRightKey("EmployeeId"));

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExecutorSubdivisions)
                .WithMany(e => e.SubdivisionExecutors)
                .Map(m => m.ToTable("SubdivisionExecutors").MapLeftKey("SubdivisionId").MapRightKey("EmployeeId"));

            modelBuilder.Entity<ExecutorGroup>()
                .HasMany(e => e.Services)
                .WithMany(e => e.ExecutorGroups)
                .Map(m => m.ToTable("ServicesExecutorGroups").MapLeftKey("ServiceId").MapRightKey("ExecutorGroupId"));
        }
    }
}
