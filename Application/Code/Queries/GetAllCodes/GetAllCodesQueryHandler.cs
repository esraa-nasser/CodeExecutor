using CodeExecuter.Application.Code.Queries.GetAllCodes.Dtos;
using CodeExecuter.Application.Common.Dtos;
using CodeExecuter.Application.Common.Interfaces;
using MediatR;

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
            //var codes = _applicationDbContext.Codes.Where(c => c.IsDeleted == false).AsQueryable();
            //if( codes == null)
            //{
            //    return new GetAllCodesOutput()
            //    {
            //        AllItemsCount = 0,
            //        Result = []
            //    };
            //}
            var codes = new List<Entities.Code>()
            {
                new Entities.Code()
                {
                    Id = 1,
                    TextCode = @"
                                int x = 10;
                                int y = 20;
                                x * y",
                    TextOutput = null
                },
                new Entities.Code()
                {
                    Id = 12,
                    TextCode = @"
                                int x = 10;
                                int y = 20;
                                x / y",
                    TextOutput = null
                },
                new Entities.Code()
                {
                    Id = 3,
                    TextCode = @"
                                int x = 10;
                                int y = 20;
                                x + y",
                    TextOutput = null
                },
                new Entities.Code()
                {
                    Id = 3,
                    TextCode = @"
                                int x = 10;
                                int y = 20;
                                x - y",
                    TextOutput = null
                },
            }.ToList();
            int allItemsCount = codes.Count();
            //if (request.PageNumber.HasValue && request.PageSize.HasValue)
            //{
            //    codes = codes.Skip((request.PageNumber.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value);
            //}
            //var result = await codes.Select(c => new CodeDto()
            //{
            //    CodeText = c.TextCode,
            //    Id = c.Id
            //}).ToListAsync();
            var result = codes.Select(c => new CodeDto()
            {
                CodeText = c.TextCode,
                Id = c.Id
            }).ToList();
            return new GetAllCodesOutput()
            {
                AllItemsCount = allItemsCount,
                Result = result
            };
        }
    }
}
