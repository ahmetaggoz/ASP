using MediatR;
using ProductManagerSystem.Features.Products.Dtos;

public record UpdateProductCommand(int Id, ProductDto Product) : IRequest<bool>;