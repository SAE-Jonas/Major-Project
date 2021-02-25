using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

    public Camera CameraA;
    public Camera CameraB;

    public Material cameraMatA;
    public Material cameraMatB;

    // Start is called before the first frame update
    void Start()
    {
        if (CameraA.targetTexture != null)
        {
            CameraA.targetTexture.Release();
        }
        CameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = CameraA.targetTexture;

        if (CameraB.targetTexture != null)
        {
            CameraB.targetTexture.Release();
        }
        CameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = CameraB.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
