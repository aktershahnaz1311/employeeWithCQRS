using AutoMapper;
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

public record DeleteProductCommand(int id) : IRequest<CommandResult<VMProduct>>;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommandResult<VMProduct>>
{
    private readonly IProductRepository _productrepository; 
    private readonly IValidator<DeleteProductCommand> _validator;
    private readonly IMapper _mapper;
    public DeleteProductCommandHandler(IProductRepository productRepository, IValidator<DeleteProductCommand> validator, IMapper mapper)
    {
        _productrepository = productRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMProduct>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid) throw new ValidationException(validator.Errors);
        var result = await _productrepository.DeleteAsync(request.id);
        return result switch
        {
            null => new CommandResult<VMProduct>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMProduct>(result, CommandResultTypeEnum.Success)
        };
    }
}

