namespace Entities;

public class Recipient:BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string EligibilityStatus { get; set; }

    public List<BenefitPayment> PaymentHistory { get; set; }

    public int PreferredPaymentCurrencyId { get; set; }


}


public class BenefitPayment { }
