using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLAB.Domains.Models.Laboratoires;

namespace GLAB.App
{
    public interface ILabService
    {
        Task<List<Laboratory>> getLaboratories();

        Task removeLaboratory(string id);

        Task setLaboratory(Laboratory laboratory);

        Task createLaboratoiry(Laboratory laboratoiry);
    }

}
