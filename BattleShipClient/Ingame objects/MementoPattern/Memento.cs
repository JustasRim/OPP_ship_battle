using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.MementoPattern
{
    public class Memento
    {

        private ITile tileState;
        private int x;
        private int y;
        private Button buttonState;
        private List<Button> selectedButtonsState;

        public Memento(ITile tileSate,int x, int y, Button buttonState, List<Button> selectedButtonsState)
        {
            this.tileState = tileSate;
            this.x = x;
            this.y = y;
            this.buttonState = buttonState;
            this.selectedButtonsState = selectedButtonsState;
        }

        public (ITile,int,int, Button, List<Button>) getState()
        {
            return (this.tileState,this.x, this.y, this.buttonState, this.selectedButtonsState);
        }

        public void setState(ITile tileSate,int x, int y, Button buttonState, List<Button> selectedButtonsState)
        {
            this.tileState = tileSate;
            this.x = x;
            this.y = y;
            this.buttonState = buttonState;
            this.selectedButtonsState = selectedButtonsState;
        }
    }
}
