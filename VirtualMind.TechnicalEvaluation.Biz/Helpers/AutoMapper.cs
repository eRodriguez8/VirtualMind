using AutoMapper;
using System.Collections.Generic;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Biz.Helpers
{
    public static class AutoMapper
    {
        private static IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserInfo, UserInformation>();
            cfg.CreateMap<UserInformation, UserInfo>();
            cfg.CreateMap<UserTransac, UserTransaction>();
            cfg.CreateMap<UserTransaction, UserTransac>();
        }).CreateMapper();

        public static List<UserInfo> ToDomain(this IEnumerable<UserInformation> entity)
        {
            return _mapper.Map<List<UserInfo>>(entity);
        }
        public static List<UserTransac> ToDomain(this IEnumerable<UserTransaction> entity)
        {
            return _mapper.Map<List<UserTransac>>(entity);
        }

        public static UserInformation ToEntity(this UserInfo entity)
        {
            return _mapper.Map<UserInformation>(entity);
        }
        public static UserTransaction ToEntity(this UserTransac entity)
        {
            return _mapper.Map<UserTransaction>(entity);
        }
    }
}
