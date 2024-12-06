namespace DataAccessLayer.Model;

internal class Sag
{
    public Sag(int sagId, int sagNr, string overskrift, string beskrivelse, int afdelingId)
    {
        SagId = sagId;
        SagNr = sagNr;
        Overskrift = overskrift;
        Beskrivelse = beskrivelse;
        AfdelingId = afdelingId;
    }

    public Sag()
    {
    }

    public int SagId { get; set; }
    public int SagNr { get; set; }
    public String Overskrift { get; set; }
    public String Beskrivelse { get; set; }

    public Afdeling Afdeling { get; set; }

    public int AfdelingId { get; set; }

    public ICollection<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();
}