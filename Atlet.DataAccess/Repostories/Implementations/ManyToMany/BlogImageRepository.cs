using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;

namespace Atlet.DataAccess.Repostories.Implementations.ManyToMany;

public class BlogImageRepository:Repository<BlogImage>,IBlogImageRepository
{
    public BlogImageRepository(AppDbContext context):base(context)
{

}
}
