using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    public void Scale(float amount)
    {
        transform.localScale = Vector3.one * amount;
    }

    public void ResetScale()
    {
        transform.localScale = Vector3.one;
    }
}
