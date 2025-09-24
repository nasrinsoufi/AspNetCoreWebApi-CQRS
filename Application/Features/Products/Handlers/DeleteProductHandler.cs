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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {   
        private readonly IProductRepository _Repository;
        public DeleteProductHandler(IProductRepository Repository)
        {
            _Repository = Repository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _Repository.GetByIdAsync(request.Id);
            if (product == null) return false; 
            await _Repository.DeleteByIdAsync(request.Id); return true;
        }


    }
}
