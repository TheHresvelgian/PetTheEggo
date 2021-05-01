using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMiniGame : MonoBehaviour
{
    public void Sheepy() => SceneManager.LoadScene(3);

    public void DanceDance() => SceneManager.LoadScene(2);
}
