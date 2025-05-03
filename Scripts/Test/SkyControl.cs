using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public Material skyboxMaterial;

    // 过渡速度
    public float transitionSpeed = 1.0f;

    // 是否启用自动过渡
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
            // 计算当前角度（0 到 180 循环）
            float angle = Mathf.PingPong(Time.time * transitionSpeed, 180.0f);
            float angle2 = Mathf.PingPong(Time.time * transitionSpeed * 2, 180.0f);

            // 设置 _DirectionYaw 和 _DirectionPitch
            skyboxMaterial.SetFloat("_DirectionYaw", angle);
            skyboxMaterial.SetFloat("_DirectionPitch", angle2);
        }
    }

    // 手动设置角度
    public void SetDirectionAngles(float yaw, float pitch)
    {
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetFloat("_DirectionYaw", yaw);
            skyboxMaterial.SetFloat("_DirectionPitch", pitch);
        }
    }

    // 重置角度
    public void ResetDirectionAngles()
    {
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetFloat("_DirectionYaw", 0);
            skyboxMaterial.SetFloat("_DirectionPitch", 0);
        }
    }
}
