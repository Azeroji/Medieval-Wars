using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dynamicname : MonoBehaviour
{
  // Start is called before the first frame update

  public Text textToShow;

  public void setname()
  {

    if (PlayerPrefs.HasKey("SavedText"))
    {
      string savedText = PlayerPrefs.GetString("SavedText");
      textToShow.text = "hello " + savedText + ",";
    }
  }
  void Start()
  {

    setname();
  }
  // Update is called once per frame

}
