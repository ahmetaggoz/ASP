namespace Entities.Exceptions
{
    public sealed class ClothNotFoundException : NotFoundException
    {
        public ClothNotFoundException(int id) : base($"Cloth with id {id} not found.")
        {
        }
    }
}