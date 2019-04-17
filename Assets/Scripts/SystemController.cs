using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{

    private Door door;
    private VideoController vc;
    // Start is called before the first frame update
    void Start()
    {
        vc = GameObject.Find("VideoPlayer").GetComponent<VideoController>();
        
        door = GetComponent<Door>();
        door.onOpen += () => {
            vc.PlayVideo();
        };
        door.onClose += () =>{
            vc.StopVideo();
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
