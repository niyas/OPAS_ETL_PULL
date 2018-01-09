CREATE PROC usp_select_IncidentManagement_Data
AS
BEGIN

	SELECT [Incident Management].[Incident Id], [Incident Management].[Notification Text],
	[Incident Management].[Severity Number],[Incident Management].Status, [Incident Management].[Suspend Reason],[Incident Management].[Assignee],[Incident Management].[Assignee Group]
	FROM OpasDatamart.dbo.[Incident Management]
	WHERE [Incident Management].[Assignee Group] in ('Tenet-Payroll/Genesys','Tenet-Payroll/HRMS-Developers')
	AND [Incident Management].Status<>'Closed'
	ORDER BY [Incident Management].[Incident Id]

END