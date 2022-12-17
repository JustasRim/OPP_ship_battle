using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Observer;
using System.Drawing;
using System.Windows.Forms;

public class WaterTile : ITileOld
{
    public Image TileImage { get; set; }
    public Image UpdateImage { get; set; }
    public Color TileColor { get; set; }
    public bool HasUnit { get => Unit != null; }
    public int X { get; set; }
    public int Y { get; set; }
    public Unit Unit { get; set; }
    public Button Button { set; private get; }

    public WaterTile(int x, int y, Image baseTile, Image afterUpdate)
    {
        X = x;
        Y = y;
        TileImage = baseTile;
        UpdateImage = afterUpdate;
        TileColor = Color.LightBlue;
    }

    public void Update()
    {
        Button.Image = UpdateImage;
    }
}