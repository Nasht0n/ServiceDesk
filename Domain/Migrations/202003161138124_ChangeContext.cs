namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeContext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServicesApprovers", name: "ServiceId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ServicesApprovers", name: "EmployeeId", newName: "ServiceId");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "ExecutorGroupId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "EmployeeId", newName: "ExecutorGroupId");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "SubdivisionId", newName: "__mig_tmp__2");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "EmployeeId", newName: "SubdivisionId");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "ServiceId", newName: "__mig_tmp__3");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "ExecutorGroupId", newName: "ServiceId");
            RenameColumn(table: "dbo.ServicesApprovers", name: "__mig_tmp__0", newName: "EmployeeId");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "__mig_tmp__1", newName: "EmployeeId");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "__mig_tmp__2", newName: "EmployeeId");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "__mig_tmp__3", newName: "ExecutorGroupId");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "IX_ServiceId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "IX_ExecutorGroupId", newName: "IX_ServiceId");
            RenameIndex(table: "dbo.ServicesApprovers", name: "IX_ServiceId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.ServicesApprovers", name: "IX_EmployeeId", newName: "IX_ServiceId");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "IX_ExecutorGroupId", newName: "__mig_tmp__2");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "IX_EmployeeId", newName: "IX_ExecutorGroupId");
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "IX_SubdivisionId", newName: "__mig_tmp__3");
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "IX_EmployeeId", newName: "IX_SubdivisionId");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "__mig_tmp__0", newName: "IX_ExecutorGroupId");
            RenameIndex(table: "dbo.ServicesApprovers", name: "__mig_tmp__1", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "__mig_tmp__2", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "__mig_tmp__3", newName: "IX_EmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "IX_EmployeeId", newName: "__mig_tmp__3");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "IX_EmployeeId", newName: "__mig_tmp__2");
            RenameIndex(table: "dbo.ServicesApprovers", name: "IX_EmployeeId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "IX_ExecutorGroupId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "IX_SubdivisionId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.SubdivisionExecutors", name: "__mig_tmp__3", newName: "IX_SubdivisionId");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "IX_ExecutorGroupId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.ExecutorGroupMembers", name: "__mig_tmp__2", newName: "IX_ExecutorGroupId");
            RenameIndex(table: "dbo.ServicesApprovers", name: "IX_ServiceId", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.ServicesApprovers", name: "__mig_tmp__1", newName: "IX_ServiceId");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "IX_ServiceId", newName: "IX_ExecutorGroupId");
            RenameIndex(table: "dbo.ServicesExecutorGroups", name: "__mig_tmp__0", newName: "IX_ServiceId");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "ExecutorGroupId", newName: "__mig_tmp__3");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "EmployeeId", newName: "__mig_tmp__2");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "EmployeeId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.ServicesApprovers", name: "EmployeeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "ServiceId", newName: "ExecutorGroupId");
            RenameColumn(table: "dbo.ServicesExecutorGroups", name: "__mig_tmp__3", newName: "ServiceId");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "SubdivisionId", newName: "EmployeeId");
            RenameColumn(table: "dbo.SubdivisionExecutors", name: "__mig_tmp__2", newName: "SubdivisionId");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "ExecutorGroupId", newName: "EmployeeId");
            RenameColumn(table: "dbo.ExecutorGroupMembers", name: "__mig_tmp__1", newName: "ExecutorGroupId");
            RenameColumn(table: "dbo.ServicesApprovers", name: "ServiceId", newName: "EmployeeId");
            RenameColumn(table: "dbo.ServicesApprovers", name: "__mig_tmp__0", newName: "ServiceId");
        }
    }
}
