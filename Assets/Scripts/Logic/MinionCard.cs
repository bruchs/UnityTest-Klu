using UnityEngine;

[System.Flags]
public enum CardAttributes
{
    Furia = (1 << 0),
    Imbloquiable = (1 << 1),
    Indesterrable = (1 << 2),
    Alimentar = (1 << 3),
    Unica = (1 << 4)
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Minion")]
public class MinionCard : BaseCard
{
    public int goldCost;
    public int attackPoints;

    public Behavior attackBehavior;
    public Behavior defenseBehavior;

    [SerializeField][EnumFlag]
    public CardAttributes Atributtes;

    public void OnAttack()
    {
        attackBehavior.Behave();
    }

    public void OnDefence()
    {
        defenseBehavior.Behave();
    }

    public void AddDamagePoints(int pointsToAdd)
    {
        attackPoints += pointsToAdd;
    }

    public void RestDamagePoints(int pointsToRest)
    {
        attackPoints -= pointsToRest;
    }
}
