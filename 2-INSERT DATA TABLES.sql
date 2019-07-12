USE [TEST]
GO

DECLARE @ind INT=1;

WHILE(@ind<1200000)
BEGIN
	INSERT INTO [dbo].[Ref]
           ([ID]
           ,[ID2]
           ,[Name])
    SELECT
           @ind
           ,@ind
           ,CAST(@ind AS NVARCHAR(255));

	SET @ind=@ind+1;
END 
GO

USE [TEST]
GO

DECLARE @ind INT=1;
DECLARE @ind_ref INT=1;

WHILE(@ind<=12000000)
BEGIN
	IF(@ind%3=0) SET @ind_ref=1;
	ELSE IF (@ind%5=0) SET @ind_ref=2;
	ELSE IF (@ind%7=0) SET @ind_ref=3;
	ELSE IF (@ind%11=0) SET @ind_ref=4;
	ELSE IF (@ind%13=0) SET @ind_ref=5;
	ELSE IF (@ind%17=0) SET @ind_ref=6;
	ELSE IF (@ind%19=0) SET @ind_ref=7;
	ELSE IF (@ind%23=0) SET @ind_ref=8;
	ELSE IF (@ind%29=0) SET @ind_ref=9;
	ELSE IF (@ind%31=0) SET @ind_ref=10;
	ELSE IF (@ind%37=0) SET @ind_ref=11;
	ELSE SET @ind_ref=@ind%1190000;
	
	INSERT INTO [dbo].[Customer]
	           ([ID]
	           ,[Name]
	           ,[Ref_ID]
	           ,[Ref_ID2])
	     SELECT
	           @ind,
	           CAST(@ind AS NVARCHAR(255)),
	           @ind_ref,
	           @ind_ref;


	SET @ind=@ind+1;
END
GO