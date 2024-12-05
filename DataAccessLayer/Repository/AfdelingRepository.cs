using DataAccessLayer.Context;
using DataAccessLayer.Mapper;
using DTO.Model;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class AfdelingRepository
    {
        public static void AddAfdeling(DTO.Model.AfdelingOverview afdeling)
        {
            using (TidsregistreringContext context = new TidsregistreringContext())
            {
                Afdeling a = MedarbejderMapper.Map(afdeling);
                context.Afdeling.Add(a);
                context.SaveChanges();
            }
        }

        public static List<AfdelingOverview> AllAfdeling()
        {
            List<AfdelingOverview> retur = new List<AfdelingOverview>();
            using (TidsregistreringContext context = new TidsregistreringContext())
            {
                foreach (Model.Afdeling a in context.Afdeling)
                {
                    retur.Add(MedarbejderMapper.Map(a));
                }
            }

            return retur;
        }

        public static AfdelingOverview GetAfdelinger(int id)
        {
            using (TidsregistreringContext context = new TidsregistreringContext())
            {
                return MedarbejderMapper.Map(context.Afdeling.Find(id));
            }
        }

        public static void DeleteAfdeling(int id)
        {
            using (TidsregistreringContext context = new TidsregistreringContext())
            {
                Model.Afdeling afdeling = context.Afdeling.Find(id);
                context.Afdeling.Remove(afdeling);
                context.SaveChanges();
            }
        }
    }
}