using DataAccessLayer.Context;
using DataAccessLayer.Mapper;
using DataAccessLayer.Model;
using DTO.Model;
using Microsoft.EntityFrameworkCore;
using Sag = DataAccessLayer.Model.Sag;

namespace DataAccessLayer.Repository;

public class SagRepository
{
    public static DTO.Model.Sag GetSag(int sagId)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return SagMapper.Map(context.Sag.Find(sagId));
        }
    }

    public static void AddSag(DTO.Model.Sag sag)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            var s = SagMapper.Map(sag);
            context.Sag.Add(s);
            context.SaveChanges();
        }
    }

    public static void EditSag(DTO.Model.Sag sag)
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            Model.Sag dataSag = context.Sag.Find(sag.SagId);
            SagMapper.Update(sag, dataSag);
            context.SaveChanges();
        }
    }
    
    public static List<DTO.Model.Sag> GetAllSag()
    {
        using (TidsregistreringContext context = new TidsregistreringContext())
        {
            return context.Sag.Select(s => SagMapper.Map(s)).ToList();
        }
    }
}