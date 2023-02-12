namespace API_Markel.Data.Requests
{
    public class UpdateClaimRequest
    {
        public decimal? IncurredLoss { get; set; }
        public bool Closed { get; set; }
    }
}
