

namespace Atlet.DataAccess.Repostories.Implementations.Blogs;


public class BlogRepository:Repository<Blog>,IBlogRepository
{
	public BlogRepository(AppDbContext context) : base(context)
    {

    }
}
