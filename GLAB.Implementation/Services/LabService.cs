using GLAB.App;
using GLAB.Domains.Models.Laboratoires;
using GLAB.infra.Storages;

namespace GLAB.Implementation.Services
{
    public class LabService : ILabService

    {
        private readonly ILabStorage labStorage;

        public LabService(ILabStorage labStorage)
        {
            this.labStorage = labStorage;
        }

        public async Task createLaboratoiry(Laboratory laboratory)
        {

            if (await laboratoryIsValid(laboratory))
            {
                await labStorage.insertLaboratory(laboratory);
            }
        }

        public async Task<List<Laboratory>> getLaboratories()
        {
            List<Laboratory> laboratories = await labStorage.selectLaboratories();
            return laboratories;
        }

        public async Task setLaboratory(Laboratory laboratoire)
        {
            if (await laboratoryIsValid(laboratoire))
            {
                await labStorage.updateLaboratory(laboratoire);
            }
        }
        public async Task removeLaboratory(string id)
        {
            if (await validateId(id))
            {
                await labStorage.deleteLaboratory(id);
            }
        }


        private async Task<bool> laboratoryIsValid(Laboratory laboratory)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(laboratory.LaboratoryId))
                    throw new ArgumentException("LaboratoryId cannot be null or whitespace.", nameof(laboratory.LaboratoryId));
                if (string.IsNullOrWhiteSpace(laboratory.Name))
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(laboratory.Name));
                if (string.IsNullOrWhiteSpace(laboratory.Acronyme))
                    throw new ArgumentException("Acronyme cannot be null or whitespace.", nameof(laboratory.Acronyme));
                if (string.IsNullOrWhiteSpace(laboratory.Adresse))
                    throw new ArgumentException("Adresse cannot be null or whitespace.", nameof(laboratory.Adresse));
                if (string.IsNullOrWhiteSpace(laboratory.Email))
                    throw new ArgumentException("Email cannot be null or whitespace.", nameof(laboratory.Email));

              /*  if (await LaboratoireExists(laboratory.LaboratoryId))
                    throw new InvalidOperationException($"Laboratoire with ID '{laboratory.LaboratoryId}' already exists.");
              */
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating laboratoire: {ex.Message}");
                return false;
            }
        }

        private static async Task<bool> validateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"Invalid ID: {id}", nameof(id));
            }

            return true;
        }

        }
    }

