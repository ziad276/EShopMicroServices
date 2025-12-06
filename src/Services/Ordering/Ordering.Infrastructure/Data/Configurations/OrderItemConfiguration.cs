using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObject;


namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Configure the primary key for the OrderItem entity
            builder.HasKey(oi => oi.Id); //oi => oi.Id takes variable oi and returns its id


            // Configure the Id property (a Value Object) to be stored as a Guid in the database
            builder.Property(oi => oi.Id).HasConversion(

                // When saving to the database: take the Guid value from the OrderItemId value object
                orderItemId => orderItemId.Value,

                // When loading from the database: recreate the OrderItemId value object from the Guid
                dbId => OrderItemId.Of(dbId)
            );


            // Configure the relationship between OrderItem and Product:
            // Each OrderItem is linked to exactly one Product,
            // and the ProductId property on OrderItem is used as the foreign key.
            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            builder.Property(oi => oi.Quantity).IsRequired();

            builder.Property(oi => oi.Price).IsRequired();




        }
    }
}
