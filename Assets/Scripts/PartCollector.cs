using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject rake;
    [SerializeField] GameObject lemminkainen;
    private PickUp pickUp;
    Renderer[] childRenderers;
    void Start()
    {
        pickUp = rake.GetComponent<PickUp>();
        childRenderers = lemminkainen.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bodyPart")
        {

            pickUp.removeItem();
            var name = other.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.name;
            buildBody(name);
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled= false;
        }
    }

    public void buildBody(string part)
    {

        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject.name == part)
            {

                renderer.enabled = true;
            }
        }
    }
}
