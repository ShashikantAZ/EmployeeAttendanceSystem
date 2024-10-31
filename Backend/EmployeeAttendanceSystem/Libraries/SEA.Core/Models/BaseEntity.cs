namespace SEA.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
    }
}
