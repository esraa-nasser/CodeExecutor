using CodeExecuter.Application.Code.Queries.GetAllCodes.Dtos;
using CodeExecuter.Application.Common.Dtos;
using CodeExecuter.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Queries.GetAllCodes
{
    public class GetAllCodesQueryHandler : IRequestHandler<GetAllCodesQuery, GetAllCodesOutput>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllCodesQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<GetAllCodesOutput> Handle(GetAllCodesQuery request, CancellationToken cancellationToken)
        {
            var codes = _applicationDbContext.Codes.Where(c => c.IsDeleted == false).AsQueryable();
            if( codes == null)
            {
                return new GetAllCodesOutput()
                {
                    AllItemsCount = 0,
                    Result = []
                };
            }
            int allItemsCount = codes.Count();
            if (request.PageNumber.HasValue && request.PageSize.HasValue)
            {
                codes = codes.Take(request.PageSize.Value).Skip((request.PageNumber.Value - 1) * request.PageSize.Value);
            }
            var result = await codes.Select(c => new CodeDto()
            {
                CodeText = c.TextCode,
                Id = c.Id
            }).ToListAsync();
            return new GetAllCodesOutput()
            {
                AllItemsCount = allItemsCount,
                Result = result
            };
        }
    }
}
