using UnityEngine;
using UnityEngine.SceneManagement;

public class PartCollector : MonoBehaviour
{
    [SerializeField] GameObject rake;
    [SerializeField] GameObject lemminkainen;
    private PickUp pickUp;
    Renderer[] childRenderers;
    private int collectedPieces = 0;

    void Start()
    {
        pickUp = rake.GetComponent<PickUp>();
        childRenderers = lemminkainen.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedPieces == 7) {

            SceneManager.LoadScene("sepinscene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bodyPart")
        {

            pickUp.removeItem();
            var name = other.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.name;
            buildBody(name);
            Destroy(other.gameObject);
        }
    }

    public void buildBody(string part)
    {
        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject.name == part)
            {
                collectedPieces++; 
                renderer.enabled = true;
            }
        }
    }
}
