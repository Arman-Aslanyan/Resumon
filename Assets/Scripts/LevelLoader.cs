using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    public Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }

    public void StartEncounter()
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        canvas.enabled = true;
        FindObjectOfType<GameManager>().BeginEncounter();
        transition.SetTrigger("End");
    }
}
