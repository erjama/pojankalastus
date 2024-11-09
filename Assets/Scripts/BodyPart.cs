using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPart : MonoBehaviour
{

    [SerializeField] private GameObject point;
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "harava") {

            this.transform.SetParent(point.gameObject.transform);
            this.GetComponent<BallScript>().enabled = false;
            
        }
    }

}
