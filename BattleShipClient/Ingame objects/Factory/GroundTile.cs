using System.Drawing;

class GroundTile : ITile
{
    public Color Color
    {
        get { return Color.DarkGreen; }
        set { }
    }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasEnemy { get; set; }
    public GroundTile(int x, int y)
    {
        X = x;
        Y = y;
        HasEnemy = false;
    }
}