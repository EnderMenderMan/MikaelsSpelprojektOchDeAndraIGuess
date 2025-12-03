using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowRune : Rune
{
    [SerializeField] Collider2D playerGrowCheckCollider;
    [SerializeField] float resizeSpeed;
    [SerializeField] float whenActiveSize;
    float origninalSizeDif;
    (float size, float changedSoFar) forceResizeIfCanceledValues;

    public void Activate() => Activate(whenActiveSize);
    public void Activate(float sizeValue)
    {
        origninalSizeDif += sizeValue;
        StartResize(sizeValue, resizeSpeed, true, true);
    }
    public void Deactivate()
    {
        StartResize(-origninalSizeDif, resizeSpeed, false, true);
        origninalSizeDif = 0;
    }

    public void StartResize(float size, float changeSpeed, bool enableCollisonStop, bool forceResizeIfCanceled)
    {
        StopAllCoroutines();
        if (forceResizeIfCanceledValues.size != 0)
        {
            Vector3 scale = PlayerMovement.Instance.transform.localScale;
            float changeSize = forceResizeIfCanceledValues.size - forceResizeIfCanceledValues.changedSoFar;
            PlayerMovement.Instance.transform.localScale = new Vector3(scale.x + changeSize, scale.y + changeSize, scale.z - changeSize);

        }
        forceResizeIfCanceledValues.size = forceResizeIfCanceled ? forceResizeIfCanceledValues.size : 0;
        StartCoroutine(Resize(size, changeSpeed, enableCollisonStop));
    }
    public IEnumerator Resize(float size, float changeSpeed, bool enableCollisonStop)
    {
        float startSize = 0;
        float previusSize = 0;
        Vector3 startScale = PlayerMovement.Instance.transform.localScale;
        while (Mathf.Abs(startSize) <= Mathf.Abs(size))
        {
            startSize += changeSpeed * Mathf.Sign(size) * Time.deltaTime;
            if (Mathf.Abs(startSize) > Mathf.Abs(size))
                startSize = size;

            if (enableCollisonStop && playerGrowCheckCollider != null && playerGrowCheckCollider.IsTouchingLayers())
            {
                startSize = previusSize;
            }

            Vector3 scale = PlayerMovement.Instance.transform.localScale;
            PlayerMovement.Instance.transform.localScale = new Vector3(startScale.x + startSize, startScale.y + startSize, startScale.z + startSize);
            forceResizeIfCanceledValues.changedSoFar = startSize;


            previusSize = startSize;
            yield return null;
        }
    }
}
