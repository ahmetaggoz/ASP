namespace Entities.DataTransferObjects
{
    public record ClothesDto
    {
        public int Id { get; init; }
        public String Name { get; init; }
        public decimal Price { get; init; }
    }
}
