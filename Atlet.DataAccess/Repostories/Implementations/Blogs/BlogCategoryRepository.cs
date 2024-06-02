namespace Atlet.DataAccess.Repostories.Implementations.Blogs;

public class BlogCategoryRepository:Repository<BlogCategory>,IBlogCategoryRepository
{
	public BlogCategoryRepository(AppDbContext context) : base(context) { }
}
