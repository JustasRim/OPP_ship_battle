using BattleShipClient.Ingame_objects.Iterator;
using System.Collections.Generic;
public abstract class Map
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

    public void ResetTiles()
    {
        _tiles.ForEach(q => q.Unit = null);
    }

    // Factory Method
    public abstract void CreateTiles();

    public abstract ITile GetTile(int x, int y);
}
//public abstract class Map
//{
//    ListCollection<ITile> _tiles = new ListCollection<ITile>();
//    public Map()
//    {
//        this.CreateTiles();
//    }
//    public ListCollection<ITile> Tiles
//    {
//        get { return _tiles; }
//    }

//    public void ResetTiles()
//    {
//        var iterator = _tiles.createIterator();
//        while(iterator.hasMore())
//        {
//            var tile = iterator.getNext();
//            tile.Unit = null;
//        }
//    }

//    // Factory Method
//    public abstract void CreateTiles();

//    public abstract ITile GetTile(int x, int y);
//}