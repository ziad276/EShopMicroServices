﻿
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description,
        string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidatro : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidatro()
        {
            RuleFor(command => command.Name).NotEmpty()
                .Length(2, 150).WithMessage("Name Must be within 2 and 150");
            RuleFor(command => command.Id).NotEmpty().WithName("Id is required");
            RuleFor(command => command.Price).GreaterThan(0).WithName("Price Should be more than Zero");
        }
    }


    internal class UpdateProductCommandHandler
        (IDocumentSession session) :
        ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
