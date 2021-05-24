using System;

namespace Dio.Series.Classes
{
    public abstract class EntidadeBase
    {
        public int Id {get; protected set; }

        internal object retornaExcluido()
        {
            throw new NotImplementedException();
        }

        internal int retornaId()
        {
            throw new NotImplementedException();
        }

        internal int retornaTitulo()
        {
            throw new NotImplementedException();
        }
    }
}