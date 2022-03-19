using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Exceptions
{
    public class ErroDeValidacao : Exception
    {
        public ErroDeValidacao(string mensagem) : base(mensagem) { }
    }
}
