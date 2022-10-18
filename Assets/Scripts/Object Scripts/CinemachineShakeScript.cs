using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShakeScript : MonoBehaviour
{
    //private CinemachineVirtualCamera virtualCamera;
    //private CinemachineBasicMultiChannelPerlin channel;
    public static CinemachineShakeScript instance;
    private float timer;
    private float startIntensity;
    //private float startTime;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        /*
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if(virtualCamera != null){
            Debug.Log("Virtual Camera Found!");
        }
        channel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if(channel != null){
            Debug.Log("Channel Found!");
        }
        */
    }

    public void ShakeCamera(float intensity, float time){
        foreach(CinemachineBasicMultiChannelPerlin cha in LeadCameraTrackerScript.channels){
            cha.m_AmplitudeGain = intensity;
        }
        //LeadCameraTrackerScript.channel.m_AmplitudeGain = intensity;
        startIntensity = intensity;
        timer = time;
        //startTime = time;
    }

    void Update(){
        if(timer > 0){
            timer -= Time.deltaTime;
            if(timer <= 0){
                foreach(CinemachineBasicMultiChannelPerlin cha in LeadCameraTrackerScript.channels){
                    cha.m_AmplitudeGain = 0;
                }
            }
            else{
                
                //LeadCameraTrackerScript.channel.m_AmplitudeGain = Mathf.Lerp(startIntensity, 0, 1 - (timer / startTime));
                foreach(CinemachineBasicMultiChannelPerlin cha in LeadCameraTrackerScript.channels){
                    //cha.m_AmplitudeGain = Mathf.Lerp(startIntensity, 0, 1 - (timer / startTime));
                    cha.m_AmplitudeGain = startIntensity;
                }
            }
        }
        else{
            foreach(CinemachineBasicMultiChannelPerlin cha in LeadCameraTrackerScript.channels){
                cha.m_AmplitudeGain = 0;
            }
        }
    }
}
