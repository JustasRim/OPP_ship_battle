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
                 Tiles.Add(new RockTile(i, j));
                else if(j<5)
                 Tiles.Add(new GroundTile(i, j));
                else
                 Tiles.Add(new WaterTile(i, j));
            }
        }
    }
    public override ITile GetTile(int x, int y)
    {
        return (Tiles[x * 10 + y]);
    }
}