USE [DataMain]
GO

INSERT INTO [dbo].[Tblu_HandUnitCalc]
           ([MainCode],[IDNo],[Name],[Address],[EnergyQuntity],[EnergyQuntityHourse],[ActivitiesCode],[PriceCalcType],[intEffectDay])
     VALUES
           --('mmr001',11111111111111,'„Õ„œ Œ·Ì·','Õ·Ê«‰',3267,2,2,365) -- „‰“·Ì 11386.45
		   ('mmr001',11111111111111,'⁄·Ì «Õ„œ','«·„⁄«œÌ',0,1.5,2,2,365) 
GO


