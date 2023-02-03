using AutoMapper;
using MediatR;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction;
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
    public class SearchEmployeeQuery : IRequest<IBaseResponseModelAble>
    {
        public string Word { get; set; }
        public SearchEmployeeQuery(string word)
        {
            Word = word;    
        }
    }

    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQuery, IBaseResponseModelAble>
    {
        public SearchEmployeeQueryHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
        {
            Mapper = mapper;
            EmployeeReadRepository = employeeReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IEmployeeReadRepository EmployeeReadRepository;
        [TransactionAspect]
        public async Task<IBaseResponseModelAble> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = EmployeeReadRepository.SearchEmployees(request.Word);

                var result = Mapper.Map<List<GetAllEmployeeResponseModel>>(model);

                if (result.Count != 0)
                    return new SuccessResponseModel(ModelMessage.Data, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
