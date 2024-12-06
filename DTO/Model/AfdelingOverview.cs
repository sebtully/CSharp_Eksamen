namespace DTO.Model;

public class AfdelingOverview
{
    public int AfdelingId { get; set; }
    public int Nummer { get; set; }
    public string Navn { get; set; }
    
    public AfdelingOverview(int afdelingId, int nummer, string navn)
    {
        AfdelingId = afdelingId;
        Nummer = nummer;
        Navn = navn;
    }
    
    public AfdelingOverview()
    {
    }
}