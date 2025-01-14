using CodeExecuter.Application.Code.Queries.GetDetails.Dtos;
using CodeExecuter.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Queries.GetDetails
{
    public class GetDetailsQueryHandler : IRequestHandler<GetDetailsQuery, GetDetailsOutput>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetDetailsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<GetDetailsOutput> Handle(GetDetailsQuery request, CancellationToken cancellationToken)
        {
            Validate(request);
            var code = await _applicationDbContext.Codes.FirstOrDefaultAsync(c => c.Id == request.Id && c.IsDeleted == false);
            if(code == null)
            {
                throw new Exception("Code not found");
            }
            return new GetDetailsOutput()
            {
                Id = code.Id,
                Texts = code.TextCode
            };
        }
        private void Validate (GetDetailsQuery request)
        {
            if (request.Id == 0)
            {
                throw new Exception("Id is required");
            }
        }
    }
}
