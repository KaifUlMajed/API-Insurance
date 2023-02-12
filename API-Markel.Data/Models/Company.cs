namespace API_Markel.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Addresses { get; set; } = new List<string>();
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool HasActiveInsurancePolicy { get; set; }
        public DateTime InsuranceEndDate { get; set; }
    }
}
