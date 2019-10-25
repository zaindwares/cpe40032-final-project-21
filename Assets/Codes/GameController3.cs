using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    // Start is called before the first frame update
    public void onPlayButtonClick()
    {
        SceneManager.LoadScene("Proj Sana");
    }
}
