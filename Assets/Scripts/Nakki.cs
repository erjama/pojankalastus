using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nakki : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip laughter;
    [SerializeField] Scare scare;
    [SerializeField] FirstPersonController firstPersonController;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "PlayerMummo")
        {
            AudioManager.instance.Play(laughter);
            scare.ShowMonster();
            StartCoroutine(transformPlayer());
        }
    }

    IEnumerator transformPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        firstPersonController.transformPlayerToStart();
    }
}
