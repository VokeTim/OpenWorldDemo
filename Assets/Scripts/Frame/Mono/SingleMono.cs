using UnityEngine;

public class SingleMono<T> : MonoBehaviour where T : SingleMono<T>
{
    public static T Instance;

    protected virtual void Init()
    {
        if (Instance == null) 
        {
            Instance = (T)this;
        }
    }
}
