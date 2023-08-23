﻿using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Blogs.ManyToMany;

public class BlogImage:BaseEntity,IEntity
{
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
