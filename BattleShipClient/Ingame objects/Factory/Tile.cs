using BattleShipClient.Ingame_objects;
using System.Drawing;
public interface ITile
{
    Color Color { get; set; }
    int X { get; set; }
    int Y { get; set; }
    bool HasUnit { get; }
    Unit Unit { get; set; }
}