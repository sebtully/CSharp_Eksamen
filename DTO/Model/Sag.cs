namespace DTO.Model;

public class Sag
{
    public Sag(int sagId, int sagsNr, string overskrift, string beskrivelse)
    {
        SagId = sagId;
        SagsNr = sagsNr;
        Overskrift = overskrift;
        Beskrivelse = beskrivelse;
    }

    public Sag()
    {
    }
    
    public int AfdelingId { get; set; }
    public int SagId { get; set; }
    public int SagsNr { get; set; }
    public string Overskrift { get; set; }
    public string Beskrivelse { get; set; }
}