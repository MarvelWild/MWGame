using System.Collections.Generic;

namespace MwGame;

// todo: draw sort

public class Entities {

    public List<IEntity> List = new List<IEntity>();

    public void Add(IEntity entity)
    {
        List.Add(entity);
    }

}