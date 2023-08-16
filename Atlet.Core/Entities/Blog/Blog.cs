using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Blog.ManyToMany;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Core.Entities.Blog;

public class Blog:BaseAuditableEntity,IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogCategoryId { get; set; }
    public BlogCategory BlogCategory { get; set; }
    public ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();



}
