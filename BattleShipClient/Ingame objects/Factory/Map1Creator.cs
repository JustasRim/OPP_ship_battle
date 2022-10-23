class Map1Creator : Map
{
    // Factory Method implementation
    public override void CreateTiles()
    {
        for(int i = 0; i< 10;i++)
        {
            for (int j = 0; j < 10; i++)
            {
                Tiles.Add(new GroundTile(i, j));
            }
        }
    }
}