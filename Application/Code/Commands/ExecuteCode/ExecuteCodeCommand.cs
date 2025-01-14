using CodeExecuter.Application.Code.Commands.ExecuteCode.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Commands.ExecuteCode
{
    public class ExecuteCodeCommand : IRequest<ExecuteCodeOutput>
    {
        public string Code { get; set; }
    }
}
