namespace DataAccessLayer.Model;

internal class Sag
{
    public Sag(int sagId, int sagsNr, string overskrift, string beskrivelse, int afdelingId)
    {
        SagId = sagId;
        SagsNr = sagsNr;
        Overskrift = overskrift;
        Beskrivelse = beskrivelse;
        AfdelingId = afdelingId;
    }

    public Sag()
    {
    }

    public int SagId { get; set; }
    public int SagsNr { get; set; }
    public String Overskrift { get; set; }
    public String Beskrivelse { get; set; }

    public Afdeling Afdeling { get; set; }

    public int AfdelingId { get; set; }

    public ICollection<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();
}