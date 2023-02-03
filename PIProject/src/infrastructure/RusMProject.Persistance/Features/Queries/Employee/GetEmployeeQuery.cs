using AutoMapper;
using MediatR;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models;
using RusMProjectApplication.Models.General;
using RusMProjectApplication.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Features.Queries.Employee
{
    public class GetEmployeeQuery : IRequest<IBaseResponseModelAble>
    {
        public GetEmployeeQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IBaseResponseModelAble>
    {
        public GetEmployeeQueryHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
        {
            Mapper = mapper;
            EmployeeReadRepository = employeeReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IEmployeeReadRepository EmployeeReadRepository;

        public async Task<IBaseResponseModelAble> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = EmployeeReadRepository.GetEmployeeWithInclude(request.Id);

                var result = Mapper.Map<GetEmployeeResponseModel>(model);

                if (result != null)
                    return new SuccessResponseModel(ModelMessage.SingleData, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
