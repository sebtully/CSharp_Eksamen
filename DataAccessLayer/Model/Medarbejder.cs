namespace DataAccessLayer.Model;

internal class Medarbejder
{
    public Medarbejder(int medarbejderId, string initial, string navn, string cpr, int afdelingId)
    {
        MedarbejderId = medarbejderId;
        Initial = initial;
        Navn = navn;
        Cpr = cpr;
        AfdelingId = afdelingId;
    }

    public Medarbejder()
    {
    }

    public int MedarbejderId { get; set; }
    public String Initial { get; set; }
    public String Navn { get; set; }
    public String Cpr { get; set; }

    public Afdeling Afdeling { get; set; }

    public List<Afdeling> Afdelinger { get; set; } = new List<Afdeling>();

    public List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

    public int AfdelingId { get; set; }
}