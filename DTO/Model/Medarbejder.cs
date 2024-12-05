using System.ComponentModel.DataAnnotations;

namespace DTO.Model;

public class Medarbejder
{
    public Medarbejder(int medarbejderId, string initial, string navn, string cpr)
    {
        MedarbejderId = medarbejderId;
        Initial = initial;
        Navn = navn;
        Cpr = cpr;
    }

    public Medarbejder()
    {
    }

    [Required] public int MedarbejderId { get; set; }
    public string Initial { get; set; }

    public string Navn { get; set; }

    public string Cpr { get; set; }
    public AfdelingOverview Afdeling { get; set; }
    public int AfdelingId { get; set; }
}