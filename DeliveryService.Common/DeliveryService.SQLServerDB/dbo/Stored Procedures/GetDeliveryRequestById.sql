CREATE PROCEDURE [dbo].[GetDeliveryRequestById] (@RequestId INT) AS
BEGIN
    SELECT *
    FROM DeliveryRequests
    WHERE RequestId = @RequestId;
END;