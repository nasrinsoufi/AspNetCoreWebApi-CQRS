using Application.Features.Products.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {   private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product= await _repository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return false;
            }
            else
            {
                product.Name = request.Name;
                product.Price = request.Price;

                await _repository.UpdateAsync(product);
                return true;
            }
        }
    }
}
