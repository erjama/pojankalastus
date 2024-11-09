using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] private GameObject point;
    [SerializeField] AudioClip collectAudio;
    private bool hasItem = false;
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "bodyPart" && hasItem == false) {

            //AudioManager.instance.Play(collectAudio);
            hasItem = true;
            other.gameObject.transform.SetParent(point.gameObject.transform);
            other.gameObject.transform.localPosition = Vector3.zero;
            other.gameObject.GetComponent<BallScript>().enabled = false;

        }
    }


    public void removeItem() {
        hasItem = false;
        
    }
}
