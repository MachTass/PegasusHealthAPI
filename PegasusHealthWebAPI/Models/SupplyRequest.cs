namespace PegasusHealthWebAPI.Models {
    public class SupplyRequest {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long VendorId { get; set; }
        public long MedicalSupplyId { get; set; }
        public string Amount { get; set; }
        public bool Acknowledged { get; set; }
    }
}