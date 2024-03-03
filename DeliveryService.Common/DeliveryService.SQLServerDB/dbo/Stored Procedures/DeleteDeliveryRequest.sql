CREATE PROCEDURE [dbo].[DeleteDeliveryRequest]
    @RequestId INT
AS
BEGIN
    DELETE FROM DeliveryRequests
    WHERE RequestId = @RequestId;
END;