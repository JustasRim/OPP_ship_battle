using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Observer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.FlyWeight
{
    public class Tile : ITile
    {
        public Button Button { get;  set; }
        public Color TileColor { get; set; }
        public Image TileImage { get;set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasUnit { get => Unit != null; }
        public Unit Unit { get; set; }

        public Tile(string image, Color setColor, Func<Image> setImage, int x, int y)
        {
            (TileImage, TileColor) = TileImages.getImage(image, setColor, setImage);
            X = x;
            Y = y;
        }

        public void Update()
        {
            (Button.Image, Button.BackColor) = TileImages.getImage("update", Color.Crimson, TileImages.SetUpdate);
        }

    }
}
