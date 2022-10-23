using System.Collections.Generic;
abstract class Map
{
    private List<ITile> _tiles = new List<ITile>();
    public Map()
    {
        this.CreateTiles();
    }
    public List<ITile> Tiles
    {
        get { return _tiles; }
    }
    // Factory Method
    public abstract void CreateTiles();
}