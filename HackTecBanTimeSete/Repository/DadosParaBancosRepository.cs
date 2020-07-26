using HackTecBanTimeSete.Data;
using HackTecBanTimeSete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Repository
{
    public interface IDadosParaBancosRepository 
    {
        List<Documento> GetSicorDeUsuariosToList();
        List<Avaliacao> GetDadosAvaliacaoUsuariosToList();
    }

    public class DadosParaBancosRepository: IDadosParaBancosRepository
    {

        private readonly  HackTecBanTimeSeteContext _ctx;

        public DadosParaBancosRepository(HackTecBanTimeSeteContext ctx)
        {
            _ctx = ctx;
        }

        public List<Documento> GetSicorDeUsuariosToList() 
        {
            var lst =  _ctx.Documentos.ToList();
            return lst;
        }

        public List<Avaliacao> GetDadosAvaliacaoUsuariosToList()
        {
            var lst = _ctx.Avaliacoes.ToList();
            return lst;
        }


    }
}
