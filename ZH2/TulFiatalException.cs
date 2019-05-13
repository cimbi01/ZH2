using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class TulFiatalException : Exception
    {
        public int Kor { get; }
        public TulFiatalException(int kor) : base("A megadott játékos nem múlt el 18 éves")
        {
            Kor = kor;
        }
    }
}
