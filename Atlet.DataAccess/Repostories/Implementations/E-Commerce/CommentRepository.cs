namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class CommentRepository:Repository<Comment>,ICommentRepository
{
	public CommentRepository(AppDbContext context) : base(context)
    {

    }
}
