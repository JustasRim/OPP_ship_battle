using BattleShipClient.Ingame_objects.AbstractFactory;
using BattleShipClient.Ingame_objects.Adapter;
using BattleShipClient.Ingame_objects.Builder;
using BattleShipClient.Ingame_objects.Decorator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BattleShipClient.Ingame_objects.Facade.Facade;

namespace BattleShipClient.Ingame_objects.Facade
{
    public class Facade
    {
        Map2Creator yourMap { get; set; }
        Map2Creator yourMapTmp { get; set; }
        Map2Creator enemyMap { get; set; }

        int masts { get; set; }
        Ship unitOf1Masts { get; set; }
        Ship unitOf2Masts { get; set; }
        Ship unitOf3Masts { get; set; }
        Ship unitOf4Masts { get; set; }

        Director director { get; set; }

        public Facade()
        {
            yourMap = new Map2Creator();
            yourMapTmp = new Map2Creator();
            enemyMap = new Map2Creator();
            director = new Director();
            masts = 20;
        }

        public Ship GetUnits(UnitTypes type)
        {
            switch (type)
            {
                case UnitTypes.unitOf1Masts:
                    return unitOf1Masts;
                case UnitTypes.unitOf2Masts:
                    return unitOf2Masts;
                case UnitTypes.unitOf3Masts:
                    return unitOf3Masts;
                case UnitTypes.unitOf4Masts:
                    return unitOf4Masts;
                default:
                    return null;
            }
        }

        public Map GetMap(Maps map)
        {
            switch (map)
            {
                case Maps.yourMap:
                    return yourMap;
                    break;
                case Maps.yourMapTmp:
                    return yourMapTmp;
                    break;
                case Maps.enemyMap:
                    return enemyMap;
                    break;
                default:
                    return null;
            };
        }
        public ITile GetTile(Maps map, int x, int y)
        {
            switch (map)
            {
                case Maps.yourMap:
                    return yourMap.GetTile(x, y);
                    break;
                case Maps.yourMapTmp:
                    return yourMapTmp.GetTile(x, y);
                    break;
                case Maps.enemyMap:
                    return enemyMap.GetTile(x, y);
                    break;
                default:
                    return null;
            };
        }

        public void ResetTiles(Maps map)
        {
            switch (map)
            {
                case Maps.yourMap:
                    yourMap.ResetTiles();
                    break;
                case Maps.yourMapTmp:
                    yourMapTmp.ResetTiles();
                    break;
                case Maps.enemyMap:
                    enemyMap.ResetTiles();
                    break;
            };
        }

        public enum Maps
        {
            yourMap,
            yourMapTmp,
            enemyMap
        }

        public enum UnitTypes
        {
            unitOf1Masts,
            unitOf2Masts,
            unitOf3Masts,
            unitOf4Masts
        }

