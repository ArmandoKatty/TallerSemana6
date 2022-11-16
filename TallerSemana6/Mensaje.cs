using System;
using System.Collections.Generic;
using System.Text;

namespace TallerSemana6
{
    public interface Mensaje
    {
        void LongAlert(string mensaje); // 5 seg
        void ShortAlert(string mensaje); //3 seg
    }
}
