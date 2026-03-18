using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using System.Text.Json;


namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class KYCService : IKYCService
    {
        private readonly IKYCRepository _repository;

        public KYCService(IKYCRepository repository)
        {
            _repository = repository;
        }

        public async Task<KYCProfile> GetByIdAsync(long id) => await _repository.GetByIdAsync(id);

        public async Task<List<KYCProfile>> SearchAsync(string query) => await _repository.SearchAsync(query);

        public async Task<KYCProfile> CreateAsync(long customerId, List<IFormFile> documents, List<string> requiredDocs)
        {
            var docMappings = new List<object>();

            for (int i = 0; i < requiredDocs.Count; i++)
            {
                var docType = requiredDocs[i];
                var file = documents.ElementAtOrDefault(i);

                if (file != null && file.Length > 0)
                {
                    var path = Path.Combine("wwwroot/uploads", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    docMappings.Add(new { Type = docType, FilePath = "/uploads/" + file.FileName });
                }
            }

            var profile = new KYCProfile
            {
                CustomerId = customerId,
                DocumentRefsJSON = JsonSerializer.Serialize(docMappings),
            };

            return await _repository.AddAsync(profile);
        }

        public async Task<KYCProfile> UpdateAsync(long id, List<IFormFile> documents, List<string> requiredDocs)
        {
            var profile = await _repository.GetByIdAsync(id);
            if (profile == null) return null;

            var docMappings = new List<object>();

            for (int i = 0; i < requiredDocs.Count; i++)
            {
                var docType = requiredDocs[i];
                var file = documents.ElementAtOrDefault(i);

                if (file != null && file.Length > 0)
                {
                    var path = Path.Combine("wwwroot/uploads", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    docMappings.Add(new { Type = docType, FilePath = "/uploads/" + file.FileName });
                }
            }

            if (docMappings.Any())
            {
                profile.DocumentRefsJSON = JsonSerializer.Serialize(docMappings);
            }

            return await _repository.UpdateAsync(profile);
        }

        public async Task<KYCProfile> PatchAsync(long id, KYCProfile partialProfile)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

         

            if (!string.IsNullOrEmpty(partialProfile.DocumentRefsJSON))
                existing.DocumentRefsJSON = partialProfile.DocumentRefsJSON;

            return await _repository.UpdateAsync(existing);
        }
    }
}

