﻿using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Blogs.BlogDtos;

public class BlogPutDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int BlogCategoryId { get; init; }
    public ICollection<int> BlogImageIds { get; init; } = new List<int>();
}
