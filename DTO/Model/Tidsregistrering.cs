namespace DTO.Model;

public class Tidsregistrering
{
    public Tidsregistrering(int tidsregistreringId, DateTime startTid, DateTime slutTid)
    {   
        TidsregistreringId = tidsregistreringId;
        StartTid = startTid;
        SlutTid = slutTid;
    }
    
    public Tidsregistrering()
    {
    }
    
    public int AfdelingId { get; set; }
    public int SagId { get; set; }
    public int MedarbejderId { get; set; }
    public int TidsregistreringId { get; set; }
    public DateTime StartTid { get; set; }
    public DateTime SlutTid { get; set; }
    
    
}