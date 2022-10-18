using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRoomScript : MonoBehaviour
{
    public GameObject virtualCam;
    //public LeadCameraTrackerScript leadScript;
    private CinemachineVirtualCamera cam;
    //private CinemachineShakeScript activeShakeScript;
    private CinemachineBasicMultiChannelPerlin channel;

    void Awake(){
        cam = virtualCam.GetComponent<CinemachineVirtualCamera>();
        //activeShakeScript = virtualCam.GetComponent<CinemachineShakeScript>();
        channel = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !other.isTrigger){
            virtualCam.SetActive(true);
            LeadCameraTrackerScript.AddActiveCamera(virtualCam, cam, channel);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && !other.isTrigger){
            LeadCameraTrackerScript.RemoveActiveCamera(virtualCam, cam, channel);
            virtualCam.SetActive(false);
        }
    }
}
