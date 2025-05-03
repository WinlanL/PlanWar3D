using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public Material skyboxMaterial;

    // �����ٶ�
    public float transitionSpeed = 1.0f;

    // �Ƿ������Զ�����
    public bool autoTransition = true;

    void Update()
    {
        if (skyboxMaterial == null)
        {
            Debug.LogWarning("Skybox material is not assigned!");
            return;
        }

        if (autoTransition)
        {
            // ���㵱ǰ�Ƕȣ�0 �� 180 ѭ����
            float angle = Mathf.PingPong(Time.time * transitionSpeed, 180.0f);
            float angle2 = Mathf.PingPong(Time.time * transitionSpeed * 2, 180.0f);

            // ���� _DirectionYaw �� _DirectionPitch
            skyboxMaterial.SetFloat("_DirectionYaw", angle);
            skyboxMaterial.SetFloat("_DirectionPitch", angle2);
        }
    }

    // �ֶ����ýǶ�
    public void SetDirectionAngles(float yaw, float pitch)
    {
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetFloat("_DirectionYaw", yaw);
            skyboxMaterial.SetFloat("_DirectionPitch", pitch);
        }
    }

    // ���ýǶ�
    public void ResetDirectionAngles()
    {
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetFloat("_DirectionYaw", 0);
            skyboxMaterial.SetFloat("_DirectionPitch", 0);
        }
    }
}
