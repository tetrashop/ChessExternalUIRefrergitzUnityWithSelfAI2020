using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigtzChessPortable
{
    static class TimeElapced
    {

        public static long TimeNow()
        {
            DateTime Now = DateTime.Now;
            return (Now.Hour * 24 * 60 * 60 * 1000) + (Now.Minute * 60 * 1000) + (Now.Second * 1000) + Now.Millisecond;
        }
    }
}
