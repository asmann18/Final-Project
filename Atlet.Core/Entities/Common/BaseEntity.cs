using Atlet.Core.Abstract.Interfaces;

namespace Atlet.Core.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
        public bool IsDeleted { get; set; }

}
