using MediatR;
using ProductManagerSystem.Features.Products.Dtos;

public record CreateProductCommand(ProductDto Product) : IRequest<int>;