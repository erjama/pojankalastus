using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] private GameObject point;
    private bool hasItem = false;

    [SerializeField] AudioClip audioClipCollectItem;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "bodyPart" && hasItem == false) {

            hasItem = true;
            other.gameObject.transform.SetParent(point.gameObject.transform);
            other.gameObject.transform.localPosition = Vector3.zero;
            other.gameObject.GetComponent<BallScript>().enabled = false;
            var rb= other.gameObject.GetComponent<Rigidbody>();
            Destroy(rb);
            AudioManager.instance.Play(audioClipCollectItem);
        }
    }

    public void removeItem() {
        hasItem = false; 
    }
}
