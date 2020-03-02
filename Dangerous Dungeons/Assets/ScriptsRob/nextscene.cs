using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscene : MonoBehaviour
{
    Canvas can;
    private void Start()
    {
        can = GetComponentInChildren<Canvas>();
        can.enabled = false;
    }

    public void goNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        can.enabled = true;
    }
}
