using System.Collections;
using UnityEngine;

public class DisappearAppear : MonoBehaviour
{
    public float shrinkScale = 0.1f;
    public float growScale = 2f;
    public float animationTime = 0.5f;

    private Vector3 originalScale;
    private bool isDisappearing = false;
    private bool isAppearing = false;
    private bool isFullyAppeared = true;
    private bool isFullyDisappeared = false;

    private Coroutine disappearCoroutine;
    private Coroutine appearCoroutine;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void Disappear()
    {
        if (isFullyAppeared)
        {
            if (appearCoroutine != null)
            {
                StopCoroutine(appearCoroutine);
            }
            disappearCoroutine = StartCoroutine(DoDisappear());
        }
        else if (isAppearing)
        {
            StopCoroutine(appearCoroutine);
            disappearCoroutine = StartCoroutine(DoDisappear());
        }
    }

    public void Appear()
    {
        if (isFullyDisappeared)
        {
            gameObject.SetActive(true);
            appearCoroutine = StartCoroutine(DoAppear());
        }
        else if (isDisappearing)
        {
            StopCoroutine(disappearCoroutine);
            appearCoroutine = StartCoroutine(DoAppear());
        }
    }

    IEnumerator DoDisappear()
    {
        if (isDisappearing) yield break;

        isDisappearing = true;
        isAppearing = false;
        isFullyAppeared = false;
        float timer = 0f;
        float startScale = transform.localScale.x;
        while (timer < animationTime)
        {
            timer += Time.deltaTime;
            float scale = Mathf.Lerp(startScale, shrinkScale, timer / animationTime);
            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
        transform.localScale = new Vector3(shrinkScale, shrinkScale, shrinkScale);
        gameObject.SetActive(false);
        isDisappearing = false;
        isFullyDisappeared = true;
    }

    IEnumerator DoAppear()
    {
        if (isAppearing) yield break;

        isFullyDisappeared = false;
        isDisappearing = false;
        isAppearing = true;
        float timer = 0f;
        float startScale = transform.localScale.x;
        while (timer < animationTime)
        {
            timer += Time.deltaTime;
            float scale = Mathf.Lerp(startScale, originalScale.x * growScale, timer / animationTime);
            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
        transform.localScale = originalScale;
        isAppearing = false;
        isFullyAppeared = true;
    }
}
