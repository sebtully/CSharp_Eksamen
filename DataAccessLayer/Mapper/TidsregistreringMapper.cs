using DTO.Model;
using DataAccessLayer.Model;
using Tidsregistrering = DataAccessLayer.Model.Tidsregistrering;


namespace DataAccessLayer.Mapper;

internal class TidsregistreringMapper
{
    public static DTO.Model.Tidsregistrering Map(Tidsregistrering tidsregistrering)
    {
        return new DTO.Model.Tidsregistrering(tidsregistrering.TidsregistreringId, tidsregistrering.StartTid, tidsregistrering.SlutTid);
    }
    
    public static Tidsregistrering Map(DTO.Model.Tidsregistrering dtoTidsregistrering)
    {
        return new Tidsregistrering
        {
            StartTid = dtoTidsregistrering.StartTid,
            SlutTid = dtoTidsregistrering.SlutTid,
            SagId = dtoTidsregistrering.SagId,
            MedarbejderId = dtoTidsregistrering.MedarbejderId
        };
    }
    
    internal static void Update(DTO.Model.Tidsregistrering dtoTidsregistrering, Tidsregistrering dataTidsregistrering)
    {
        dataTidsregistrering.StartTid = dtoTidsregistrering.StartTid;
        dataTidsregistrering.SlutTid = dtoTidsregistrering.SlutTid;
        dataTidsregistrering.SagId = dtoTidsregistrering.SagId;
        dataTidsregistrering.MedarbejderId = dtoTidsregistrering.MedarbejderId;
    }
    
    
    
}