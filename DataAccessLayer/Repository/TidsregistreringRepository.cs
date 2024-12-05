using DataAccessLayer.Context;
using DataAccessLayer.Mapper;
using DTO.Model;

namespace DataAccessLayer.Repository;

public class TidsregistreringRepository
{
    
        public static void AddTidsregistrering(Tidsregistrering tidsregistrering)
        {
            using (var context = new TidsregistreringContext())
            {
                var entity = TidsregistreringMapper.Map(tidsregistrering);
                context.Tidsregistrering.Add(entity);
                context.SaveChanges();
            }
        }
        
    public static Tidsregistrering GetTidsregistrering(int id)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return TidsregistreringMapper.Map(context.Tidsregistrering.Find(id));
        }
    }
    
    public static List<Tidsregistrering> GetAllTidsregistrering()
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return context.Tidsregistrering
                .Select(t => TidsregistreringMapper.Map(t))
                .ToList();
        }
    }

    public static void EditTidsregistrering(Tidsregistrering tidsregistrering)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            DataAccessLayer.Model.Tidsregistrering dataTidsregistrering =
                context.Tidsregistrering.Find(tidsregistrering.TidsregistreringId);
            TidsregistreringMapper.Update(tidsregistrering, dataTidsregistrering);
            context.SaveChanges();
        }
    }

    public static void DeleteTidsregistrering(int id)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            DataAccessLayer.Model.Tidsregistrering tidsregistrering = context.Tidsregistrering.Find(id);
            context.Tidsregistrering.Remove(tidsregistrering);
            context.SaveChanges();
        }
    }

    public static List<Tidsregistrering> GetTidsregistreringByMedarbejder(int medarbejderId)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return context.Tidsregistrering
                .Where(t => t.MedarbejderId == medarbejderId)
                .Select(t => TidsregistreringMapper.Map(t))
                .ToList();
        }
    }

    public static List<Tidsregistrering> GetTidsregistreringBySag(int sagId)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return context.Tidsregistrering
                .Where(t => t.SagId == sagId)
                .Select(t => TidsregistreringMapper.Map(t))
                .ToList();
        }
    }
    
    
}