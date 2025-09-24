using Application.Features.Products.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers
{
    public class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, List<Product>>
    { 
        private readonly IProductRepository _Repository;
        public GetAllProductsHandler(IProductRepository Repository)
        {
            _Repository = Repository;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _Repository.GetAllAsync();
        }

       
            
    }
}
