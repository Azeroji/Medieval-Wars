using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadonBoardingsScene : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }
  public GameObject nameInput;
  public GameObject ageInput;
  public GameObject passwordInput;

  public GameObject errorText;


  public void loadtoOnBoardingScenes()
  {
    errorText.SetActive(false);
    if (nameInput.GetComponent<InputField>().text != "" && ageInput.GetComponent<InputField>().text != "" && passwordInput.GetComponent<InputField>().text != "")
    {
      SceneManager.LoadScene("onBoardingScene1");

    }
    else
    {
      errorText.SetActive(true);

    }

  }
   public Text textToSave;

    public void SaveText()
    {
        PlayerPrefs.SetString("SavedText", textToSave.text);
        PlayerPrefs.Save();
    }


  // Update is called once per frame
  void Update()
  {
    SaveText();

  }
}
