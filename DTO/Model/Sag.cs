namespace DTO.Model;

public class Sag
{

    public Sag(int sagId, int sagNr, string overskrift, string beskrivelse)
    {
        SagId = sagId;
        SagNr = sagNr;
        Overskrift = overskrift;
        Beskrivelse = beskrivelse;
    }

    public Sag()
    {
    }
    
    public int AfdelingId { get; set; }
    public int SagId { get; set; }
    public int SagNr { get; set; }
    public string Overskrift { get; set; }
    public string Beskrivelse { get; set; }
}