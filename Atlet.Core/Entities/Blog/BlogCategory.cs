using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Core.Entities.Blog;

public class BlogCategory:BaseEntity,IEntity
{
    public string Name { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

}
