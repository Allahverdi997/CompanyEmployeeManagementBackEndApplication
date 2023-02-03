using AutoMapper;
using MediatR;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using RusMProjectApplication.Exceptions;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models;
using RusMProjectApplication.Models.General;
using RusMProjectApplication.Registration.CreateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Features.Commands.Employee
{
    public class CreateEmployeeCommand : IRequest<IBaseResponseModelAble>
    {
        public CreateEmployeeCommand(EmployeeDSO employeeDSO)
        {
            EmployeeDSO = employeeDSO;
        }
        public EmployeeDSO EmployeeDSO { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IBaseResponseModelAble>
    {
        public IUserSessionAble UserSession { get; set; }
        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeWriteRepository employeeWriteRepository, IUserSessionAble userSession)
        {
            Mapper = mapper;
            EmployeeWriteRepository = employeeWriteRepository;
            UserSession = userSession;
        }
        public IMapper Mapper { get; set; }
        public IEmployeeWriteRepository EmployeeWriteRepository;

        public async Task<IBaseResponseModelAble> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = Mapper.Map<RusMProject.Domain.Entities.Employee>(request.EmployeeDSO);

                    if (result != null)
                    {
                        var success = await EmployeeWriteRepository.Add(result, UserSession.User);
                        if (success)
                            return new SuccessResponseModel(ModelMessage.CanAdded, result);
                        return new ErrorResponseModel(ModelMessage.CanNotAdded);
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new ServerErrorException("Server Error");
                }
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
