using BattleShipClient.Ingame_objects;
using BattleShipClient.Ingame_objects.Adapter;
using BattleShipClient.Ingame_objects.Builder;
using BattleShipClient.Ingame_objects.Decorator;
using BattleShipClient.Ingame_objects.Facade;
using BattleShipClient.Ingame_objects.Iterator;
using BattleShipClient.Ingame_objects.MementoPattern;
using BattleShipClient.Ingame_objects.Prototype;
using BattleShipClient.Ingame_objects.State;
using BattleShipClient.Ingame_objects.Strategy;
using BattleShipClient.Ingame_objects.Visitor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BattleShipClient
{
    public partial class Form1 : Form, IStateCor
    {
        string enemyNick;
        public bool enemyGiveUpBeforeStart = false;
        public bool normalEnd = false;
        public Button clickedButton;
        public Facade facade = new Facade();
        public IStateCor _stateCor = null;
        Originator originator;
        CareTaker careTaker;

        public void SetState(IStateCor state)
        {
            _stateCor = state;
        }

        //mast not sunk
        //public int masts = 20;
        public Form1(string enemyNick)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.enemyNick = enemyNick;
            _stateCor = new ZeroState(this);
            originator = new Originator();
            careTaker = new CareTaker();
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
                            button.BackColor = tile.TileColor;
                            //button.Image = tile.TileImage;
                            tile.Button = button;
                            button.Click += new System.EventHandler(this.setMastbuttonClick);
                        }
                        else if (name== "PEnemy")
                        {
                            //var tile = map.GetTile(i - 1, j - 1);
                            var tile = facade.GetTile(map, i - 1, j - 1);
                            button.BackColor = tile.TileColor;
                            //button.Image = tile.TileImage;
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
                SetState(new OneState(this));
                _stateCor.Handle();
                //SetState(new ZeroState(this));
                //MessageBox.Show("You have set wrong number of 1-masts", "Error");
                return;
            }
            checkResult = facade.Check2Masts();
            //checkResult = Check2Masts();
            if (checkResult == false)
            {
                SetState(new TwoState(this));
                _stateCor.Handle();
                //SetState(new ZeroState(this));
                //MessageBox.Show("You have set wrong number of 2-masts", "Error");
                return;
            }
            checkResult = facade.Check3Masts();
            //checkResult = Check3Masts();
            if (checkResult == false)
            {
                SetState(new ThreeState(this));
                _stateCor.Handle();
               // SetState(new ZeroState());
                // MessageBox.Show("You have set wrong number of 3-masts", "Error");
                return;
            }
            checkResult = facade.Check4Masts();
            if (checkResult == false)
            {
                SetState(new FourState(this));
                _stateCor.Handle();
                //SetState(new ZeroState());
                //MessageBox.Show("You have set wrong number of 4-masts", "Error");
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

        public void GetShotAndResponse(int y, int x, int damage)
        {
            Panel panel = (Panel)this.Controls.Find("PYou", true).FirstOrDefault();
            
            var tiles = facade.GetMap(Facade.Maps.yourMap).Tiles;
            var iterator = new ListIterator<ITile>(tiles, x, y);
            var all_tiles = new List<ITile>();
            for (int i = 0; i < 2; i++)
            {
                all_tiles.AddRange(iterator.getNext());
            }
            SignalMessage signalMessage = new SignalMessage();
            signalMessage.CreateEmptyMessage();

            FrontDecorator frontDecorator = new FrontDecorator(signalMessage, signalMessage);
            EndDecorator endDecorator = new EndDecorator(frontDecorator, signalMessage);
            WholeDecorator wholeDecorator = new WholeDecorator(endDecorator, signalMessage);
            var hasUnit = false;
            //var tile = facade.GetTile(Facade.Maps.yourMap, x, y);
            foreach (var tile in all_tiles)
            {
                Button button = (Button)panel.Controls.Find(tile.X.ToString() + tile.Y.ToString(), true).FirstOrDefault();
                if (tile.HasUnit)
                {
                    hasUnit = true;
                    var hasUnitDied = facade.DamageUnit(tile, damage);

                    if (hasUnitDied)
                        button.BackColor = Color.Tomato;
                    else
                        button.BackColor = Color.Purple;

                    Application.DoEvents();
                    wholeDecorator.CreateMessage((char)5 + " " + enemyNick + " " + tile.Unit.Health + " <EOF>");
                    Program.client.Send(wholeDecorator.ReturnMessage());
                }
                else
                {
                    button.BackColor = Color.Silver;
                    //button.BackColor = Color.Red;
                }
               
            }
            if(!hasUnit)
            {
                wholeDecorator.CreateMessage((char)4 + " " + enemyNick + " <EOF>");
                Program.client.Send(wholeDecorator.ReturnMessage());

                //Your turn
                ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = true;
            }
            else
            {
                if (facade.GetRemainingMastsCount() == 0)
                {
                    Application.DoEvents();
                    return;
                }
                else
                {
                    //Your turn
                    ((Panel)this.Controls.Find("PEnemy", true).FirstOrDefault()).Enabled = false;
                }
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
                    //originator.setLine(facade.GetTile(Facade.Maps.yourMap, x, y), x, y, clickedButton, selectedButtons);
                    //careTaker.addMemento(originator.save());

                    clickedButton.BackColor = Color.MediumBlue;
                    //add to dictionary
                    selectedButtons.Add(clickedButton);
                    //disable corners
                    DisableOrEnableAllCorners((Panel)clickedButton.Parent, x, y, false);
                    //set true in game table
                    
                    facade.AssignUnit(facade.GetTile(Facade.Maps.yourMap, x, y), new Unit());

                    originator.setElements(facade.GetTile(Facade.Maps.yourMap, x, y),x,y,clickedButton,selectedButtons);
                    careTaker.addMemento(originator.save());


                    //issaugau facade/facede map
                    //facade.GetTile(Facade.Maps.yourMap, x, y) = ITile int?
                    //----------------------------------------------------------------

                }
            }
            else
            {
                //originator.setLine(facade.GetTile(Facade.Maps.yourMap, x, y), x, y, clickedButton, selectedButtons);
                //careTaker.addMemento(originator.save());

                clickedButton.BackColor = facade.GetTile(Facade.Maps.yourMap, x, y).TileColor;
                //clickedButton.Image = facade.GetTile(Facade.Maps.yourMap, x, y).TileImage;
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

                originator.setElements(facade.GetTile(Facade.Maps.yourMap, x, y),x,y, clickedButton, selectedButtons);
                careTaker.addMemento(originator.save());
            }
        }

        void buttonClick(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;//detect which button has been pressed
            int x = Int32.Parse(clickedButton.Name.Substring(0, 1)); //get x button co-ordinates
            int y = Int32.Parse(clickedButton.Name.Substring(1, 1)); //get y button co-ordinates
            //Send Shot
            string message = "";
            var yourMap = facade.GetMap(Facade.Maps.yourMap);
            var damage = yourMap.Tiles.Where(q => q.HasUnit).SelectMany(q => q.Unit.Parts).Sum(q => q.Damage);
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

        private void undoUnit_Click(object sender, EventArgs e)
        {
            if (originator.getElements().Item1.Unit == null)
            {
                facade.AssignUnit(facade.GetTile(Facade.Maps.yourMap, originator.getElements().Item2, originator.getElements().Item3), new Unit());
                originator.getElements().Item4.BackColor = Color.MediumBlue;

                originator.getElements().Item5.Add(originator.getElements().Item4);
                //disable corners
                foreach (Button btn in originator.getElements().Item5)
                {
                    DisableOrEnableAllCorners((Panel)btn.Parent, Int32.Parse(btn.Name[0].ToString()), Int32.Parse(btn.Name[1].ToString()), false);
                }
            }
            else
            {
                facade.AssignUnit(facade.GetTile(Facade.Maps.yourMap, originator.getElements().Item2, originator.getElements().Item3), null);
                
               

                if (originator.getElements().Item3 > 4)
                {
                    originator.getElements().Item4.BackColor = Color.LightBlue;
                }
                else if (originator.getElements().Item3 == 5)
                {
                    originator.getElements().Item4.BackColor = Color.Gray;
                }
                else
                {
                    originator.getElements().Item4.BackColor = Color.Green;
                }
 

                DisableOrEnableAllCorners((Panel)originator.getElements().Item4.Parent, originator.getElements().Item2, originator.getElements().Item3, true);
                //remove from dictionary
                originator.getElements().Item5.Remove(originator.getElements().Item4);
                //disable corners for buttons in dictionary
                foreach (Button btn in originator.getElements().Item5)
                {
                    DisableOrEnableAllCorners((Panel)btn.Parent, Int32.Parse(btn.Name[0].ToString()), Int32.Parse(btn.Name[1].ToString()), false);
                }
            }
            originator.restore(careTaker.undo());
        }

        void IStateCor.Handle()
        {
            return;
        }

        
    }
}
