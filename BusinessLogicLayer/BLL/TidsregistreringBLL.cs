using DataAccessLayer.Repository;
using DTO.Model;

namespace BusinessLogicLayer.BLL;

public class TidsregistreringBLL
{
    // MedarbejderRepository
    public Medarbejder GetMedarbejder(int id)
    {
        return MedarbejderRepository.GetMedarbejder(id);
    }

    public void AddMedarbejder(Medarbejder medarbejder)
    {
        MedarbejderRepository.AddMedarbejder(medarbejder);
    }

    public List<Medarbejder> GetAllMedarbejder()
    {
        return MedarbejderRepository.GetAllMedarbejder();
    }

    public void AddMedarbejderToAfdeling(int medarbejderId, int afdelingId)
    {
        MedarbejderRepository.AddMedarbejderToAfdeling(medarbejderId, afdelingId);
    }

    // AfdelingRepository
    public void AddAfdeling(AfdelingOverview afdeling)
    {
        AfdelingRepository.AddAfdeling(afdeling);
    }

    public List<AfdelingOverview> AllAfdeling()
    {
        return AfdelingRepository.AllAfdeling();
    }

    public AfdelingOverview GetAfdelinger(int id)
    {
        return AfdelingRepository.GetAfdelinger(id);
    }


    public void DeleteAfdeling(int id)
    {
        AfdelingRepository.DeleteAfdeling(id);
    }


    // SagRepository
    public Sag GetSag(int id)
    {
        return SagRepository.GetSag(id);
    }

    public void AddSag(Sag sag)
    {
        SagRepository.AddSag(sag);
    }

    public void EditSag(Sag sag)
    {
        SagRepository.EditSag(sag);
    }

    public List<Sag> GetAllSag()
    {
        return SagRepository.GetAllSag();
    }

    // TidsregistreringRepository
    public Tidsregistrering GetTidsregistrering(int id)
    {
        return TidsregistreringRepository.GetTidsregistrering(id);
    }

    public void AddTidsregistrering(Tidsregistrering tidsregistrering)
    {
        TidsregistreringRepository.AddTidsregistrering(tidsregistrering);
    }

    public void EditTidsregistrering(Tidsregistrering tidsregistrering)
    {
        TidsregistreringRepository.EditTidsregistrering(tidsregistrering);
    }

    public List<Tidsregistrering> GetAllTidsregistrering()
    {
        return TidsregistreringRepository.GetAllTidsregistrering();
    }

    public List<Tidsregistrering> GetTidsregistreringByMedarbejder(int medarbejderId)
    {
        return TidsregistreringRepository.GetTidsregistreringByMedarbejder(medarbejderId);
    }

    public List<Tidsregistrering> GetTidsregistreringBySag(int sagId)
    {
        return TidsregistreringRepository.GetTidsregistreringBySag(sagId);
    }
}