/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Make] ([Name],[IsActive]) select 'Boeing',1 where not exists(select 1 from Make where name='Boeing')
INSERT INTO [dbo].[AirlineModel] ([Name],[IsActive]) select '777-300ER',1 where not exists(select 1 from AirlineModel where name='777-300ER”')
