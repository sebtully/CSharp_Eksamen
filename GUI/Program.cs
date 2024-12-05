using BusinessLogicLayer.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        TidsregistreringBLL bll = new TidsregistreringBLL();

        AfdelingOverview ao = new AfdelingOverview()
        {
            AfdelingId = 1,
            Nummer = 11,
            Navn = "IT-afdelingen"
        };
        bll.AddAfdeling(ao);

        Medarbejder m = new Medarbejder()
        {
            Initial = "AM",
            Navn = "Abukar Moallin",
            Cpr = "1234567890",
            AfdelingId = 1
        };
        
        
        
        bll.AddMedarbejder(m);

        List<Medarbejder> medarbejderList = bll.GetAllMedarbejder();

        foreach (var medarbejder in medarbejderList)
        {
            Console.WriteLine($"Initial: {medarbejder.Initial}, Navn: {medarbejder.Navn}, Cpr: {medarbejder.Cpr}, Afdeling: {medarbejder.AfdelingId}");
        }
    }
}