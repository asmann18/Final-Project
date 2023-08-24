using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Blogs;

public class BlogCategory:BaseEntity,IEntity
{
    public string Name { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

}
