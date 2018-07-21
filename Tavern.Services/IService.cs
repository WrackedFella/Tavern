using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tavern.Services
{
    public interface IService<TModel>
    {
		Task<IEnumerable<TModel>> Get();

		Task<TModel> Get(Guid id);

        Task<IEnumerable<TModel>> Search(TModel model);

        Task<TModel> Update(Guid id, TModel model);

        Task<IEnumerable<TModel>> Insert(params TModel[] models);

        Task Delete(Guid id);
    }
}
