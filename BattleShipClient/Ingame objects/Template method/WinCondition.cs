namespace BattleShipClient.Ingame_objects.Template_method
{
    public class WinCondition
    {
        public bool UnitCanTakeDamage(Unit hitUnit, int damage)
        {
            return hitUnit.CanTakeDamage(damage);
        }

        public virtual bool PassesWinCondition(Unit hitUnit, int damage, int remainingUnits)
        {
            return false;
        }

        public bool GameWon(Unit hitUnit, int damage, int remainingUnits)
        {
            if (UnitCanTakeDamage(hitUnit, damage))
            {
                return PassesWinCondition(hitUnit, damage, remainingUnits);
            }
            else return false;
        }
    }

    public class FirstDestroyed : WinCondition
    {
        public sealed override bool PassesWinCondition(Unit hitUnit, int damage, int remainingUnits)
        {
            var dmgTaken = hitUnit.GetDamageTaken(damage);

            return (hitUnit.Health - dmgTaken <= 0);
        }
    }

    public class AllDestroyed : WinCondition
    {
        public sealed override bool PassesWinCondition(Unit hitUnit, int damage, int remainingUnits)
        {
            var dmgTaken = hitUnit.GetDamageTaken(damage);

            return (hitUnit.Health - dmgTaken <= 0 && remainingUnits == 1);
        }
    }
}
