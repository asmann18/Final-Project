using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Blogs;

public class Blog:BaseAuditableEntity,IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogCategoryId { get; set; }
    public BlogCategory BlogCategory { get; set; }
    public ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();



}
