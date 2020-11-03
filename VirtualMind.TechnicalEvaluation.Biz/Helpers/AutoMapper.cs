using AutoMapper;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using System.Collections.Generic;

namespace VirtualMind.TechnicalEvaluation.Biz.Helpers
{
    public static class AutoMapper
    {
        private static IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ConvertionDetail, AUD_dContenedores>();
            cfg.CreateMap<AUD_dContenedores, ConvertionDetail>();
        }).CreateMapper();

        public static List<ConvertionDetail> ToDomain(this IEnumerable<AUD_dContenedores> entity)
        {
            return _mapper.Map<List<ConvertionDetail>>(entity);
        }
        public static AUD_dContenedores ToEntity(this ConvertionDetail entity)
        {
            return _mapper.Map<AUD_dContenedores>(entity);
        }
    }
}
