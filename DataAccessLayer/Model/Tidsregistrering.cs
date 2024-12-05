namespace DataAccessLayer.Model;

internal class Tidsregistrering
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
    
    
    public int TidsregistreringId { get; set; }
    public DateTime StartTid { get; set; }
    public DateTime SlutTid{ get; set; }
    
    public int SagId { get; set; }
    
    public int SagNr { get; set; }

    public Sag Sag { get; set; }

    public int MedarbejderId { get; set; }

    public Medarbejder Medarbejder { get; set; }
}