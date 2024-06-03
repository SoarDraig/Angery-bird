using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    IEnumerator Start()
    {
        // 致敬华为
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1 );
    }
    
    void Update()
    {
        
    }
}
