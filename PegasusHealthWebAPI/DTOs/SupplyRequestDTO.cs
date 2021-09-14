namespace PegasusHealthWebAPI.DTOs {
    public class SupplyRequestDTO {
        public long RequestId { get; set; }
        public long VendorId { get; set; }
        public long MedicalSupplyId { get; set; }
        public string Amount { get; set; }
        public bool Acknowledged { get; set; }
    }
}