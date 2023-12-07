using AutoMapper;
using Employee.Model;
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

namespace Employee.Core.CQRS.Employee.Command;


public record CreateProductCommand(VMProduct product) : IRequest<CommandResult<VMProduct>>;




public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult<VMProduct>>
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductCommand> _validator;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IValidator<CreateProductCommand> validator, IMapper mapper)
    {
        _productRepository = productRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMProduct>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)

            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<Products>(request.product);

        var product = await _productRepository.InsertAsync(result);

        return product switch
        {
            null => new CommandResult<VMProduct>(null, CommandResultTypeEnum.NotFound),

            _ => new CommandResult<VMProduct>(product, CommandResultTypeEnum.Success)

        };
    }
}



