using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success, string message):this(success) //burası diyorki eğer iki parametre gönderirse hem birinci hem ikinci ctor çalışır.
        {                                                           //Yani alttakini de çalıştır
            Message= message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; } // Normalde burası sadece get ,readonly ama biz bunu yani Buranın set kısmını  ctor da yapabiliyoruz

        public string Message { get; }
    }
}
