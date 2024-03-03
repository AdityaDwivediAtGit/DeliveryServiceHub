CREATE PROCEDURE [dbo].[LastSavedRequest]
AS
BEGIN
    SELECT TOP 1 RequestId FROM DeliveryRequests ORDER BY RequestId DESC;
END;