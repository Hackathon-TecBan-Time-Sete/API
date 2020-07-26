using HackTecBanTimeSete.Data;
using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Repository
{

    public interface IAvaliacaoRepository 
    {
        void SetAvaliacao(AvaliacaoDTO avaliacao);

    }

    public class AvaliacaoRepository : IAvaliacaoRepository
    {

        private readonly HackTecBanTimeSeteContext _ctx;

        public AvaliacaoRepository(HackTecBanTimeSeteContext ctx)
        {
            _ctx = ctx;

        }

        public void SetAvaliacao(AvaliacaoDTO avaliacao)
        {
            var ett = new Avaliacao()
            {
                CompleteName = avaliacao.CompleteName,
                Cpf = avaliacao.Cpf,
                DateBirth = avaliacao.DateBirth,
                Address = avaliacao.Address,
                ExperienceTime = avaliacao.ExperienceTime,
                Father = avaliacao.Father,
                Grade = avaliacao.Grade,
                Income = avaliacao.Income,
                LastHarvest = avaliacao.LastHarvest,
                Mother = avaliacao.Mother,
                NumberEmployees = avaliacao.NumberEmployees,
                NumberMachines = avaliacao.NumberMachines,
                Prevent = avaliacao.Prevent,
                SizeField = avaliacao.SizeField,
                Segment = avaliacao.Segment,
                Id = avaliacao.Id,               
            };

            _ctx.Avaliacoes.Add(ett);
        }


    }
}
