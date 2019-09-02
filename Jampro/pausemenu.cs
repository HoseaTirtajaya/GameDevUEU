using UnityEngine;
using UnityEngine.UI; // We need to edit text components
using UnityEngine.EventSystems; // And determine if our mouse is hovering
using UnityEngine.SceneManagement; // And have access to switching scenes.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("PauseMenu");
        }
    }
}
