using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    public class TierBand
    {
        public string Identification { get; set; }
        public string TierValueMinimum { get; set; }
        public string CalculationFrequency { get; set; }
        public string ApplicationFrequency { get; set; }
        public string FixedVariableInterestRateType { get; set; }
        public string AER { get; set; }

    }

    public class TierBandSet
    {
        public string TierBandMethod { get; set; }
        public List<TierBand> TierBand { get; set; }
        public string Destination { get; set; }

    }

    public class CreditInterest
    {
        public List<TierBandSet> TierBandSet { get; set; }

    }

    public class OverdraftTierBand
    {
        public string Identification { get; set; }
        public string TierValueMin { get; set; }
        public string TierValueMax { get; set; }
        public string EAR { get; set; }
        public List<string> Notes { get; set; }

    }

    public class OverdraftTierBandSet
    {
        public string TierBandMethod { get; set; }
        public string OverdraftType { get; set; }
        public string Identification { get; set; }
        public bool AuthorisedIndicator { get; set; }
        public string BufferAmount { get; set; }
        public List<string> Notes { get; set; }
        public List<OverdraftTierBand> OverdraftTierBand { get; set; }

    }

    public class Overdraft
    {
        public List<string> Notes { get; set; }
        public List<OverdraftTierBandSet> OverdraftTierBandSet { get; set; }

    }

    public class ProductDetails
    {
        public List<string> Segment { get; set; }
        public int FeeFreeLength { get; set; }
        public string FeeFreeLengthPeriod { get; set; }

    }

    public class BCA
    {
        public CreditInterest CreditInterest { get; set; }
        public Overdraft Overdraft { get; set; }
        public List<object> OtherFeesCharges { get; set; }
        public ProductDetails ProductDetails { get; set; }

    }

    public class Product
    {
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string AccountId { get; set; }
        public string SecondaryProductId { get; set; }
        public string ProductType { get; set; }
        public string MarketingStateId { get; set; }
        public BCA BCA { get; set; }

    }

    public class Data
    {
        public List<Product> Product { get; set; }

    }

    public class Links
    {
        public string Self { get; set; }

    }

    public class Meta
    {
        public int TotalPages { get; set; }

    }

    public class Root
    {
        public Data Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }

    }
}
