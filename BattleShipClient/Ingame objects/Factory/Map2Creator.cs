class Map2Creator : Map
{
    // Factory Method implementation
    public override void CreateTiles()
    {
        for(int i = 0; i< 100;i++)
        {
            if(i % 10 < 5){
                Tiles.Add(new GroundTile());
            }
            else
            {
                Tiles.Add(new WaterTile());
            }
        }
    }
}