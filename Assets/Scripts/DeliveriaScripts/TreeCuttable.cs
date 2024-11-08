using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    [SerializeField] AudioClip audioClipTreeHit;

    public override void Hit()
    {
        AudioManager.instance.Play(audioClipTreeHit);
        SpawnTreeLogs();
        Destroy(gameObject);
    }

    private void SpawnTreeLogs()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }
    }
}
