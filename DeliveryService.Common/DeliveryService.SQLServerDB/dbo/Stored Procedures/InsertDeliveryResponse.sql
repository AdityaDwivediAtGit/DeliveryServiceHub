CREATE PROCEDURE [dbo].[InsertDeliveryResponse]
    @RequestId INT,
    @Provider NVARCHAR(50),
    @Response NVARCHAR(MAX),
	@ResponseDate DATETIME
AS
BEGIN
    INSERT INTO DeliveryResponses (RequestId, Provider, Response, ResponseDate)
    VALUES (@RequestId, @Provider, @Response, @ResponseDate);
END;