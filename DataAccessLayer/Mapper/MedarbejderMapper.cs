namespace DataAccessLayer.Mapper;
using DataAccessLayer.Model;
using DTO.Model;
using Medarbejder = DataAccessLayer.Model.Medarbejder;

internal class MedarbejderMapper
{
    public static DTO.Model.Medarbejder Map(Medarbejder medarbejder)
    {
        return new DTO.Model.Medarbejder(medarbejder.MedarbejderId, medarbejder.Initial, medarbejder.Navn, medarbejder.Cpr);
    }

    public static Medarbejder Map(DTO.Model.Medarbejder dtoMedarbejder)
    {
        return new Medarbejder
        {
            MedarbejderId = dtoMedarbejder.MedarbejderId,
            Initial = dtoMedarbejder.Initial,
            Navn = dtoMedarbejder.Navn,
            Cpr = dtoMedarbejder.Cpr
        };
    }
    
    internal static DTO.Model.AfdelingDetail AfdelingDetail(Afdeling afdeling)
    {
        DTO.Model.AfdelingDetail retur = new AfdelingDetail();
        retur.AfdelingNavn = afdeling.Navn;
        retur.medarbejderList = MedarbejderMapper.Map(afdeling.Medarbejder);
        return retur;
    }
    
    private static List<DTO.Model.Medarbejder> Map(List<Medarbejder> medarbejder)
    {
        List<DTO.Model.Medarbejder> retur = new List<DTO.Model.Medarbejder>();
        foreach (Medarbejder m in medarbejder)
        {
            retur.Add(MedarbejderMapper.Map(m));
        }

        return retur;
    }
    
    public static DTO.Model.AfdelingOverview Map(Afdeling afdeling)
    {
        return new DTO.Model.AfdelingOverview(afdeling.AfdelingId, afdeling.Nummer, afdeling.Navn);
    }
    
    public static Afdeling Map(DTO.Model.AfdelingOverview a)
    {
        return new Afdeling(a.AfdelingId, a.Navn, a.Nummer);
    }
}