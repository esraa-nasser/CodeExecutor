using CodeExecuter.Application.Code.Commands.AddCode;
using CodeExecuter.Application.Code.Commands.ExecuteCode.Dtos;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Commands.ExecuteCode
{
    public class ExecuteCodeCommandHandler : IRequestHandler<ExecuteCodeCommand, ExecuteCodeOutput>
    {
        public async Task<ExecuteCodeOutput> Handle(ExecuteCodeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateCommand(command);
                var result = await CSharpScript.EvaluateAsync(command.Code);
                return new ExecuteCodeOutput()
                {
                    Result = JsonConvert.SerializeObject(result),
                    ExecutedSuccessfully = true
                };
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //create a handler class for validation and use it inside add and execute
        private async Task ValidateCommand(ExecuteCodeCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Code))
            {
                throw new Exception("TextCode is required");
            }
            //here will add regex to check if code is c# code 
            //var isCommandArray = Regex.IsMatch(request.Code, @"^\[.*?\]$");

        }
    }
}
