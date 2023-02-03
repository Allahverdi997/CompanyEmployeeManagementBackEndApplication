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

namespace RusMProject.Persistance.Features.Commands.User
{
    public class CreateUserCommand : IRequest<IBaseResponseModelAble>
    {
        public CreateUserCommand(UserDSO userDSO)
        {
            UserDSO = userDSO;
        }
        public UserDSO UserDSO { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IBaseResponseModelAble>
    {
        public IUserSessionAble UserSession { get; set; }
        public CreateUserCommandHandler(IMapper mapper, IUserWriteRepository userWriteRepository, IUserSessionAble userSession)
        {
            Mapper = mapper;
            UserWriteRepository = userWriteRepository;
            UserSession = userSession;
        }
        public IMapper Mapper { get; set; }
        public IUserWriteRepository UserWriteRepository;

        public async Task<IBaseResponseModelAble> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = Mapper.Map<RusMProject.Domain.Entities.User>(request.UserDSO);

                    if (result != null)
                    {
                        var success = await UserWriteRepository.Add(result, UserSession.User);
                        if (success)
                            return new SuccessResponseModel(ModelMessage.CanAdded, result);
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
