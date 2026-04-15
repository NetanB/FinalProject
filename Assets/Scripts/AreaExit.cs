using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    private float waitToLoad = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()   )
        {
            
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            UIFade.Instance.FadetoBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }
    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoad >= 0)
        {
            waitToLoad -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