        public bool Check1Masts()
        {
            int leftNo = 0;
            int rightNo = 0;
            int upNo = 0;
            int downNo = 0;

            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //if (yourMap.GetTile(i, j).HasUnit)
                    if (GetTile(Facade.Maps.yourMap, i, j).HasUnit)
                    {
                        leftNo = IsLeftNeighbour(i, j);
                        rightNo = IsRightNeighbour(i, j);
                        upNo = IsUpNeighbour(i, j);
                        downNo = IsDownNeighbour(i, j);
                        if (leftNo == 0 && rightNo == 0 && downNo == 0 && upNo == 0)
                        {
                            //with prototype (if the first unit is being then creates with builder else creates with prototype)
                            //if(unitOf1Masts == null)
                            if (GetUnits(Facade.UnitTypes.unitOf1Masts) == null)
                            {
                                var destroyerBuilder = new DestroyerShipBuilder();
                                director.Construct(destroyerBuilder);
                                var ship = destroyerBuilder.GetShip();

                                /*BattalionCreator battalionCreator = new BattalionCreator();
                                var battalion = battalionCreator.CreateBattalion(1);
                                var factory = battalion.GetAbstractFactory();
                                var tank = factory.CreateTank();
                                var testShip = factory.CreateShip();

                                var createdTank = tank.GetName();
                                var createdShip = testShip.GetName();*/                                

                                yourMapTmp.GetTile(i, j).Unit = ship;
                                var tile = yourMap.GetTile(i, j);
                                tile.Unit = ship;

                                ship.Publisher.RegisterSubscriber(tile);
                                counter++;
                                unitOf1Masts = ship;
                            }
                            else
                            {
                                var ship = (Ship)unitOf1Masts.DeepCopy();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                var tile = yourMap.GetTile(i, j);
                                tile.Unit = ship;

                                ship.Publisher.RegisterSubscriber(tile);

                                counter++;
                            }

                            //before
                            /*
                            var destroyerBuilder = new DestroyerShipBuilder();
                            director.Construct(destroyerBuilder);
                            var ship = destroyerBuilder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i, j).Unit = ship;
                            counter++;
                            */
                        }
                        if (counter > 4) return false;
                    }

                }
            }
            if (counter < 4) return false;
            return true;
        }

        public int IsLeftNeighbour(int x, int y)
        {
            int x1 = x;
            int y1 = y - 1;
            if (y1 > -1)
            {
                //if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
                if (GetTile(Facade.Maps.yourMap, x1, y1).HasUnit) //check if neighbour has neighbour
                {
                    return 1 + IsLeftNeighbour(x1, y1);
                }
                else //no neigbour
                {
                    return 0;
                }
            }
            else //no neighbour
            {
                return 0;
            }
        }
        public int IsRightNeighbour(int x, int y)
        {
            int x1 = x;
            int y1 = y + 1;
            if (y1 < 10)
            {
                //if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
                if (GetTile(Facade.Maps.yourMap, x1, y1).HasUnit) //check if neighbour has neighbour

                {
                    return 1 + IsRightNeighbour(x1, y1);
                }
                else //no neigbour
                {
                    return 0;
                }
            }
            else //no neighbour
            {
                return 0;
            }
        }
        public int IsUpNeighbour(int x, int y)
        {
            int x1 = x - 1;
            int y1 = y;
            if (x1 > -1)
            {
                //if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
                if (GetTile(Facade.Maps.yourMap, x1, y1).HasUnit) //check if neighbour has neighbour
                {
                    return 1 + IsUpNeighbour(x1, y1);
                }
                else //no neigbour
                {
                    return 0;
                }
            }
            else //no neighbour
            {
                return 0;
            }
        }
        public int IsDownNeighbour(int x, int y)
        {
            int x1 = x + 1;
            int y1 = y;
            if (x1 < 10)
            {
                //if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
                if (GetTile(Facade.Maps.yourMap, x1, y1).HasUnit) //check if neighbour has neighbour
                {
                    return 1 + IsDownNeighbour(x1, y1);
                }
                else //no neigbour
                {
                    return 0;
                }
            }
            else //no neighbour
            {
                return 0;
            }
        }

        public bool Check2Masts()
        {
            int leftNo = 0;
            int rightNo = 0;
            int upNo = 0;
            int downNo = 0;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (yourMap.GetTile(i, j).HasUnit)
                    {
                        if (yourMapTmp.GetTile(i, j).HasUnit == true) continue;
                        downNo = IsDownNeighbour(i, j);
                        upNo = IsUpNeighbour(i, j);
                        if (downNo == 1 && upNo == 0)
                        {
                            if (unitOf2Masts == null)
                            {
                                var destroyerBuilder = new DestroyerShipBuilder();
                                director.Construct(destroyerBuilder);
                                var ship = destroyerBuilder.GetShip();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                counter++;
                                unitOf2Masts = ship;
                            }
                            else
                            {
                                var ship = (Ship)unitOf2Masts.DeepCopy();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                counter++;
                            }
                            /* before
                            var destroyerBuilder = new DestroyerShipBuilder();
                            director.Construct(destroyerBuilder);
                            var ship = destroyerBuilder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMapTmp.GetTile(i + 1, j).Unit = ship;

                            yourMap.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i + 1, j).Unit = ship;
                            counter++;
                            */
                        }
                        else if (downNo == 0 && upNo == 0)
                        {
                            rightNo = IsRightNeighbour(i, j);
                            leftNo = IsLeftNeighbour(i, j);
                            if (rightNo == 1 && leftNo == 0)
                            {
                                if (unitOf2Masts == null)
                                {
                                    var destroyerBuilder = new DestroyerShipBuilder();
                                    director.Construct(destroyerBuilder);
                                    var ship = destroyerBuilder.GetShip();

                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));

                                    counter++;
                                    unitOf2Masts = ship;
                                }
                                else
                                {
                                    var ship = (Unit)unitOf2Masts.DeepCopy();

                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));

                                    counter++;
                                }
                                /* before
                                 var destroyerBuilder = new DestroyerShipBuilder();
                                 director.Construct(destroyerBuilder);
                                 var ship = destroyerBuilder.GetShip();

                                 yourMapTmp.GetTile(i, j).Unit = ship;
                                 yourMapTmp.GetTile(i, j + 1).Unit = ship;

                                 yourMap.GetTile(i, j).Unit = ship;
                                 yourMap.GetTile(i, j + 1).Unit = ship;
                                 counter++;
                                 */
                            }
                        }
                        if (counter > 3) return false;
                    }
                }
            }
            if (counter < 3) return false;
            return true;
        }
        public bool Check3Masts()
        {
            int leftNo = 0;
            int rightNo = 0;
            int upNo = 0;
            int downNo = 0;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (yourMap.GetTile(i, j).HasUnit)
                    {
                        if (yourMapTmp.GetTile(i, j).HasUnit == true) continue;
                        downNo = IsDownNeighbour(i, j);
                        upNo = IsUpNeighbour(i, j);
                        if (downNo == 2 && upNo == 0)
                        {
                            if (unitOf3Masts == null)
                            {
                                var builder = new BattleShipBuilder();
                                director.Construct(builder);
                                var ship = builder.GetShip();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;
                                yourMapTmp.GetTile(i + 2, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;
                                yourMap.GetTile(i + 2, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 2, j));

                                counter++;
                                unitOf3Masts = ship;
                            }
                            else
                            {
                                var ship = (Ship)unitOf3Masts.DeepCopy();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;
                                yourMapTmp.GetTile(i + 2, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;
                                yourMap.GetTile(i + 2, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 2, j));

                                counter++;
                            }
                            /* before
                            var builder = new BattleShipBuilder();
                            director.Construct(builder);
                            var ship = builder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMapTmp.GetTile(i + 1, j).Unit = ship;
                            yourMapTmp.GetTile(i + 2, j).Unit = ship;

                            yourMap.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i + 1, j).Unit = ship;
                            yourMap.GetTile(i + 2, j).Unit = ship;
                            counter++;
                            */
                        }
                        else if (downNo == 0 && upNo == 0)
                        {
                            rightNo = IsRightNeighbour(i, j);
                            leftNo = IsLeftNeighbour(i, j);
                            if (rightNo == 2 && leftNo == 0)
                            {
                                if (unitOf3Masts == null)
                                {
                                    var builder = new BattleShipBuilder();
                                    director.Construct(builder);
                                    var ship = builder.GetShip();
                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 2).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;
                                    yourMap.GetTile(i, j + 2).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 2));

                                    counter++;
                                    unitOf3Masts = ship;
                                }
                                else
                                {
                                    var ship = (Ship)unitOf3Masts.DeepCopy();
                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 2).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;
                                    yourMap.GetTile(i, j + 2).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 2));

                                    counter++;
                                }
                            }

                            /* before
                            var builder = new BattleShipBuilder();
                            director.Construct(builder);
                            var ship = builder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMapTmp.GetTile(i, j + 1).Unit = ship;
                            yourMapTmp.GetTile(i, j + 2).Unit = ship;

                            yourMap.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i, j + 1).Unit = ship;
                            yourMap.GetTile(i, j + 2).Unit = ship;
                            counter++;
                            */
                        }
                        if (counter > 2) return false;
                    }
                }
            }
            if (counter < 2) return false;
            return true;
        }
        public bool Check4Masts()
        {
            int leftNo = 0;
            int rightNo = 0;
            int upNo = 0;
            int downNo = 0;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (yourMap.GetTile(i, j).HasUnit)
                    {
                        if (yourMapTmp.GetTile(i, j).HasUnit == true) continue;
                        downNo = IsDownNeighbour(i, j);
                        upNo = IsUpNeighbour(i, j);
                        if (downNo == 3 && upNo == 0)
                        {
                            if (unitOf4Masts == null)
                            {
                                var builder = new BattleShipBuilder();
                                director.Construct(builder);
                                var ship = builder.GetShip();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;
                                yourMapTmp.GetTile(i + 2, j).Unit = ship;
                                yourMapTmp.GetTile(i + 3, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;
                                yourMap.GetTile(i + 2, j).Unit = ship;
                                yourMap.GetTile(i + 3, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 2, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 3, j));

                                counter++;
                                unitOf4Masts = ship;
                            }
                            else
                            {
                                var ship = (Ship)unitOf4Masts.DeepCopy();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i + 1, j).Unit = ship;
                                yourMapTmp.GetTile(i + 2, j).Unit = ship;
                                yourMapTmp.GetTile(i + 3, j).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i + 1, j).Unit = ship;
                                yourMap.GetTile(i + 2, j).Unit = ship;
                                yourMap.GetTile(i + 3, j).Unit = ship;

                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 1, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 2, j));
                                ship.Publisher.RegisterSubscriber(yourMap.GetTile(i + 3, j));
                                counter++;
                            }

                            /* before
                            var builder = new BattleShipBuilder();
                            director.Construct(builder);
                            var ship = builder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMapTmp.GetTile(i + 1, j).Unit = ship;
                            yourMapTmp.GetTile(i + 2, j).Unit = ship;
                            yourMapTmp.GetTile(i + 3, j).Unit = ship;

                            yourMap.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i + 1, j).Unit = ship;
                            yourMap.GetTile(i + 2, j).Unit = ship;
                            yourMap.GetTile(i + 3, j).Unit = ship;
                            counter++;
                            */
                        }
                        else if (downNo == 0 && upNo == 0)
                        {
                            rightNo = IsRightNeighbour(i, j);
                            leftNo = IsLeftNeighbour(i, j);
                            if (rightNo == 3 && leftNo == 0)
                            {
                                if (unitOf4Masts == null)
                                {
                                    var builder = new BattleShipBuilder();
                                    director.Construct(builder);
                                    var ship = builder.GetShip();
                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 2).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 3).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;
                                    yourMap.GetTile(i, j + 2).Unit = ship;
                                    yourMap.GetTile(i, j + 3).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 2));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 3));

                                    counter++;
                                    unitOf4Masts = ship;
                                }
                                else
                                {
                                    var ship = (Ship)unitOf4Masts.DeepCopy();
                                    yourMapTmp.GetTile(i, j).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 1).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 2).Unit = ship;
                                    yourMapTmp.GetTile(i, j + 3).Unit = ship;

                                    yourMap.GetTile(i, j).Unit = ship;
                                    yourMap.GetTile(i, j + 1).Unit = ship;
                                    yourMap.GetTile(i, j + 2).Unit = ship;
                                    yourMap.GetTile(i, j + 3).Unit = ship;

                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 1));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 2));
                                    ship.Publisher.RegisterSubscriber(yourMap.GetTile(i, j + 3));

                                    counter++;
                                }

                                /* before
                                var builder = new BattleShipBuilder();
                                director.Construct(builder);
                                var ship = builder.GetShip();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMapTmp.GetTile(i, j + 1).Unit = ship;
                                yourMapTmp.GetTile(i, j + 2).Unit = ship;
                                yourMapTmp.GetTile(i, j + 3).Unit = ship;

                                yourMap.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i, j + 1).Unit = ship;
                                yourMap.GetTile(i, j + 2).Unit = ship;
                                yourMap.GetTile(i, j + 3).Unit = ship;
                                counter++;

                                */
                            }
                        }
                        if (counter > 1) return false;
                    }
                }
            }
            if (counter < 1) return false;
            return true;
        }
        public bool DamageUnit(ITile tile, int damage)
        {
            var unit = tile.Unit;
            unit.AddPowerUp(PowerUpType.Shield, 50);
            if (unit.GetPowerUpType() != PowerUpType.None)
            {
                if (unit.CanTakeDamage(damage))
                {
                    var dmg = unit.GetDamageTaken(damage);
                    unit.TakeDamage(unit.GetDamageTaken(damage));
                }
            }
            else
            {
                unit.TakeDamage(damage);
            }
            if (unit.Health <= 0)
            {
                masts--;
                if (unit is Ship sinkable)
                {
                    Die(sinkable);
                }
                else
                {
                    var tank = unit as Tank;
                    var adapter = new ShipTankAdapter(tank);
                    Die(adapter);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Die(ISinkable sinkable)
        {
            sinkable.Sink();
        }
        public int GetRemainingMastsCount() 
        {
            return masts;
        }
        public void AssignUnit(ITile tile, Unit unit)
        {
            tile.Unit = unit;
        }
    }
}
