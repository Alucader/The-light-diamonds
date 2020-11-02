using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.ComponentModel;
public class WinLoad : MonoBehaviour
{
    [SerializeField] static string strNextNmae;
    public string reLoadName;
    public string nextName;
    public Text test;
    public Slider slider;
    [SerializeField] float lerp;
    AsyncOperation async;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Loading")
        {
            lerp = 0;
            async = SceneManager.LoadSceneAsync(strNextNmae);
            async.allowSceneActivation = false;
        }
    }

    public void PtLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        strNextNmae = nextName;
        Debug.Log(strNextNmae);
        SceneManager.LoadScene("Loading");
    }
    public void ReloadScene()
    {
        strNextNmae = reLoadName;
        Debug.Log(strNextNmae);
        SceneManager.LoadScene("Loading");
    }

    // Update is called once per frame
    void Update()
    {
        if (test && slider)
        {
            lerp = Mathf.Lerp(lerp, async.progress, Time.deltaTime);
            test.text = ((int)(lerp / 9 * 10 * 100)).ToString() + "%";
            slider.value = lerp / 9 * 10;
            if (lerp / 9 * 10 >= 0.98)
            {
                test.text = "100%";
                slider.value = 1;
                async.allowSceneActivation = true;
            }
        }


    }
}
