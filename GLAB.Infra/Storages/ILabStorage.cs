using GLAB.Domains.Models.Laboratoires;

namespace GLAB.infra.Storages
{
    public interface ILabStorage
    {

        Task<List<Laboratory>> selectLaboratories();

        Task insertLaboratory(Laboratory laboratory);

        Task updateLaboratory(Laboratory laboratory);

        Task deleteLaboratory(String id);

    }
}
