using DTO.Model;

namespace DataAccessLayer.Model;

internal class Afdeling
{
    public Afdeling(int afdelingId, string navn, int nummer)
    {
        AfdelingId = afdelingId;
        Navn = navn;
        Nummer = nummer;
    }


    public Afdeling()
    {
    }

    public int AfdelingId { get; set; }
    public int Nummer { get; set; }
    public String Navn { get; set; }

    public List<Medarbejder> Medarbejder { get; set; } = new List<Medarbejder>();

    public List<Sag> Sager { get; set; } = new List<Sag>();
}