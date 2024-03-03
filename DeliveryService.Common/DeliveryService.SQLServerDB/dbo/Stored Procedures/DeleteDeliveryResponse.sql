CREATE PROCEDURE [dbo].[DeleteDeliveryResponse]
    @ResponseId INT
AS
BEGIN
    DELETE FROM DeliveryResponses
    WHERE ResponseId = @ResponseId;
END;