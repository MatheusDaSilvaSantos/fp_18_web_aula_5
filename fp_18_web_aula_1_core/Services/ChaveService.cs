using fp_18_web_aula_1_core.Models;
using fp_web_aula_1_core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fp_18_web_aula_1_core.Services
{
    public class ChaveService : IChaveService
    {
        public List<Chave> List()
        {
            var chaveA = new Chave()
            {
                Nome = "Grupo A",
                Times = new List<Time>()
                {
                    new Time(){Id=1, Nome="Russia", Bandeira="RUS"},
                    new Time(){Id=2, Nome="Saudi Arabia", Bandeira="KSA"},
                    new Time(){Id=3, Nome="Egypt", Bandeira="EGY"},
                    new Time(){Id=4, Nome="Uruguay", Bandeira="URU"},
                }
            };

            var chaveB = new Chave()
            {
                Nome = "Grupo B",
                Times = new List<Time>()
                {
                    new Time(){Id=5, Nome="Portugal", Bandeira="POR"},
                    new Time(){Id=6, Nome="Spain", Bandeira="ESP"},
                    new Time(){Id=7, Nome="Morocco", Bandeira="MAR"},
                    new Time(){Id=8, Nome="IR Iran", Bandeira="IRN"},
                }
            };
            var chaveC = new Chave()
            {
                Nome = "Grupo C",
                Times = new List<Time>()
                {
                    new Time(){Id=9, Nome="France", Bandeira="FRA"},
                    new Time(){Id=10, Nome="Australia", Bandeira="AUS"},
                    new Time(){Id=11, Nome="Peru", Bandeira="PER"},
                    new Time(){Id=12, Nome="Denmark", Bandeira="DEN"},
                }
            };
            var chaveD = new Chave()
            {
                Nome = "Grupo D",
                Times = new List<Time>()
                {
                    new Time(){Id=13, Nome="Argentina", Bandeira="ARG"},
                    new Time(){Id=14, Nome="Iceland", Bandeira="ISL"},
                    new Time(){Id=15, Nome="Croatia", Bandeira="CRO"},
                    new Time(){Id=16, Nome="Nigeria", Bandeira="NGA"},
                }
            };
            var chaveE = new Chave()
            {
                Nome = "Grupo E",
                Times = new List<Time>()
                {
                    new Time(){Id=17, Nome="Brazil", Bandeira="BRA"},
                    new Time(){Id=18, Nome="Switzerland", Bandeira="SUI"},
                    new Time(){Id=19, Nome="Costa Rica", Bandeira="CRC"},
                    new Time(){Id=20, Nome="Serbia", Bandeira="SRB"},
                }
            };
            var chaveF = new Chave()
            {
                Nome = "Grupo F",
                Times = new List<Time>()
                {
                    new Time(){Id=21, Nome="Germany", Bandeira="GER"},
                    new Time(){Id=22, Nome="Mexico", Bandeira="MEX"},
                    new Time(){Id=23, Nome="Sweden", Bandeira="SWE"},
                    new Time(){Id=24, Nome="Korea Republic", Bandeira="KOR"},
                }
            };
            var chaveG = new Chave()
            {
                Nome = "Grupo G",
                Times = new List<Time>()
                {
                    new Time(){Id=25, Nome="Belgium", Bandeira="BEL"},
                    new Time(){Id=26, Nome="Panama", Bandeira="PAN"},
                    new Time(){Id=27, Nome="Tunisia", Bandeira="TUN"},
                    new Time(){Id=28, Nome="England", Bandeira="ENG"},
                }
            };
            var chaveH = new Chave()
            {
                Nome = "Grupo H",
                Times = new List<Time>()
                {
                    new Time(){Id=29, Nome="Poland", Bandeira="POL"},
                    new Time(){Id=30, Nome="Senegal", Bandeira="SEN"},
                    new Time(){Id=31, Nome="Colombia", Bandeira="COL"},
                    new Time(){Id=32, Nome="Japan", Bandeira="JPN"},
                }
            };

            var chaves = new List<Chave>();

            chaves.Add(chaveA);
            chaves.Add(chaveB);
            chaves.Add(chaveC);
            chaves.Add(chaveD);
            chaves.Add(chaveE);
            chaves.Add(chaveF);
            chaves.Add(chaveG);
            chaves.Add(chaveH);

            return chaves;
        }
    }
}
