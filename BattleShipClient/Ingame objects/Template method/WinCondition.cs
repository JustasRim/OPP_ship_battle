namespace BattleShipClient.Ingame_objects.Template_method
{
    public class WinCondition
    {
        public virtual bool GameWon(Unit hitUnit, int damage, int remainingUnits)
        {
            return false;
        }
    }

    public class FirstDestroyed : WinCondition
    {
        public sealed override bool GameWon(Unit hitUnit, int damage, int remainingUnits)
        {
            if (hitUnit.CanTakeDamage(damage))
            {
                var dmgTaken = hitUnit.GetDamageTaken(damage);

                if (hitUnit.Health - dmgTaken <= 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }

    public class AllDestroyed : WinCondition
    {
        public sealed override bool GameWon(Unit hitUnit, int damage, int remainingUnits)
        {
            if (hitUnit.CanTakeDamage(damage))
            {
                var dmgTaken = hitUnit.GetDamageTaken(damage);

                if (hitUnit.Health - dmgTaken <= 0 && remainingUnits == 1)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
