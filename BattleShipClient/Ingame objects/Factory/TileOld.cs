using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.FlyWeight;
using BattleShipClient.Ingame_objects.Observer;
using System.Drawing;
using System.Windows.Forms;

public interface ITileOld : ISubscriber
{
    Button Button { set; }
    Color TileColor { set; get; }
    Image TileImage { get; set; }
    Image UpdateImage { get; set; }
    int X { get; set; }
    int Y { get; set; }
    bool HasUnit { get; }
    Unit Unit { get; set; }
}