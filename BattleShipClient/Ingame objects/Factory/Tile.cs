using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.FlyWeight;
using BattleShipClient.Ingame_objects.Observer;
using System.Drawing;
using System.Windows.Forms;

public interface ITile : ISubscriber
{
    Button Button { set; }
    Image TileImage { set; get; }
    Color TileColor { set; get; }
    int X { get; set; }
    int Y { get; set; }
    bool HasUnit { get; }
    Unit Unit { get; set; }
}