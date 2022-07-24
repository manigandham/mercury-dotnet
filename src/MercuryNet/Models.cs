namespace MercuryNet;

public class RecipientRequest
{
    public string Name { get; set; } = null!;
    public List<string> Emails { get; set; } = new();
    public string PaymentMethod { get; set; } = PaymentMethodTypes.Electronic;
    public RoutingInfo? ElectronicRoutingInfo { get; set; }
}

public class RecipientResponse
{
    public string Id { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<string> Emails { get; set; } = new();
    public RoutingInfo? ElectronicRoutingInfo { get; set; }
}

public class RoutingInfo
{
    public string? BankName { get; set; }
    public string AccountNumber { get; set; } = null!;
    public string RoutingNumber { get; set; } = null!;
    public string ElectronicAccountType { get; set; } = "personalChecking";
    public AddressInfo Address { get; set; } = null!;
}

public class AddressInfo
{
    public string Address1 { get; set; } = null!;
    public string? Address2 { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = "US";
}

public class TransactionRequest
{
    public string RecipientId { get; set; } = null!;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = "ach";
    public string? Note { get; set; }
    public string? ExternalMemo { get; set; }
    public string IdempotencyKey { get; set; } = null!;
}

public class TransactionResponse
{
    public string Id { get; set; } = null!;
    public DateTime EstimatedDeliveryDate { get; set; }
    public DateTime? FailedAt { get; set; }
    public Errors? Errors { get; set; }
}

public class Errors
{
    public string? Message { get; set; }
}
