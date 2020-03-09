IF NOT EXISTS 
(SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Requests]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_Requests]
AS
SELECT     ROW_NUMBER() OVER (ORDER BY (SELECT     1)) AS RowNumber, *
FROM         (
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''AccountCancellationRequests'' AS Source
FROM										  dbo.AccountCancellationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''AccountDisconnectRequests'' AS Source
FROM										  dbo.AccountDisconnectRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                       
UNION                      
   
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''AccountLossRequests'' AS Source
FROM										  dbo.AccountLossRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                       UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''AccountRegistrationRequests'' AS Source
FROM										  dbo.AccountRegistrationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                       UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EmailRegistrationRequests'' AS Source
FROM										  dbo.EmailRegistrationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                       UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EmailSizeIncreaseRequests'' AS Source
FROM										  dbo.EmailSizeIncreaseRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                                              
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EquipmentInstallationRequests'' AS Source
FROM										  dbo.EquipmentInstallationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EquipmentRefillRequests'' AS Source
FROM										  dbo.EquipmentRefillRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EquipmentRepairRequests'' AS Source
FROM										  dbo.EquipmentRepairRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''EquipmentReplaceRequests'' AS Source
FROM										  dbo.EquipmentReplaceRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''NetworkConnectRequests'' AS Source
FROM										  dbo.NetworkConnectRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                                              
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''PhoneCommunicationRequests'' AS Source
FROM										  dbo.PhoneCommunicationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''SoftwareDevelopmentRequests'' AS Source
FROM										  dbo.SoftwareDevelopmentRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''SoftwareReworkRequests'' AS Source
FROM										  dbo.SoftwareReworkRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id
                                              
UNION
                       
SELECT     
request.Id as RequestId, 
action.Id as ActionId, 
action.Name as ActionName, 
service.Id as ServiceId, 
service.Name as ServiceName, 
status.Id as StatusId, 
status.Name as StatusName, 
client.Id AS ClientId, 
client.Fullname AS ClientFullname, 
execGroup.Id as ExecutorGroupId, 
execGroup.Name as ExecutorGroupName, 
executor.Id AS ExecutorId, 
executor.Fullname AS ExecutorFullname, 
request.Title, 
request.Description, 
''VideoCommunicationRequests'' AS Source
FROM										  dbo.VideoCommunicationRequests request INNER JOIN
                                              dbo.Actions action ON request.ActionId = action.Id INNER JOIN
                                              dbo.Services service ON action.ServiceId = service.Id INNER JOIN
                                              dbo.Status status ON request.StatusId = status.Id INNER JOIN
                                              dbo.Employees client ON request.ClientId = client.Id INNER JOIN
                                              dbo.ExecutorGroups execGroup ON request.ExecutorGroupId = execGroup.Id LEFT OUTER JOIN
                                              dbo.Employees executor ON request.ExecutorId = executor.Id                                             
                                              
) AS NumberedResult'