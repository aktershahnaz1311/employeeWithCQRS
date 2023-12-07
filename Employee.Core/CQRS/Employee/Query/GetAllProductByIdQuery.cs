using Employee.Repository.Concrete;
using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Employee.Query
{
    public  class GetAllProductByIdQuery : IRequest<QueryResult<VMProduct>>

    {


        //[JsonConstructor]
        public GetAllProductByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public class GetAllProductByIdQueryHandler : IRequestHandler<GetAllProductByIdQuery, QueryResult<VMProduct>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IValidator<GetAllProductByIdQuery> _validator;

            public GetAllProductByIdQueryHandler(IProductRepository productRepository, IValidator<GetAllProductByIdQuery> validator)
            {
                _productRepository = productRepository;
                _validator = validator;
            }
            public async Task<QueryResult<VMProduct>> Handle(GetAllProductByIdQuery request, CancellationToken cancellationToken)
            {
                var validate = await _validator.ValidateAsync(request, cancellationToken);
                if (!validate.IsValid) throw new ValidationException(validate.Errors);
                var product = await _productRepository.GetByIdAsync(request.Id);
                return product switch
                {
                    null => new QueryResult<VMProduct>(null, QueryResultTypeEnum.NotFound),
                    _ => new QueryResult<VMProduct>(product, QueryResultTypeEnum.Success)
                };
            }
        }
    }
}
