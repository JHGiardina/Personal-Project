using UnityEngine;
using System.Collections;
//THIS IS A CHATGPT SCRIPT
public class CursorLock : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CursorLockLoop());;
    }

     IEnumerator CursorLockLoop()
    {
        while (true) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                yield break; 
            }

            yield return null; 
    }
}
}
