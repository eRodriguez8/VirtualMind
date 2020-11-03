using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Biz.Interface
{
    public interface IDatosVolumetricosBiz
    {
        DatosVolumetricos volumenDeArticulos(string valor, int? region);
    }
}
