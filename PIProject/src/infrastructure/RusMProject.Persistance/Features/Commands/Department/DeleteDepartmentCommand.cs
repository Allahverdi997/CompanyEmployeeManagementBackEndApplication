using AutoMapper;
using MediatR;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using RusMProjectApplication.Exceptions;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models;
using RusMProjectApplication.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Features.Commands.Department
{
    public class DeleteDepartmentCommand : IRequest<IBaseResponseModelAble>
    {
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, IBaseResponseModelAble>
    {
        public IUserSessionAble UserSession { get; set; }
        public DeleteDepartmentCommandHandler(IMapper mapper, IUnitOfWorkAble unitOfWork, IUserSessionAble userSession)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            UserSession = userSession;
        }
        public IMapper Mapper { get; set; }
        public IUnitOfWorkAble UnitOfWork { get; set; }

        public async Task<IBaseResponseModelAble> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = await UnitOfWork.DepartmentReadRepository.GetAsync(request.Id);
                    if (result != null)
                    {
                        var success = UnitOfWork.DepartmentWriteRepository.Remove(result, UserSession.User);
                        if (success)
                            return new SuccessResponseModel(ModelMessage.CanNotDeleted, result);
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
