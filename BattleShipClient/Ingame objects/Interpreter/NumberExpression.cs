namespace BattleShipClient.Ingame_objects.Interpreter
{
    public class NumberExpression : Expression
    {
        private readonly int _value;

        public NumberExpression(int value)
        {
            _value = value;
        }

        public override int Interpreter()
        {
            return _value;
        }
    }
}
