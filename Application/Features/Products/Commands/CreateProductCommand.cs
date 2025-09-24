using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
