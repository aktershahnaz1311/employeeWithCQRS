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

public record UpdateProductCommand(int id, VMProduct product) : IRequest<CommandResult<VMProduct>>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommandResult<VMProduct>>

{

    private readonly IProductRepository _productrepository;
    private readonly IValidator<UpdateProductCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IValidator<UpdateProductCommand> validator, IMapper mapper)
    {
        _productrepository = productRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMProduct>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
            throw new ValidationException(validator.Errors);
        var data = _mapper.Map<Products>(request.product);
        var result = await _productrepository.UpdateAsync(request.id, data);
        return result switch
        {
            null => new CommandResult<VMProduct>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMProduct>(result, CommandResultTypeEnum.Success)
        };
    }




}


