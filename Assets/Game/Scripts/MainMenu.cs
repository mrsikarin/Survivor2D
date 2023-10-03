using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float timeScale = 1f;
    public GameObject target;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
   // public void scaleUp()
  //  {
   //   //  target.transform.LeanScale(Vector3.one*2,timeScale);
        //transform.LeanScale
   // }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator ScaleUp()
    {
        target.transform.LeanScale(Vector3.one*scale,timeScale);
        yield return new WaitForSeconds(timeScale);
        target.transform.LeanScale(Vector3.one,timeScale);
        yield return new WaitForSeconds(timeScale);
        StartCoroutine(ScaleUp());
    }
}
