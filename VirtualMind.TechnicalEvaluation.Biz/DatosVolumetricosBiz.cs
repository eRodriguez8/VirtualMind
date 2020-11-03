using VirtualMind.TechnicalEvaluation.Biz.Interface;
using VirtualMind.TechnicalEvaluation.Dal.Interface;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using log4net;
using System;
using System.Linq;

namespace VirtualMind.TechnicalEvaluation.Biz
{
    public class DatosVolumetricosBiz : BaseBusiness, IDatosVolumetricosBiz
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DatosVolumetricosBiz));

        public DatosVolumetricosBiz(IUOW_CDsEntities uOWCdsDB) : base(uOWCdsDB)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public DatosVolumetricos volumenDeArticulos(string valor, int? region)
        {
            try
            {
                var value = _uOWCdsDB.AUD_dVolumenDeArticulos(valor, region)
                .Select(x => new DatosVolumetricos
                {
                    Articulo = x.Articulo,
                    PosicionPicking = x.PosicionPicking,
                    Unidad = x.Unidad,
                    Caja = x.Caja,
                    UxB = x.UxB,
                    UMD = x.UMD,
                    CxH = x.CxH,
                    HxP = x.HxP
                }).ToList();

                return value.FirstOrDefault();
            }
            catch (Exception Exception)
            {
                Logger.Error(Exception);
                throw;
            }
        }
    }
}
