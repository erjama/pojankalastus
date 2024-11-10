using UnityEngine;
using UnityEngine.SceneManagement;

public class PartCollector : MonoBehaviour
{
    private const int ALL_PIECES_COLLECTED_COUNT = 7;
    private const string END_SCENE_NAME = "sepinscene";
    [SerializeField] GameObject rake;
    [SerializeField] GameObject lemminkainen;
    private PickUp pickUp;
    Renderer[] childRenderers;
    private int collectedPieces = 0;

    [SerializeField] AudioClip setPartAudio;

    void Start()
    {
        pickUp = rake.GetComponent<PickUp>();
        childRenderers = lemminkainen.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedPieces == ALL_PIECES_COLLECTED_COUNT)
        {
            SceneManager.LoadScene(END_SCENE_NAME);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bodyPart")
        {
            pickUp.removeItem();
            var name = other.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.name;
            buildBody(name);
            AudioManager.instance.Play(setPartAudio);
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
