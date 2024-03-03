CREATE PROCEDURE [dbo].[InsertDeliveryRequest]( @ShopId INT, @Items NVARCHAR(MAX), @DeliveryPartner NVARCHAR(MAX) )
AS
BEGIN
    DECLARE @RequestDate DATETIME = GETDATE();
    INSERT INTO DeliveryRequests (ShopId, Items, DeliveryPartner, RequestDate)
    VALUES (@ShopId, @Items, @DeliveryPartner, @RequestDate);
	SELECT SCOPE_IDENTITY() AS RequestId;
END;