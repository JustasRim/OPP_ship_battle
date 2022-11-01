using BattleShipClient.Ingame_objects;
using System.Drawing;
class WaterTile : ITile
{
    public Color Color
    {
        get { return Color.LightCyan; }
        set { }
    }
    public bool HasUnit { get => Unit != null; }
    public int X { get; set; }
    public int Y { get; set; }
    public Unit Unit { get; set; }

    public WaterTile(int x, int y)
    {
        X = x;
        Y = y;
    }
}