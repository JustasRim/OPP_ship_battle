using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Observer;
using System.Drawing;
using System.Windows.Forms;

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
    public Button Button { set; private get; }

    public WaterTile(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Update()
    {
        Button.BackColor = Color.Crimson;
    }
}