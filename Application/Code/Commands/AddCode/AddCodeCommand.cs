using CodeExecuter.Application.Code.Commands.AddCode.Dtos;
using MediatR;

namespace CodeExecuter.Application.Code.Commands.AddCode
{
    public class AddCodeCommand : IRequest<AddCodeOutput>
    {
        public string Code { get; set; }
    }
}
