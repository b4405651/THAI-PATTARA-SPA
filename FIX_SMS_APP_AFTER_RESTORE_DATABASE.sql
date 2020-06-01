USE SpaManagementSystem
GO
EXEC sp_change_users_login 'Auto_Fix', 'SMS_APP', NULL, 'SMS_APP'
EXEC sp_change_users_login 'update_one', 'SMS_APP', 'SMS_APP'
GO