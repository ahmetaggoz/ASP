using MediatR;
using ProductManagerSystem.Models;

public record GetProductsQuery : IRequest<List<Product>>;