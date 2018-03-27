using fp_web_aula_1_core.Models;
using System.Collections.Generic;

namespace fp_web_aula_1_core.Services
{
    public class NoticiaService : INoticiaService
    {
        private ILogerApi _log;

        public NoticiaService(ILogerApi logerApi)
        {
            _log = logerApi;
        }
        public List<Noticia> List()
        {
            _log.Log(null, 2);
            var retorno = new List<Noticia>();
            for (int i = 0; i < 10; i++)
            {
                retorno.Add(new Noticia() { Id = i, Titulo = $"Noticia sobre {i}" });
            }
            return retorno;
            //return new List<Noticia>();
        }

      
    }
}
