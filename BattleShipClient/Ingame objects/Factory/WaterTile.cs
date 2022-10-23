class WaterTile : ITile
{
    public byte Red
    {
        get { return 0; }
        set { }
    }
    public byte Green
    {
        get { return 0; }
        set { }
    }
    public byte Blue
    {
        get { return 255; }
        set { }
    }
    public int X { get; set; }
    public int Y { get; set; }

    public WaterTile(int x, int y)
    {
        X = x;
        Y = y;
    }
}