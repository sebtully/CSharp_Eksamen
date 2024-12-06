using DataAccessLayer.Model;
using DTO.Model;
using Sag = DataAccessLayer.Model.Sag;


namespace DataAccessLayer.Mapper;

internal class SagMapper
{
    public static DTO.Model.Sag Map(Sag sag)
    {
        return new DTO.Model.Sag(sag.SagId, sag.SagNr,sag.Overskrift, sag.Beskrivelse);
    }
    
    public static Sag Map(DTO.Model.Sag dtoSag)
    {
        return new Sag
        {
            SagNr = dtoSag.SagNr,    
            Overskrift = dtoSag.Overskrift,
            Beskrivelse = dtoSag.Beskrivelse,
            AfdelingId = dtoSag.AfdelingId
        };
    }
    
    internal static void Update(DTO.Model.Sag dtoSag, Sag dataSag)
    {
        dataSag.Overskrift = dtoSag.Overskrift;
        dataSag.Beskrivelse = dtoSag.Beskrivelse;
    }
}