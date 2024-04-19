using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç // burayı açmamızın amacı işlem başarılı mı başarısız mı bunuda class açıyoruz :)
    public interface IResult
    {
        bool Success { get; }
       string Message { get; }
    }
}
