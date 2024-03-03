CREATE PROCEDURE [dbo].[UpdateDeliveryRequest]
    @RequestId INT,
    @ShopId INT,
    @Items NVARCHAR(MAX),
    @DeliveryPartner NVARCHAR(MAX)
AS
BEGIN
    UPDATE DeliveryRequests
    SET ShopId = @ShopId,
        Items = @Items,
        DeliveryPartner = @DeliveryPartner
    WHERE RequestId = @RequestId;
END;