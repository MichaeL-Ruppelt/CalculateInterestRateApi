namespace CalculateInterestRateApi.Entities
{
    public class CalculateResponse
    {
        public decimal ValueCalculated { get; set; }

        public CalculateResponse(decimal value) { ValueCalculated = value; }
    }
}
