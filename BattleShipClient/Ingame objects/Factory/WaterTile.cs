using System.Drawing;
class WaterTile : ITile
{
    public Color Color
    {
        get { return Color.LightCyan; }
        set { }
    }
    public bool HasUnit { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public WaterTile(int x, int y)
    {
        X = x;
        Y = y;
        HasUnit = false;
    }
}