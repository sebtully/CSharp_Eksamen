using DataAccessLayer.Model;
using DataAccessLayer.Context;
using DataAccessLayer.Mapper;
using DataAccessLayer.Model;
using DTO.Model;
using Microsoft.EntityFrameworkCore;
using Medarbejder = DTO.Model.Medarbejder;
using Tidsregistrering = DTO.Model.Tidsregistrering;


namespace DataAccessLayer.Repository;

public class MedarbejderRepository
{
    public static Medarbejder GetMedarbejder(int id)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return MedarbejderMapper.Map(context.Medarbejder.Find(id));
        }
    }

    public static void AddMedarbejder(DTO.Model.Medarbejder medarbejder)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            DataAccessLayer.Model.Medarbejder med = MedarbejderMapper.Map(medarbejder);
            context.Medarbejder.Add(med);
            context.SaveChanges();
        }
    }


    public static List<Medarbejder> GetAllMedarbejder()
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return context.Medarbejder
                .Select(m => MedarbejderMapper.Map(m))
                .ToList();
        }
    }

    public static void AddMedarbejderToAfdeling(int medarbejderId, int afdelingId)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            Model.Medarbejder medarbejder = context.Medarbejder.Where(a => a.AfdelingId == afdelingId).FirstOrDefault();
            medarbejder.AfdelingId = afdelingId;
            context.SaveChanges();
        }
    }
}