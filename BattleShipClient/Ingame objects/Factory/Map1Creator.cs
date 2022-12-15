public class Map1Creator : Map
{
    // Factory Method implementation
    public override void CreateTiles()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Tiles.Add(new GroundTile(i, j));
            }
        }
    }
    public override ITile GetTile(int x, int y)
    {
        var iterator = Tiles.createIterator();
        for (int i = 0; i < x * 10 + y; i++)
        {
            iterator.getNext();
        }
        return iterator.getNext();
    }
}