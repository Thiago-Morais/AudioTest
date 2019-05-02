using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(FMODUnity.RuntimeManager.HasBankLoaded("Master Bank"))
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FMODUnity.RuntimeManager.HasBankLoaded("Master Bank"))
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene(1);
        }
    }
}
