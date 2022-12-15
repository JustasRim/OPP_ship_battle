using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Adapter;
using BattleShipClient.Ingame_objects.Builder;
using BattleShipClient.Ingame_objects.Decorator;
using BattleShipClient.Ingame_objects.Facade;
using BattleShipClient.Ingame_objects.Prototype;
using BattleShipClient.Ingame_objects.Strategy;
using BattleShipClient.Ingame_objects.Visitor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace BattleShipClient
{
    public partial class Form1 : Form
    {
        string enemyNick;
        public bool enemyGiveUpBeforeStart = false;
        public bool normalEnd = false;
        public Button clickedButton;
        public Facade facade = new Facade();
        //mast not sunk
        //public int masts = 20;
        public Form1(string enemyNick)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.enemyNick = enemyNick;
        }

        List<Button> selectedButtons = new List<Button>();
        
        private void GenerateMap(string name, int xStartPos, int yStartPos, Facade.Maps map)
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
                            //var tile = map.GetTile(i - 1, j - 1);
                            var tile = facade.GetTile(map, i - 1, j - 1);
                            button.BackColor = tile.Color;
                            tile.Button = button;
                            button.Click += new System.EventHandler(this.setMastbuttonClick);
                        }
                        else if (name== "PEnemy")
                        {
                            //var tile = map.GetTile(i - 1, j - 1);
                            var tile = facade.GetTile(map, i - 1, j - 1);
                            button.BackColor = tile.Color;
                            tile.Button = button;
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
            //GenerateMap("PYou",204, 190, yourMap);
            GenerateMap("PYou", 204, 190, Facade.Maps.yourMap);
            //yourMapTmp.ResetTiles();
            facade.ResetTiles(Facade.Maps.yourMapTmp);
        }

        private void DisableOrEnableButtonIfExists(Panel panel, int x1, int y1, bool DisOrEn)
        {
            Button button;
            button = (Button)panel.Controls.Find(x1.ToString() + y1.ToString(), true).FirstOrDefault();
            if (button != null)
            {
                if (DisOrEn == false)
                    button.Enabled = false;
                else
                    button.Enabled = true;
            }
        }

        private void DisableOrEnableAllCorners(Panel panel, int x, int y, bool trueOrFalse)
        {
            DisableOrEnableButtonIfExists(panel, x-1, y-1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x-1, y+1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x+1, y+1, trueOrFalse);
            DisableOrEnableButtonIfExists(panel, x+1, y-1, trueOrFalse);
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
            GenerateMap("PEnemy", 360, 190, Facade.Maps.enemyMap);
            //Make visible mast tip panel
            PMast.Visible = true;
            facade.ResetTiles(Facade.Maps.yourMapTmp);
        }
        void playbuttonClick(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;
            facade.ResetTiles(Facade.Maps.yourMapTmp);
            //yourMapTmp.ResetTiles();
            var checkResult = facade.Check1Masts();
            //checkResult = Check1Masts();
            if (checkResult==false)
            {
                MessageBox.Show("You have set wrong number of 1-masts", "Error");
                return;
            }
            checkResult = facade.Check2Masts();
            //checkResult = Check2Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 2-masts", "Error");
                return;
            }
            checkResult = facade.Check3Masts();
            //checkResult = Check3Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 3-masts", "Error");
                return;
            }
            checkResult = facade.Check4Masts();
            if (checkResult == false)
            {
                MessageBox.Show("You have set wrong number of 4-masts", "Error");
                return;
            }
        
            var signalMessage = new SignalMessage();
            FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
            EndDecorator endDecorator = new EndDecorator(frontDecorator, signalMessage);
            WholeDecorator wholeDecorator = new WholeDecorator(endDecorator, signalMessage);

            facade.CreateCompositeFleet();

            signalMessage.CreateEmptyMessage();         
            char comm = (char)0;
            wholeDecorator.CreateMessage(Program.userLogin + " " + Program.enemyNick);
            frontDecorator.CreateMessage(comm + " ");
            endDecorator.CreateEndMessage(" <EOF>");
            Program.client.Send(signalMessage.ReturnMessage());
            enemyGiveUpBeforeStart = true;
            //Receive answer in Program's thread
            clickedButton.Enabled = false;      
        }

        public void GetShotAndResponse(int x, int y, int damage)
        {
            Panel panel = (Panel)this.Controls.Find("PYou", true).FirstOrDefault();
            Button button = (Button)panel.Controls.Find(x.ToString() + y.ToString(), true).FirstOrDefault();
            
            SignalMessage signalMessage = new SignalMessage();
            signalMessage.CreateEmptyMessage();

            FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
            EndDecorator endDecorator = new EndDecorator(frontDecorator, signalMessage);
            WholeDecorator wholeDecorator = new WholeDecorator(endDecorator, signalMessage);

            var tile = facade.GetTile(Facade.Maps.yourMap, x, y);
            if (tile.HasUnit)
            {
                var hasUnitDied = facade.DamageUnit(tile, damage);

                if (hasUnitDied)
                    button.BackColor = Color.Tomato;
                else
                    button.BackColor = Color.Purple;

                Application.DoEvents();
                if (facade.GetRemainingMastsCount() == 0)
                {
                    Application.DoEvents();
                    return;
                }
                else
                {
                    wholeDecorator.CreateMessage((char)5 + " " + enemyNick + " " + tile.Unit.Health + " <EOF>");
                    Program.client.Send(wholeDecorator.ReturnMessage());
                    //Your turn
                    ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = false;
                }
            }
            else//Send Miss
            {
                wholeDecorator.CreateMessage((char)4 + " " + enemyNick + " <EOF>");
                Program.client.Send(wholeDecorator.ReturnMessage());
                button.BackColor = Color.Silver;

                //Your turn
                ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = true;
            }
            Application.DoEvents();
        }

        void setMastbuttonClick(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;//detect which button has been pressed
            int x = Int32.Parse(clickedButton.Name.Substring(0, 1)); //get x button co-ordinates
            int y = Int32.Parse(clickedButton.Name.Substring(1, 1)); //get y button co-ordinates
            int leftNo = facade.IsLeftNeighbour(x, y);
            int rightNo = facade.IsRightNeighbour(x, y);
            int upNo = facade.IsUpNeighbour(x, y);
            int downNo = facade.IsDownNeighbour(x, y);

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
                    facade.AssignUnit(facade.GetTile(Facade.Maps.yourMap, x, y), new Unit());
                }
            }
            else
            {
                clickedButton.BackColor = facade.GetTile(Facade.Maps.yourMap, x, y).Color;
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
                facade.AssignUnit(facade.GetTile(Facade.Maps.yourMap, x, y), null);
            }
        }

        void buttonClick(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;//detect which button has been pressed
            int x = Int32.Parse(clickedButton.Name.Substring(0, 1)); //get x button co-ordinates
            int y = Int32.Parse(clickedButton.Name.Substring(1, 1)); //get y button co-ordinates
            //Send Shot
            string message = "";
            var damage = 0;
            var iterator = facade.GetMap(Facade.Maps.yourMap).Tiles.createIterator();
            while(iterator.hasMore())
            {
                var tile = iterator.getNext();
                if (tile.HasUnit)
                {
                    var unitDamage = tile.Unit.Parts.Sum(q => q.Damage);
                    damage += unitDamage;
                }
            }
            message = (char)6 + " " + enemyNick + " " + x.ToString() + " " + y.ToString() + " " + damage + " <EOF>";
            SignalMessage signalMessage = new SignalMessage();
            signalMessage.CreateEmptyMessage();
            FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
            frontDecorator.CreateMessage((char)6 + " " + enemyNick + " " + x.ToString() + " " + y.ToString() + " " + damage + " <EOF>");
            Program.client.Send(frontDecorator.ReturnMessage());
           
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
                SignalMessage signalMessage = new SignalMessage();
                signalMessage.CreateEmptyMessage();
                FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
                frontDecorator.CreateMessage(comm + " " + Program.userLogin + " " + Program.enemyNick + " <EOF>");
                Program.client.Send(frontDecorator.ReturnMessage());
                
            }
            else if (normalEnd == false)
            {
                char comm = (char)15;
                SignalMessage signalMessage = new SignalMessage();
                signalMessage.CreateEmptyMessage();
                FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
                frontDecorator.CreateMessage(comm + " " + Program.userLogin + " " + Program.enemyNick + " <EOF>");
                Program.client.Send(frontDecorator.ReturnMessage());
                
            }
            //User Go to EnemySelectionPanel
            DialogResult = DialogResult.Yes;
        }

        private void orderToRepair_Click(object sender, EventArgs e)
        {
            facade.fleet.Visit(new RepairVisitor());
            orderToRepair.Enabled = false;
        }

        private void delegateEngineers_Click(object sender, EventArgs e)
        {
            facade.fleet.Visit(new ArmorVisitor());
            delegateEngineers.Enabled = false;
        }

        private void silentOrder_Click(object sender, EventArgs e)
        {
            facade.fleet.Visit(new DamageReductionVisitor());
            silentOrder.Enabled = false;
        }
    }
}
