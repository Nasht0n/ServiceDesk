IF NOT EXISTS 
(SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[RequestsView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[RequestsView]
AS
SELECT     ROW_NUMBER() OVER (ORDER BY (SELECT     1)) AS RowNumber, *
FROM         (
SELECT     
request.Id as RequestId, 
request.Title, 
request.Justification,
request.Description, 
request.ServiceId,
request.StatusId,
request.PriorityId,
request.ClientId,
request.ExecutorId,
request.ExecutorGroupId,
request.SubdivisionId,
lifeCycle.Date,
''EquipmentInstallationRequest'' AS Source
FROM										  
dbo.EquipmentInstallationRequests request INNER JOIN
dbo.EquipmentInstallationRequestLifeCycles lifeCycle ON lifeCycle.RequestId = request.Id 
WHERE request.StatusId = 1
                         
                                              
) AS NumberedResult'