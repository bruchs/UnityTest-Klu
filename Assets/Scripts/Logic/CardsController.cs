using Boo.Lang;
using UnityEngine;

public class CardsController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardContainer;
    public BaseCard[] cards;
    private List<GameObject> currentCards;

    private void Start()
    {
        currentCards = new List<GameObject>();
    }

    public void InitializeCards()
    {
        foreach(GameObject cardGO in currentCards)
        {
            Destroy(cardGO);
        }

        foreach (BaseCard currentCard in cards)
        {
            GameObject cardGameObject = Instantiate(cardPrefab);
            BaseCardUI cardUI = cardGameObject.GetComponent<BaseCardUI>();
            cardUI.cardData = currentCard;

            cardGameObject.transform.SetParent(cardContainer);
            currentCards.Add(cardGameObject);
        }
    } 
}
