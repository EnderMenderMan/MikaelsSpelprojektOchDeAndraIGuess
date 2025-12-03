using UnityEngine;

public class GrowRune : Rune
{
    [SerializeField] float whenActiveSize;
    float origninalSizeDif;

    public void Activate() => Activate(whenActiveSize);
    public void Activate(float sizeValue)
    {
        origninalSizeDif += sizeValue;
        Vector3 scale = PlayerMovement.Instance.transform.localScale;
        Debug.Log("Activate");
        PlayerMovement.Instance.transform.localScale = new Vector3(scale.x + sizeValue, scale.y + sizeValue, scale.z + sizeValue);

    }
    public void Deactivate()
    {
        Vector3 scale = PlayerMovement.Instance.transform.localScale;
        PlayerMovement.Instance.transform.localScale = new Vector3(scale.x - origninalSizeDif, scale.y - origninalSizeDif, scale.z - origninalSizeDif);
        origninalSizeDif = 0;
    }
}
