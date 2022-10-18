using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LeadCameraTrackerScript : MonoBehaviour
{
    //public static CinemachineVirtualCamera activeCam;
    //public static GameObject[] currentCam;
    public static List<GameObject> cams = new List<GameObject>();
    //public static CinemachineShakeScript activeShakeScript;
    //public static CinemachineVirtualCamera[] virtualCamera;
    public static List<CinemachineVirtualCamera> virCams = new List<CinemachineVirtualCamera>();
    //public static CinemachineBasicMultiChannelPerlin[] channel;
    public static List<CinemachineBasicMultiChannelPerlin> channels = new List<CinemachineBasicMultiChannelPerlin>();

    public static void AddActiveCamera(GameObject newCam, CinemachineVirtualCamera newVir, CinemachineBasicMultiChannelPerlin newChannel){
        cams.Add(newCam);
        virCams.Add(newVir);
        channels.Add(newChannel);
        //currentCam = newCam;
        //activeShakeScript = newCam.GetComponent<CinemachineShakeScript>();
        //activeShakeScript = newShake;
        //virtualCamera = newVir;
        //channel = newChannel;
        Debug.Log("New Camera Set");
    }

    public static void RemoveActiveCamera(GameObject newCam, CinemachineVirtualCamera newVir, CinemachineBasicMultiChannelPerlin newChannel){
        int reps = 0;
        while(cams.Contains(newCam)){
            cams.Remove(newCam);
            reps++;
            if(reps > 50){
                return;
            }
        }
        reps = 0;
        while(virCams.Contains(newVir)){
            virCams.Remove(newVir);
            reps++;
            if(reps > 50){
                return;
            }
        }
        reps = 0;
        while(channels.Contains(newChannel)){
            channels.Remove(newChannel);
            reps++;
            if(reps > 50){
                return;
            }
        }
    }
}
