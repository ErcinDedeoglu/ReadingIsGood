namespace ReadingIsGood.Data.Enum
{
    public enum OrderStatus
    {
        New = 0,
        PendingPayment = 1,
        PendingShipment = 2,
        PendingCustomerApproval = 3,
        Done = 4,
        Cancelled = 5,
        Returned = 6
    }
}