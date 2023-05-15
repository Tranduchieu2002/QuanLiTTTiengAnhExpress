using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3CExpress
{
    internal class ClassUserUtils
    {

        public string TinhHangHocSinh(float reading = 0, float speaking = 0, float listening = 0 , float writing = 0)
        {
            float overall = ( reading + speaking + listening + writing ) / 4;
            if (overall > 7)
            {
                return "Giỏi";
            }
            else if (overall > 5)
            {
                return "Khá";
            }
            else if (overall > 3)
            {
                return "Trung bình";
            }
            else return "Yếu";
        }
    }
}
