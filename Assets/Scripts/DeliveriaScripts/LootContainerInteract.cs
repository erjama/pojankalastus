using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] AudioClip audioClipOpenChest;
    [SerializeField] AudioClip audioClipCloseChest;

    public override void Interact(Character character)
    {
        if (opened == false)
        {
            OpenChest();
        }
        else
        {
            CloseChest();
        }
    }

    private void CloseChest()
    {
        opened = false;
        closedChest.SetActive(true);
        openedChest.SetActive(false);
        AudioManager.instance.Play(audioClipCloseChest);
    }

    private void OpenChest()
    {
        opened = true;
        closedChest.SetActive(false);
        openedChest.SetActive(true);
        AudioManager.instance.Play(audioClipOpenChest);
    }
}


