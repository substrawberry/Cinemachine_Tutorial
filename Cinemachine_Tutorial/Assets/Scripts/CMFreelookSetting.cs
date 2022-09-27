using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMFreelookSetting : MonoBehaviour
{
    CinemachineFreeLook freeLook;
    public float scrollSpeed = 2000.0f;
    void Awake()
    {
        CinemachineCore.GetInputAxis = clickControl;
    }

    void Start()
    {
        // Target 설정
        freeLook = this.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = GameObject.Find("PlayerArmature").transform;
        freeLook.LookAt = GameObject.Find("PlayerCameraRoot").transform;

        // Lens 설정
        freeLook.m_Lens.FieldOfView = 50;
        freeLook.m_Lens.NearClipPlane = 0.2f;
        freeLook.m_Lens.FarClipPlane = 4000;
        freeLook.m_Lens.Dutch = 0;
        freeLook.m_Lens.ModeOverride = LensSettings.OverrideModes.None;

        // Axis Control 설정
        freeLook.m_XAxis.Value = 0;
        freeLook.m_XAxis.m_MaxSpeed = 300;
        freeLook.m_XAxis.m_AccelTime = 0.1f;

        // Rig 설정
        CinemachineComposer composer = freeLook.GetRig(1).GetCinemachineComponent<CinemachineComposer>();
        composer.m_DeadZoneHeight = 0.3f;
        composer.m_DeadZoneWidth = 0.5f;
    }

    public float clickControl(string axis)
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        freeLook.m_Lens.FieldOfView += scrollWheel * Time.deltaTime * scrollSpeed;

        if (Input.GetMouseButton(0))
            return UnityEngine.Input.GetAxis(axis);

        return 0;
    }
}