using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }
  public GameObject progressbar;

  // Update is called once per frame
  public void loadsigninscene()
  {
    if (progressbar.GetComponent<SpriteRenderer>().sprite.name == "Progress=10")
    {
      SceneManager.LoadScene("SignIn Scene");

    }
  }
  void Update()
  {
    loadsigninscene();


  }
}
