using System;

namespace Tavern.Domain.Core
{
    public interface IDomainObject
    {
        Guid GetId();
    }
}
