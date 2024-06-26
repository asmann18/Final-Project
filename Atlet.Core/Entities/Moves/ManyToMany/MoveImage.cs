﻿using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Moves.ManyToMany;

public class MoveImage:BaseEntity,IEntity
{
    public MoveImage()
    {
        
    }
    public MoveImage(int moveId,int imageId)
    {
        MoveId = moveId;
        ImageId = imageId;
    }
    public int MoveId { get; set; }
    public Move Blog { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}
