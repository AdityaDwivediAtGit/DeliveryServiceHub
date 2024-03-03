CREATE PROCEDURE [dbo].[GetDeliveryResponseById]
    @ResponseId INT
AS
BEGIN
    SELECT *
    FROM DeliveryResponses
    WHERE ResponseId = @ResponseId;
END;