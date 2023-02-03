using AutoMapper;
using MediatR;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models.General;
using RusMProjectApplication.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Models.Domain.User;
using RusMProject.Domain.Entities;

namespace RusMProject.Persistance.Features.Queries.User
{
    public class GetUserQuery : IRequest<IBaseResponseModelAble>
    {
        public GetUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IBaseResponseModelAble>
    {
        public GetUserQueryHandler(IMapper mapper, IUserReadRepository userReadRepository,IUserService userService)
        {
            Mapper = mapper;
            UserReadRepository = userReadRepository;
            UserService = userService;
        }
        public IMapper Mapper { get; set; }
        public readonly IUserReadRepository UserReadRepository;
        public IUserService UserService { get; set; }
        [TransactionAspect]
        public async Task<IBaseResponseModelAble> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                RusMProject.Domain.Entities.User user = UserReadRepository.GetUserByNamePassword(request.UserName, request.Password);

                string token = UserService.GenerateToken(user);

                var result = Mapper.Map<GetLoginUserResponseModel>(user);
                result.Token = token;

                if (result != null)
                    return new SuccessResponseModel(ModelMessage.Data, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
