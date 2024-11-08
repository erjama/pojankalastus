using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float timeToLeave = 10f; //10 seconds
    [SerializeField] AudioClip audioClipItemPickedUp;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        /* Uncomment to make item dissappear after 10 seconds by itself 
        timeToLeave += Time.deltaTime;
        if (timeToLeave < 0)
        {
            Destroy(gameObject);
        }
        */

        float distance = Vector3.Distance(transform.position, player.position);
        //guard clause
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
             transform.position,
             player.position,
             speed * Time.deltaTime
            );

        if (distance < 0.1f)
        {
            AudioManager.instance.Play(audioClipItemPickedUp);
            Destroy(gameObject);
        }
    }
}
