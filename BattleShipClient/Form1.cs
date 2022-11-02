using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Adapter;
using BattleShipClient.Ingame_objects.Builder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Windows.Forms;

namespace BattleShipClient
{
    public partial class Form1 : Form
    {
        string enemyNick;
        public bool enemyGiveUpBeforeStart = false;
        public bool normalEnd = false;
        public Button clickedButton;

        //mast not sunk
        public int masts = 20;
        public Form1(string enemyNick)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.enemyNick = enemyNick;
        }
        public Map2Creator yourMap = new Map2Creator();
        public Map2Creator yourMapTmp = new Map2Creator();
        public Map2Creator enemyMap = new Map2Creator();

        Ship unitOf1Masts;
        Ship unitOf2Masts;
        Ship unitOf3Masts;
        Ship unitOf4Masts;

        public Director director = new Director();

        List<Button> selectedButtons = new List<Button>();
        private void setDefaultValuesInMap(bool value, bool [,] Map)
        {
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    Map[i, j] = value;
                }
            }
        }
        private void GenerateMap(string name, int xStartPos, int yStartPos, Map map)
        {
            Panel buttonPanel = new Panel();
            buttonPanel.Name = name;
            buttonPanel.Size=new Size(231, 231);
            int xButtonSize = 21;
            int yButtonSize = 21;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0 && j == 0) continue; //don't create left top corner
                    Button button = new Button();
                    buttonPanel.Controls.Add(button);
                    button.Location = new System.Drawing.Point(j* xButtonSize, i * yButtonSize);
                    button.Size = new Size(xButtonSize, yButtonSize);
                    button.ForeColor = System.Drawing.Color.Black;
                    //this.Controls.Add(button);
                    if (i>0 && j>0) //double digits: 00, 01, ..., 99
                    {
                        button.Name = (i - 1).ToString() + (j - 1).ToString();
                        //button.Text = (i - 1).ToString() + (j - 1).ToString();
                        button.Font = new Font(button.Font.FontFamily, 6);
                        if (name == "PYou")
                        {
                            button.BackColor = map.GetTile(i - 1, j - 1).Color;
                            button.Click += new System.EventHandler(this.setMastbuttonClick);
                        }
                        else if (name== "PEnemy")
                        {
                            button.BackColor = map.GetTile(i - 1, j - 1).Color;
                            button.Click += new System.EventHandler(this.buttonClick);
                        }
                    }
                    else
                    {
                        button.Enabled = false;
                        if (i == 0 && j > 0) //letters: A, B, ..., J
                        {
                            button.Text = ((char)(64 + j)).ToString();
                            button.Name= ((char)(64 + j)).ToString();
                            button.Font = new Font(button.Font.FontFamily, 6);
                        }
                        else if (i!=0 || j!=0) // digits: 1, 2, ..., 10
                        {
                            button.Text = i.ToString();
                            button.Name= "L" + i.ToString();
                            button.Font = new Font(button.Font.FontFamily, 6);
                        }
                    }          
                }
            }
            this.Controls.Add(buttonPanel);
            buttonPanel.Location = new Point(xStartPos, yStartPos);
        }
        private void SetShips()
        {
            GenerateMap("PYou",204, 190, yourMap);
            yourMapTmp.ResetTiles();
        }

        private void DisableOrEnableButtonIfExists(Panel panel, int x1, int y1, bool DisOrEn)
        {
            Button button;
            button = (Button)panel.Controls.Find(x1.ToString() + y1.ToString(), true).FirstOrDefault();
            if (button != null)
            {
                if (DisOrEn == false)
                {
                    button.Enabled = false;
                }
                else
                {
                    button.Enabled = true;
                }
            }
        }

        private int IsLeftNeighbour(int x, int y)
        {
            int x1=x;
            int y1=y-1;
            if (y1>-1)
            {
                if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
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
        private int IsRightNeighbour(int x, int y)
        {
            int x1 = x;
            int y1 = y + 1;
            if (y1 < 10)
            {
                if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
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
        private int IsUpNeighbour(int x, int y)
        {
            int x1 = x - 1;
            int y1 = y;
            if (x1 > -1)
            {
                if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
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
        private int IsDownNeighbour(int x, int y)
        {
            int x1 = x + 1;
            int y1 = y;
            if (x1 < 10)
            {
                if (yourMap.GetTile(x1, y1).HasUnit) //check if neighbour has neighbour
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
        private void DisableOrEnableAllCorners(Panel panel, int x, int y, bool trueOrFalse)
        {
            DisableOrEnableButtonIfExists(panel, x-1, y-1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x-1, y+1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x+1, y+1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x+1, y-1, trueOrFalse);
        }
        bool Check1Masts()
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
                        leftNo = IsLeftNeighbour(i, j);
                        rightNo = IsRightNeighbour(i, j);
                        upNo = IsUpNeighbour(i, j);
                        downNo = IsDownNeighbour(i, j);
                        if (leftNo==0 && rightNo==0 && downNo ==0 && upNo==0)
                        {
                            //with prototype (if the first unit is being then creates with builder else creates with prototype)
                            if(unitOf1Masts == null) { 
                            var destroyerBuilder = new DestroyerShipBuilder();
                            director.Construct(destroyerBuilder);
                            var ship = destroyerBuilder.GetShip();
                            yourMapTmp.GetTile(i, j).Unit = ship;
                            yourMap.GetTile(i, j).Unit = ship;
                            counter++;
                            unitOf1Masts = ship;
                            }
                            else
                            {
                                var ship = (Ship)unitOf1Masts.DeepCopy();
                                yourMapTmp.GetTile(i, j).Unit = ship;
                                yourMap.GetTile(i, j).Unit = ship;
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
        bool Check2Masts()
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
                        if (downNo == 1 && upNo==0)
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
                                counter++;
                                unitOf2Masts = ship;
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
                        else if (downNo==0 && upNo==0)
                        {
                            rightNo = IsRightNeighbour(i, j);
                            leftNo = IsLeftNeighbour(i, j);
                            if (rightNo==1 && leftNo==0)
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
        bool Check3Masts()
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
                                    counter++;
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
        bool Check4Masts()
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
        public void PrepareBattleField()
        {         
            //Hide panel for setting masts
            PMastSet.Visible = false;
            Panel matched = (Panel)this.Controls.Find("PYou", true).FirstOrDefault();
            matched.Visible = false;
            matched.Enabled = false;
            if (matched != null)
            {
                matched.Location = new Point(matched.Location.X - 164, matched.Location.Y);
            }
            matched.Visible = true;
            //for enemy
            GenerateMap("PEnemy", 360, 190, enemyMap);
            //Make visible mast tip panel
            PMast.Visible = true;
            yourMapTmp.ResetTiles();
        }
        void playbuttonClick(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;
            //check masts
            bool checkResult = false;
            yourMapTmp.ResetTiles();
            checkResult=Check1Masts();
            if (checkResult==false)
            {
                MessageBox.Show("You have set wrong number of 1-masts", "Error");
                return;
            }
            checkResult = Check2Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 2-masts", "Error");
                return;
            }
            checkResult = Check3Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 3-masts", "Error");
                return;
            }
            checkResult = Check4Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 4-masts", "Error");
                return;
            }

            //Send StartGame communique
            char comm = (char)0;
            string message = comm + " " + Program.userLogin + " " + Program.enemyNick + " <EOF>";
            Program.client.Send(message);
            enemyGiveUpBeforeStart = true;
            //Receive answer in Program's thread
            clickedButton.Enabled = false;
        }

        public void GetShotAndResponse(int x, int y, int damage)
        {
            Button button;
            Panel panel = (Panel)this.Controls.Find("PYou", true).FirstOrDefault();
            button = (Button)panel.Controls.Find(x.ToString() + y.ToString(), true).FirstOrDefault();
            string message = "";
            //Ship is hit
            var tile = yourMap.GetTile(x, y);
            if (tile.HasUnit)
            {
                var unit = tile.Unit;
                unit.TakeDamage(damage);
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

                    button.BackColor = Color.Tomato;
                } 
                else
                {
                    button.BackColor = Color.Purple;
                }
                
                Application.DoEvents();
                if (masts == 0)
                {
                    Application.DoEvents();
                    return;
                }
                else
                {
                    //Send Hit
                    message = (char)5 + " " + enemyNick + " " + unit.Health + " <EOF>";
                    Program.client.Send(message);
                    //Your turn
                    ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = false;
                }  
            }
            else//Send Miss
            {
                message = (char)4 + " " + enemyNick + " <EOF>";
                Program.client.Send(message);
                button.BackColor = Color.Silver;
                //Your turn
                ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = true;
            }
            Application.DoEvents();
        }

        private void Die(ISinkable sinkable)
        {
            sinkable.Sink();
        }

        void setMastbuttonClick(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;//detect which button has been pressed
            int x = Int32.Parse(clickedButton.Name.Substring(0, 1)); //get x button co-ordinates
            int y = Int32.Parse(clickedButton.Name.Substring(1, 1)); //get y button co-ordinates
            int leftNo = IsLeftNeighbour(x, y);
            int rightNo = IsRightNeighbour(x, y);
            int upNo = IsUpNeighbour(x, y);
            int downNo = IsDownNeighbour(x, y);

            //Select or not
            if (clickedButton.BackColor != Color.MediumBlue) //if button wasn't selected
            {
                //check left neigbours
                if ((leftNo + rightNo < 4) && (upNo + downNo < 4))
                {
                    clickedButton.BackColor = Color.MediumBlue;
                    //add to dictionary
                    selectedButtons.Add(clickedButton);
                    //disable corners
                    DisableOrEnableAllCorners((Panel)clickedButton.Parent, x, y, false);
                    //set true in game table
                    yourMap.GetTile(x, y).Unit = new Unit();
                }
            }
            else
            {
                clickedButton.BackColor = yourMap.GetTile(x, y).Color;
                //enable corners
                DisableOrEnableAllCorners((Panel)clickedButton.Parent, x, y, true);
                //remove from dictionary
                selectedButtons.Remove(clickedButton);
                //disable corners for buttons in dictionary
                foreach (Button btn in selectedButtons)
                {
                    DisableOrEnableAllCorners((Panel)btn.Parent, Int32.Parse(btn.Name[0].ToString()), Int32.Parse(btn.Name[1].ToString()), false);
                }
                //set false in game table
                yourMap.GetTile(x, y).Unit = null;
            }
            //Check
        }

        void buttonClick(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;//detect which button has been pressed
            clickedButton.Enabled = false;
            int x = Int32.Parse(clickedButton.Name.Substring(0, 1)); //get x button co-ordinates
            int y = Int32.Parse(clickedButton.Name.Substring(1, 1)); //get y button co-ordinates
            //Send Shot
            string message = "";
            var damage = yourMap.Tiles.Where(q => q.HasUnit).SelectMany(q => q.Unit.Parts).Sum(q => q.Damage);
            message = (char)6 + " " + enemyNick + " " + x.ToString() + " " + y.ToString() + " " + damage + " <EOF>";
            Program.client.Send(message);
            //Get answer form Program's thread       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Battleship - you're playing with " + enemyNick;
            SetShips();
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (enemyGiveUpBeforeStart == false)
            {
                //User must send GiveUp Communique
                char comm = (char)2;
                //<Who gives up> <with whom he plays>
                string message = comm + " " + Program.userLogin + " " + Program.enemyNick + " <EOF>";
                Program.client.Send(message);

            }
            else if (normalEnd == false)
            {
                char comm = (char)15;
                //<Who gives up> <with whom he plays>
                string message = comm + " " + Program.userLogin + " " + Program.enemyNick + " <EOF>";
                Program.client.Send(message);
            }
            //User Go to EnemySelectionPanel
            DialogResult = DialogResult.Yes;
        }
    }
}
