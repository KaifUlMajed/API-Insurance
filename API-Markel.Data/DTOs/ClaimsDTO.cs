namespace API_Markel.Data.DTOs
{
    public class ClaimsDTO
    {
        public string UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal? IncurredLoss { get; set; }
        public int Closed { get; set; }

    }
}
