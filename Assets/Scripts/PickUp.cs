using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] private GameObject point;
    private bool hasItem = false;

    [SerializeField] AudioClip audioClipCollectItem;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "bodyPart" && hasItem == false) {

            animator.SetBool("pickUp", true);
            StartCoroutine(waitPickUpAnimation(other));
        }
    }

    IEnumerator waitPickUpAnimation(Collider other) {
        yield return new WaitForSeconds(1.0f);
        hasItem = true;
        other.gameObject.transform.SetParent(point.gameObject.transform);
        other.gameObject.transform.localPosition = Vector3.zero;
        other.gameObject.GetComponent<BallScript>().enabled = false;
        var rb = other.gameObject.GetComponent<Rigidbody>();
        Destroy(rb);
        AudioManager.instance.Play(audioClipCollectItem);
        animator.SetBool("pickUp", false);
    }

    public void removeItem() {
        hasItem = false; 
    }
}
