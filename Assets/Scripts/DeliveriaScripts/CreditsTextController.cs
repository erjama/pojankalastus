using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditTextsController : MonoBehaviour
{
    public bool isCreditsScrolling = false;

    public RectTransform rectTransform;
    public float moveSpeedAmount = 10f; // speed of the credits
    Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreditsScrolling)
        {
            rectTransform.anchoredPosition += new Vector2(0, moveSpeedAmount * Time.deltaTime);
        }
    }

    public void StartCreditTexts()
    {
        isCreditsScrolling = true;
    }

    public void ResetCredits()
    {
        rectTransform.position = originalPosition;
        isCreditsScrolling = false;
    }
}