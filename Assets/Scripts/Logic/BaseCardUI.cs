using UnityEngine;
using UnityEngine.UI;

public class BaseCardUI : MonoBehaviour
{
    public BaseCard cardData;

    public Image UIArtwork;
    public Text UIDescription;
    public Text UIName;
    public Text UILegend;

    public void Start()
    {
        if(cardData != null)
        {
            UIArtwork.sprite = cardData.artwork;
            UIDescription.text = cardData.description;
            UIName.text = cardData.name;
            UILegend.text = cardData.legend;
        }
    }
}
