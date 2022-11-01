using System.Drawing;
public interface ITile
{
    Color Color { get; set; }
    int X { get; set; }
    int Y { get; set; }
    bool HasUnit { get; set; }
}