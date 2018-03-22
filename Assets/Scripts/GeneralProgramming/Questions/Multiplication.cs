using UnityEngine;

public class Multiplication : Question
{
    private int currentX;
    private int currentY;

    public override void GenerateQuestion()
    {
        currentX = Random.Range(1, 1000);
        currentY = Random.Range(1, 1000);
        mDescription = "Cuánto es " + currentX + " * " + currentY;

        SetAnwser();
    }

    public override void SetAnwser()
    {
        mAnwser = (currentX * currentY).ToString();
    }

    public override bool CheckForAnwser(string input)
    {
        int cAnwser = 0;
        bool isInteger = int.TryParse(input, out cAnwser);

        if (isInteger)
        {
            if (cAnwser.ToString() == mAnwser)
            {
                return true;
            }
        }

        return false;
    }
}
