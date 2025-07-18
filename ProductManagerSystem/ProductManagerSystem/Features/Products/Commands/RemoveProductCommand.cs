using MediatR;

public record RemoveProductCommand(int Id) : IRequest<bool>;
