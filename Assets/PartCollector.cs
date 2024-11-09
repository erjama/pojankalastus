using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject rake;
    private PickUp pickUp;
    void Start()
    {
        pickUp = rake.GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "bodyPart") {

            pickUp.removeItem();
            buildBody(other.gameObject.name);
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled= false;
        }
    }

    public void buildBody(string part) {

        Debug.Log(part);
    
    }
}
