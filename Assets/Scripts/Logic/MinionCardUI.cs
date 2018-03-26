using UnityEngine;
using UnityEngine.UI;

public class MinionCardUI : BaseCardUI
{
    public Text UIGoldCost;
    public Text UIAttackPoints;
    public Text UIAttributes;
    private MinionCard currentCard;

    private new void Start()
    {
        base.Start();

        currentCard = cardData as MinionCard;
        UIGoldCost.text = currentCard.goldCost.ToString();
        UIAttackPoints.text = currentCard.attackPoints.ToString();

        if (currentCard.Atributtes != 0)
        {
            UIAttributes.text = currentCard.Atributtes.ToString();
        }
    }

    public void AddDamagePointsButton(int pointsToAdd)
    {
        currentCard.AddDamagePoints(pointsToAdd);
        UIAttackPoints.text = currentCard.attackPoints.ToString();
    }

    public void RestDamagePointsButton(int pointsToRest)
    {
        currentCard.RestDamagePoints(pointsToRest);
        UIAttackPoints.text = currentCard.attackPoints.ToString();
    }

    public void DestroyCardButton()
    {
        Destroy(gameObject);
    }
}
