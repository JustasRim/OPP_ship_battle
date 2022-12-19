using BenchmarkDotNet.Disassemblers;
using System;
using System.Drawing;
//using System.Windows.Forms;
using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.FlyWeight;
using BenchmarkDotNet.Running;
using System.Drawing;
using BenchmarkDotNet.Attributes;
using BattleShipClient.Ingame_objects.Observer;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Map2Creator>();
        }
    }

    [MemoryDiagnoser]
    public class Map2Creator
    {

        [Benchmark]
        public void CreateMapFlyWeight()
        { 
            var Tiles = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 5)
                        Tiles.Add(new Tile("rock", Color.Gray, TileImages.SetGray, i, j));
                    else if (j < 5)
                        Tiles.Add(new Tile("ground", Color.DarkGreen, TileImages.SetGreen, i, j));
                    else
                        Tiles.Add(new Tile("water", Color.LightBlue, TileImages.SetBlue, i, j));
                }
            }
        }

        [Benchmark]
        public void CreateMapOld()
        {
            var Tiles = new List<ITileOld>();
            var updateImage = Image.FromFile(@"C:\Users\Vidas\Pictures\update.png");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 5)
                        Tiles.Add(new RockTile(i, j, 
                            Image.FromFile(@"C:\Users\Vidas\Pictures\rock.png"),
                            updateImage));
                    else if (j < 5)
                        Tiles.Add(new WaterTile(i, j,
                            Image.FromFile(@"C:\Users\Vidas\Pictures\water.png"),
                            updateImage));
                    else
                        Tiles.Add(new GroundTile(i, j,
                            Image.FromFile(@"C:\Users\Vidas\Pictures\ground.png"),
                            updateImage));
                }
            }
        }
    }

}

