using CodeExecuter.Application.Code.Commands.AddCode.Dtos;
using CodeExecuter.Application.Common.Interfaces;
using MediatR;

namespace CodeExecuter.Application.Code.Commands.AddCode
{
    public class AddCodeCommandHandler : IRequestHandler<AddCodeCommand, AddCodeOutput>
    {
        private readonly IApplicationDbContext _context;

        public AddCodeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddCodeOutput> Handle(AddCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateCommand(request);
                _context.Codes.Add(new Entities.Code
                {
                    TextCode = request.Code,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                });
                if (_context.SaveChanges() > new int())
                {
                    return new AddCodeOutput
                    {
                        Created = true,
                    };
                }
                else
                {
                    throw new Exception("Error while saving code");
                }
            }catch(Exception ex)
            {
                throw;
            }
            
        }
        private async Task ValidateCommand(AddCodeCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Code))
            {
                throw new Exception("TextCode is required");
            }
            //here will add regex to check if code is c# code 
            //var isCommandArray = Regex.IsMatch(request.Code, @"^\[.*?\]$");

        }
    }
}
