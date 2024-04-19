using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult :Result //Resultta ıresulttan adlığı için manager kısmında successresult dönmeside sorun yok
    {
        public SuccessResult(string message):base(true,message)
        {
                
        }

        public SuccessResult():base(true)  //Burası direkt true yollar
        {
            
        }

    }
}
