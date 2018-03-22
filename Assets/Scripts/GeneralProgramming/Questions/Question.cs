using UnityEngine;

public abstract class Question : MonoBehaviour
{
    protected string mDescription;
    protected string mAnwser;

    public abstract void GenerateQuestion();
    public abstract void SetAnwser();
    public abstract bool CheckForAnwser(string input);

    /* Getters */
    public string GetAnwser() { return mAnwser; }
    public string GetDescription() { return mDescription; }
}
