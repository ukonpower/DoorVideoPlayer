using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public int levelOpen = 30;
    public int levelClose = 100;
    

    public GameObject leap;

    public event Action onClose;
    public event Action onOpen;
    
    private bool isOpen = false;
    private LeapImageRetriever leapImage;

    // Start is called before the first frame update
    void Start()
    {
        leapImage = leap.GetComponent<LeapImageRetriever>();
    }

    // Update is called once per frame
    void Update()
    {
        int depth = 255 - leapImage.GetDepth();
        if(isOpen){
            if(depth < levelClose){
                Close();
            }
        }else{
            if(depth > levelOpen){
                Open();
            }
        }
    }

    void Open(){
        Debug.Log("open");
        if(onOpen != null){
            onOpen();
        }
        isOpen = true;
    }
    void Close(){
        Debug.Log("close");
        if(onClose != null){
            onClose();
        }
        isOpen = false;
    }
}
