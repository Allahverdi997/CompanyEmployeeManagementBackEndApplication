using AutoMapper;
using MediatR;
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
    public class GetDepartmentQuery:IRequest<IBaseResponseModelAble>,IQuery
    {
        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, IBaseResponseModelAble>
    {
        public GetDepartmentQueryHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository)
        {
            Mapper = mapper;
            DepartmentReadRepository = departmentReadRepository;
        }
        public IMapper Mapper { get; set; }
        public readonly IDepartmentReadRepository DepartmentReadRepository;

        public async Task<IBaseResponseModelAble> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {

                var model =await DepartmentReadRepository.GetAsync(request.Id);

                var result = Mapper.Map<GetDepartmentResponseModel>(model);

                if (result != null)
                    return new SuccessResponseModel(ModelMessage.SingleData, result);

                return new ErrorResponseModel(ModelMessage.NoData);
            }
            return new ErrorResponseModel(ModelMessage.CancelToken);
        }
    }
}
