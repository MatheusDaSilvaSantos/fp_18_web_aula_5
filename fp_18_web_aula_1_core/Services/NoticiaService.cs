using fp_web_aula_1_core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fp_web_aula_1_core.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _memoryCache;
        private ILogerApi _log;

        public NoticiaService(ILogerApi logerApi, Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            _log = logerApi;
        }
        public List<Noticia> List()
        {
            _log.Log(null, 2);
            var retorno = new List<Noticia>();
            var cacheKey = "listanoticias";

            if (!_memoryCache.TryGetValue(cacheKey, out retorno))
            {
                retorno = new List<Noticia>();
                Task.Delay(200).Wait();

                retorno.Add(new Noticia() { Id = 1, Titulo = "Demora nos Correios pode fazer brasileiros cancelarem ida à Copa", Url = "#", Imagem = "/assets/noticias/noticia-1.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 2, Titulo = "Copa 2018: Caboclo será chefe da delegação do Brasil na Rússia", Url = "#", Imagem = "/assets/noticias/noticia-2.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 3, Titulo = "CBF anuncia data da convocação para a Copa do Mundo", Url = "#", Imagem = "/assets/noticias/noticia-3.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 4, Titulo = "Felipão sobre Romário em 2002: ‘Não era o melhor para a equipe’", Url = "#", Imagem = "/assets/noticias/noticia-4.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 5, Titulo = "Cléber Xavier, o técnico número 2 da seleção brasileira", Url = "#", Imagem = "/assets/noticias/noticia-5.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 6, Titulo = "Meia belga Nainggolan é condenado por dirigir embriagado", Url = "#", Imagem = "/assets/noticias/noticia-6.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 7, Titulo = "Kroos: ‘O Brasil nos mostrou que não somos tão bons quanto dizem’", Url = "#", Imagem = "/assets/noticias/noticia-7.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 8, Titulo = "Favoritismo, G. Jesus e até Kahn: seleção recupera a autoestima", Url = "#", Imagem = "/assets/noticias/noticia-8.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 9, Titulo = "‘O Brasil está mais perigoso’, diz técnico da Alemanha", Url = "#", Imagem = "/assets/noticias/noticia-9.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 10, Titulo = "Brasil vai bem sem Neymar; mas quem sai para dar lugar a ele?", Url = "#", Imagem = "/assets/noticias/noticia-10.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 11, Titulo = "Brasil enfrenta Alemanha em amistoso internacional", Url = "#", Imagem = "/assets/noticias/noticia-11.jpg", DescricaoImagem = "descrição completa da imagem" });
                retorno.Add(new Noticia() { Id = 12, Titulo = "Por onde andam os jogadores brasileiros que estiveram nos 7 a 1", Url = "#", Imagem = "/assets/noticias/noticia-12.jpg", DescricaoImagem = "descrição completa da imagem" });

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2));

                _memoryCache.Set(cacheKey, retorno, cacheEntryOptions);
            }

            return retorno;
        }


    }
}
