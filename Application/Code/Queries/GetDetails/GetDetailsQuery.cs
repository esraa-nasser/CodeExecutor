using CodeExecuter.Application.Code.Queries.GetDetails.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Queries.GetDetails
{
    public class GetDetailsQuery : IRequest<GetDetailsOutput>
    {
        public int Id { get; set; }
    }
}
