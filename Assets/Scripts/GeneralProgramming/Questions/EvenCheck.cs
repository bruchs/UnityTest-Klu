using UnityEngine;

public class EvenCheck : Question
{
    private int currentX;

    public override void GenerateQuestion()
    {
        currentX = Random.Range(1, 10000);
        mDescription = currentX + " es par o impar?";
        SetAnwser();
    }

    public override void SetAnwser()
    {
        if(currentX % 2 == 0)
        {
            mAnwser = "par";
        }
        else
        {
            mAnwser = "impar";
        }
    }

    public override bool CheckForAnwser(string input)
    {
        if (input == mAnwser)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
