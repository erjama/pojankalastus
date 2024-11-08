using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParts : MonoBehaviour
{

    [SerializeField] private GameObject bodypart;

    // Optional position and rotation for spawning
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation = Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPart() {

        if (bodypart != null) {
            
            Instantiate(bodypart, spawnPosition, spawnRotation);
        } 
    }
}
