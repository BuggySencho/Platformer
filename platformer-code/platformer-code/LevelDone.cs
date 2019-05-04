using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDone : MonoBehaviour
{
    public GameObject marine;
    public marineScript marineBehaviourScript;

    void Start()
    {
        marineBehaviourScript = marine.GetComponent<marineScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("levelComplete");
        marine.SetActive(true);
    }
}
