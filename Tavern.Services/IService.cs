using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tavern.Services
{
    public interface IService<TModel>
    {
        Task<TModel> Get(Guid id);

        Task<IEnumerable<TModel>> List();

        Task<IEnumerable<TModel>> Search(TModel model);

        Task<TModel> Update(TModel model);

        Task<IEnumerable<TModel>> Insert(params TModel[] models);

        Task Delete(int id);
    }
}
