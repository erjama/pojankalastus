using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] AudioClip audioClipButtonHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.Play(audioClipButtonHover);
        Debug.Log("Mouse is over the button: " + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse has left the button: " + gameObject.name);
    }
}
