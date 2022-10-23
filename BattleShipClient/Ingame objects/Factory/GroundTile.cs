class GroundTile : ITile
{
    byte ITile.Red
    {
        get { return 0; }
        set { }
    }
    byte ITile.Green
    {
        get { return 100; }
        set { }
    }
    byte ITile.Blue
    {
        get { return 0; }
        set { }
    }
    public int X { get; set; }
    public int Y { get; set; }

    public GroundTile(int x, int y)
    {
        X = x;
        Y = y;
    }
}