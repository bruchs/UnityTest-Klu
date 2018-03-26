using UnityEngine;

public abstract class BaseCard : ScriptableObject
{
    public Sprite artwork;
    public new string  name;
    public string description;
    public string legend;

    public Behavior invokeBehavior;
    public Behavior destroyBehavior;

    public void OnCardInvoke()
    {
        invokeBehavior.Behave();
    }

    public void OnCardDestroy()
    {
        destroyBehavior.Behave();
    }
}
