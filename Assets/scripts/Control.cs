using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
  public void Controls()
{
    SceneManager.LoadSceneAsync(2);
}
}
