using AutoMapper;
using MediatR;
using RusMProject.Domain.Common;
using RusMProject.Persistance.Statics;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using RusMProjectApplication.Exceptions;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models;
using RusMProjectApplication.Models.General;
using RusMProjectApplication.Registration.UpdateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Features.Commands.Employee
{
    public class UpdateEmployeeCommand : IRequest<IBaseResponseModelAble>
    {
        public UpdateEmployeeCommand(EmployeeUpdateDSO employeeUpdateDSO)
        {
            EmployeeUpdateDSO = employeeUpdateDSO;
        }
        public EmployeeUpdateDSO EmployeeUpdateDSO { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, IBaseResponseModelAble>
    {
        public IUserSessionAble UserSession { get; set; }
        public UpdateEmployeeCommandHandler(IMapper mapper, IUnitOfWorkAble unitOfWorkAble, IUserSessionAble userSession)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWorkAble;
            UserSession = userSession;
        }
        public IMapper Mapper { get; set; }
        public IUnitOfWorkAble UnitOfWork;

        public async Task<IBaseResponseModelAble> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (request.EmployeeUpdateDSO.Id == 0)
                        throw new CustomException(500, "Client Error For Model");

                    var result = Mapper.Map<RusMProject.Domain.Entities.Employee>(request.EmployeeUpdateDSO);

                    if (result != null)
                    {
                        var success = UnitOfWork.EmployeeWriteRepository.Update(result, UserSession.User);

                        if (success)
                            return new SuccessResponseModel(ModelMessage.CanUpdated, result);
                        return new ErrorResponseModel(ModelMessage.CanNotAdded);
                    }
                }
                catch (Exception)
                {
                    throw new ServerErrorException("Server Error");
                }
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
