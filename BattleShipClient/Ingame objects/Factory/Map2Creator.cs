using BattleShipClient.Ingame_objects.FlyWeight;
using System.Drawing;

public class Map2Creator : Map
{
    // Factory Method implementation
    public override void CreateTiles()
    { 
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j ==5)
                 Tiles.Add(new Tile("rock", Color.Gray, TileImages.SetGray, i, j));
                else if(j<5)
                 Tiles.Add(new Tile("ground", Color.DarkGreen, TileImages.SetGreen, i, j));
                else
                 Tiles.Add(new Tile("water", Color.LightBlue, TileImages.SetBlue, i, j));
            }
        }
    }
    public override ITile GetTile(int x, int y)
    {
        return (Tiles[x * 10 + y]);
        //var iterator = Tiles.createIterator();
        //for (int i = 0; i < x * 10 + y; i++)
        //{
        //    iterator.getNext();
        //}
        //return iterator.getNext();
    }
}