using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonClick()
    {
        AudioManager.instance.PlaySound("click", true, true);
    }

    public void Animate(Animator anm)
    {
        anm.enabled = true;
        Destroy(anm.gameObject, 1);
    }
}
