using AutoMapper;
using MediatR;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Logging;
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
    public class GetAllEmployeeQueryWithPage : IRequest<IBaseResponseModelAble>
    {
        public GetAllEmployeeQueryWithPage(int page, int value)
        {
            Page = page;
            Value = value;
        }
        public GetAllEmployeeQueryWithPage(int value)
        {
            Value = value;
        }
        public int Page { get; set; }
        public int Value { get; set; }
    }

    public class GetAllEmployeeQueryWithPageHandler : IRequestHandler<GetAllEmployeeQueryWithPage, IBaseResponseModelAble>
    {
        public GetAllEmployeeQueryWithPageHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
        {
            Mapper = mapper;
            EmployeeReadRepository = employeeReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IEmployeeReadRepository EmployeeReadRepository;

        [LoggingAspect(Priority = 1)]
        public async Task<IBaseResponseModelAble> Handle(GetAllEmployeeQueryWithPage request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = EmployeeReadRepository.GetEmployeesWithPage(request.Page,request.Value);
                var fullData = EmployeeReadRepository.GetAllEmployees();

                var result = Mapper.Map<List<GetAllEmployeeResponseModel>>(model.ToList());

                if (result.Count != 0)
                    return new SuccessResponseModel(ModelMessage.Data, new PaginationResponseModel<GetAllEmployeeResponseModel,RusMProject.Domain.Entities.Employee>(result,fullData,request.Page,request.Value));

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
