using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPart : MonoBehaviour
{

    [SerializeField] private GameObject point;
    [SerializeField] AudioClip collectAudio;
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "harava") {

            Debug.Log("harava");
            //AudioManager.instance.Play(collectAudio);
            this.transform.SetParent(point.gameObject.transform);
            this.GetComponent<BallScript>().enabled = false;
            
        }
    }

}
