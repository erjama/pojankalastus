using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Scare : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RawImage monster;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowMonster (){

        monster.gameObject.SetActive(true);
    }

    public void HideMonster() {

        monster.gameObject.SetActive(false);
    }
}
