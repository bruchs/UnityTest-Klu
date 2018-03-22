using UnityEngine;

public class Purpouse : Question
{
    [System.Serializable]
    public struct Word
    {
        public string text;
        [HideInInspector]
        public bool hasBeenDetected;
    }

    public Word[] wordsToCheck;

    public override void GenerateQuestion()
    {
        mDescription = "¿Cual es mi propósito?";
        SetAnwser();
    }

    public override void SetAnwser()
    {
        mAnwser = "pasar mantequilla y hacer preguntas";
    }

    public override bool CheckForAnwser(string input)
    {
        // Restart 
        for (int i = 0; i < wordsToCheck.Length; i++)
        {
            wordsToCheck[i].hasBeenDetected = false;
        }

        string[] currentWords = input.Split(' ');

        for(int i = 0; i < wordsToCheck.Length; i++) 
        {
            foreach (string currentWord in currentWords)
            {
                if(wordsToCheck[i].text == currentWord)
                {
                    wordsToCheck[i].hasBeenDetected = true;
                    break;
                }
            }
        }

        foreach(Word word in wordsToCheck)
        {
            if (!word.hasBeenDetected)
            {
                return false;
            }
        }

        return true;
    }
}
