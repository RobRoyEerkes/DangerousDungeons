using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscene : MonoBehaviour
{
    private void Start()
    {
        this.enabled = false;
    }
    public void goNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        this.
    }
}
