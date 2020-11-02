using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenEsc : MonoBehaviour
{
    public GameObject EscUI;
    private bool isOpen=false ;
    public Slider soundSlider;
    public Slider viewSlider;
    public AudioSource _audio;
    public  CameraController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = (CameraController)FindObjectOfType(typeof(CameraController)) as CameraController;
        viewSlider.value = 0.3f;
        EscUI.SetActive(false);
        soundSlider.value = _audio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == false)
            {
                EscUI.SetActive(true);
            //    Time.timeScale = 0;
                isOpen = true;
            }

            else {
                EscUI.SetActive(false);
               // Time.timeScale = 1;
                isOpen =false;
            }
            

        }
    }

    public  void ChageSound()
    {
        _audio.volume = soundSlider.value;
    }
    public void ChageViewDis()
    {
        controller.dist =3 +(viewSlider.value-0.3f) * 4;
    }
}
