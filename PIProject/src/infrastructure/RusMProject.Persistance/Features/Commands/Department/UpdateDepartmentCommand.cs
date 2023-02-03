using AutoMapper;
using MediatR;
using RusMProject.Domain.Entities;
using RusMProject.Persistance.Statics;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction;
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

namespace RusMProject.Persistance.Features.Commands.Department
{
    public class UpdateDepartmentCommand : IRequest<IBaseResponseModelAble>
    {
        public UpdateDepartmentCommand(DepartmentUpdateDSO departmentUpdateDSO)
        {
            DepartmentUpdateDSO = departmentUpdateDSO;
        }
        public DepartmentUpdateDSO DepartmentUpdateDSO { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, IBaseResponseModelAble>
    {
        public IUserSessionAble UserSession { get; set; }
        public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentWriteRepository departmentWriteRepository, IUserSessionAble userSession)
        {
            Mapper = mapper;
            DepartmentWriteRepository = departmentWriteRepository;
            UserSession = userSession;
        }
        public IMapper Mapper { get; set; }
        public IDepartmentWriteRepository DepartmentWriteRepository;

        
        public async Task<IBaseResponseModelAble> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {

                if (request.DepartmentUpdateDSO.Id == 0)
                    throw new CustomException(500, "Client Error For Model");

                try
                {
                    var result = Mapper.Map<RusMProject.Domain.Entities.Department>(request.DepartmentUpdateDSO);

                    if (result != null)
                    {
                        var success = DepartmentWriteRepository.Update(result, UserSession.User);
                        if (success)
                            return new SuccessResponseModel(ModelMessage.CanUpdated, result);
                        return new ErrorResponseModel(ModelMessage.CanNotUpdated);
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
