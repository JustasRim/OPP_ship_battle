using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.FlyWeight
{
    public static class TileImages
    {
        public static Dictionary<string, (Image, Color)> Images = new Dictionary<string, (Image, Color)>();
        public static (Image, Color) getImage(string name, Color setColor, Func<Image> setImage)
        {
            if (!Images.ContainsKey(name))
            {
                Images[name] = (setImage(), setColor);
            }
            return Images[name];
        }

        public static Image SetBlue() => Image.FromFile(@"C:\Users\Vidas\Pictures\water.png");
        public static Image SetGreen() => Image.FromFile(@"C:\Users\Vidas\Pictures\ground.png");
        public static Image SetGray() => Image.FromFile(@"C:\Users\Vidas\Pictures\rock.png");
        public static Image SetUpdate() => Image.FromFile(@"C:\Users\Vidas\Pictures\update.png");
    }
}
