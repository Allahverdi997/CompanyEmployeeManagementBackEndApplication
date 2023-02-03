using AutoMapper;
using MediatR;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Logging;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Exceptions;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Models;
using RusMProjectApplication.Models.General;
using RusMProjectApplication.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Features.Queries.Department
{
    public class SearchDepartmentQuery : IRequest<IBaseResponseModelAble>,IQuery
    {
        public string Word { get; set; }
        public SearchDepartmentQuery(string word)
        {
            Word = word;    
        }
    }

    public class SearchDepartmentQueryHandler : IRequestHandler<SearchDepartmentQuery, IBaseResponseModelAble>
    {
        public SearchDepartmentQueryHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository)
        {
            Mapper = mapper;
            DepartmentReadRepository = departmentReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IDepartmentReadRepository DepartmentReadRepository;

        [LoggingAspect(Priority =1)]
        public async Task<IBaseResponseModelAble> Handle(SearchDepartmentQuery request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var model = DepartmentReadRepository.SearchDepartments(request.Word);
                var result = Mapper.Map<List<GetAllDepartmentResponseModel>>(model);

                if (result.Count != 0)
                    return new SuccessResponseModel(ModelMessage.Data, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
