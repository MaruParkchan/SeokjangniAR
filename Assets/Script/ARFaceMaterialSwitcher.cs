using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARFaceMaterialSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    public TextMeshProUGUI text;

    private ARFaceManager faceManager;
    private int switchIndex = 0;

    private void Awake()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0];
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            FaceMeterialSwitch();
        }
    }

    public void SwitchFace(int num)
    {
        switchIndex = num;
        faceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[switchIndex];
    }

    private void FaceMeterialSwitch()
    {
        switchIndex = (switchIndex + 1) % materials.Length;

        foreach(ARFace face in faceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[switchIndex];
        }
    }
}
