using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public float levelOpen = 0.9f;
    public float levelClose = 0.2f;
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
        float depth = 255.0f - leapImage.GetDepth();
        depth /= 255.0f;
        
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
