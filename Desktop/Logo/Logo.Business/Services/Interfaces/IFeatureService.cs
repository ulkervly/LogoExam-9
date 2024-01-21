using Logo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        Task CreateAsync(Feature feature);
        Task Updateasync(Feature feature);
        Task DeleteAsync(int id);
        Task<Feature> GetAsync(int id);
        Task<List<Feature>> GetAllAsync();

    }
}
