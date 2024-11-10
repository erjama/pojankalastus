using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(backToMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator backToMainMenu() {
        yield return new WaitForSeconds(14.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
