namespace Entities.Exceptions
{
    public class PriceOutOfRangeException : BadRequestException
    {
        public PriceOutOfRangeException() : base("Maximum price should be less than 1000 and greater than 10")
        {

        }
    }
}
