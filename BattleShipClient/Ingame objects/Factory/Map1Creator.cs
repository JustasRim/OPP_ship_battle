class Map1Creator : Map
{
    // Factory Method implementation
    public override void CreateTiles()
    {
        for(int i = 0; i< 100;i++)
        {
            Tiles.Add(new GroundTile());
        }
    }
}