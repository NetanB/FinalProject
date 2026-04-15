using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneManagement : Singleton<SceneManagement>
{
  public string SceneTransitionName {get; private set;}

  public void SetTransitionName(string sceneTransitionName)
  {
    this.SceneTransitionName = sceneTransitionName;
  }
}
