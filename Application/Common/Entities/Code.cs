namespace CodeExecuter.Application.Entities
{
    public class Code
    {
        public int Id { get; set; }
        public string TextCode { get; set; }
        public string? TextOutput { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
