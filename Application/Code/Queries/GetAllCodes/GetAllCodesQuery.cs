using CodeExecuter.Application.Code.Queries.GetAllCodes.Dtos;
using MediatR;

namespace CodeExecuter.Application.Code.Queries.GetAllCodes
{
    public class GetAllCodesQuery : IRequest<GetAllCodesOutput>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
