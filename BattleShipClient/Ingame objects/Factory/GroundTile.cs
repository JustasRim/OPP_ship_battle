using BattleShipClient.Ingame_objects;
using System.Drawing;
using System.Windows.Forms;

public class GroundTile : ITileOld
{
    public Image TileImage { get; set; }
    public Color TileColor { get; set; }

    public Image UpdateImage { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasUnit { get => Unit != null; }
    public Unit Unit { get; set; }

    public Button Button { set; private get; }

    public GroundTile(int x, int y, Image baseTile, Image afterUpdate)
    {
        X = x;
        Y = y;
        TileImage = baseTile;
        UpdateImage = afterUpdate;
        TileColor = Color.DarkGreen;
    }

    public void Update()
    {
        Button.Image = UpdateImage;
    }
}