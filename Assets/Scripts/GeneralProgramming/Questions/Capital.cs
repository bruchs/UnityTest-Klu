using UnityEngine;

public class Capital : Question
{
    [System.Serializable]
    public struct Country
    {
        public string countryName;
        public string capitalName;
    }

    public Country[] countries;
    private Country currentCountry;

    public override void GenerateQuestion()
    {
        currentCountry = countries[Random.Range(0, countries.Length - 1)];

        mDescription = "¿Cual es la capital de " + currentCountry.countryName + "?";
        SetAnwser();
    }

    public override void SetAnwser()
    {
        mAnwser = currentCountry.capitalName;
    }

    public override bool CheckForAnwser(string input)
    {
        if(mAnwser == input)
        {
            return true;
        }

        return false;
    }
}
