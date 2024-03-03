CREATE PROCEDURE [dbo].[UpdateDeliveryResponse]
    @ResponseId INT,
    @RequestId INT,
    @Provider NVARCHAR(50),
    @Response NVARCHAR(MAX)
AS
BEGIN
    UPDATE DeliveryResponses
    SET RequestId = @RequestId,
        Provider = @Provider,
        Response = @Response
    WHERE ResponseId = @ResponseId;
END;