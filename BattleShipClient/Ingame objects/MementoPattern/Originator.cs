using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.MementoPattern
{
    public class Originator
    {
        private ITile tile;
        private int x;
        private int y;
        private Button button;
        private List<Button> selectedButtons;

        public Originator()
        {

        }

        public void setElements(ITile tile,int x, int y, Button button, List<Button> selectedButtons)
        {
            this.tile = tile;
            this.x = x;
            this.y = y;
            this.button = button;
            this.selectedButtons = selectedButtons;
        }

        public (ITile,int,int,Button,List<Button>) getElements()
        {
            return (this.tile,this.x,this.y,this.button,this.selectedButtons);
        }

        public Memento save()
        {
            return new Memento(tile,x,y,button,selectedButtons);
        }

        public void restore(Memento m)
        {
            (this.tile,this.x,this.y, this.button, this.selectedButtons) = m.getState();
        }

    }
}
