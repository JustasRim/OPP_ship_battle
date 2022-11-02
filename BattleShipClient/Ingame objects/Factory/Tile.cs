using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Observer;
using System.Drawing;
using System.Windows.Forms;

public interface ITile : ISubscriber
{
    Button Button { set; }
    Color Color { get; set; }
    int X { get; set; }
    int Y { get; set; }
    bool HasUnit { get; }
    Unit Unit { get; set; }
}