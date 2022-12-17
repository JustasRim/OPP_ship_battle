using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.FlyWeight;
using System.Drawing;
using System.Windows.Forms;

public class RockTile : ITileOld
{
    public Image TileImage { get; set; }
    public Color TileColor { get; set; }

    public Image UpdateImage { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasUnit { get => Unit != null; }
    public Unit Unit { get; set; }
    public Button Button { set; private get; }

    public RockTile(int x, int y, Image baseTile, Image afterUpdate)
    {
        X = x;
        Y = y;
        TileImage = baseTile;
        UpdateImage = afterUpdate;
        TileColor = Color.Gray;
    }

    public void Update()
    {
        Button.Image = UpdateImage;
    }
}