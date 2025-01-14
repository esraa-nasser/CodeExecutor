using CodeExecuter.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExecuter.Application.Code.Queries.GetAllCodes.Dtos
{
    public class GetAllCodesOutput
    {
        public IList<CodeDto> Result { get; set; }
        public int AllItemsCount { get; set; }
    }
}
