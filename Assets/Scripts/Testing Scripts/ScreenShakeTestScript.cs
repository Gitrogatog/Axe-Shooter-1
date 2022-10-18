using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            //LeadCameraTrackerScript.activeShakeScript.ShakeCamera(2, 5);
            CinemachineShakeScript.instance.ShakeCamera(2, 5);
            //CinemachineShakeScript shakeScript = LeadCameraTrackerScript.activeCam.GetComponent<CinemachineShakeScript>();
            //shakeScript.ShakeCamera(1, 2);
        }
    }
}
