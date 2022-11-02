using BattleShipClient.Ingame_objects;
using System.Drawing;
using System.Windows.Forms;

class GroundTile : ITile
{
    public Color Color
    {
        get { return Color.DarkGreen; }
        set { }
    }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasUnit { get => Unit != null; }
    public Unit Unit { get; set; }

    public Button Button { set; private get; }

    public GroundTile(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Update()
    {
        Button.BackColor = Color.Crimson;
    }
}