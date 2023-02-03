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
    public class GetEmployeeQueryWithDep : IRequest<IBaseResponseModelAble>
    {
        public GetEmployeeQueryWithDep(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetEmployeeQueryWithDepHandler : IRequestHandler<GetEmployeeQueryWithDep, IBaseResponseModelAble>
    {
        public GetEmployeeQueryWithDepHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
        {
            Mapper = mapper;
            EmployeeReadRepository = employeeReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IEmployeeReadRepository EmployeeReadRepository;

        public async Task<IBaseResponseModelAble> Handle(GetEmployeeQueryWithDep request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = EmployeeReadRepository.GetEmployeesWithDepartment(request.Id);

                var result = Mapper.Map<List<GetAllEmployeeResponseModel>>(model);

                if (result != null)
                    return new SuccessResponseModel(ModelMessage.Data, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
