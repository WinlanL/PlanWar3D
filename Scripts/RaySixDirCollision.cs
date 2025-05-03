using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// ����
public enum DRI
{
    FORNT = 0,
    AFTER,
    UP,
    DOWN,
    LEFT,
    RIGHT,
}
public class RaySix
{
    // ���߾������巢�����ĵ�ƫ������
    public Vector3 offset;
    // ���� ��ǰ�����ϡ��¡�����
    public float[] distances;
    // ����
    public Ray front, after, up, down, left, right;
    // ����
    public Vector3 frontDir, afterDir, upDir, downDir, leftDir, rightDir;
    // ��ɫ
    public Color color;
    public RaySix(Vector3 offset, float[] distances, Color color)
    {
        this.offset = offset;
        this.distances = distances;
        this.color = color;
    }
}
public class RaySixDirCollision
{
    // ����ļ���
    private List<RaySix> raySixeList = new List<RaySix>();
    // ��������������
    private int layerMask = 0;
    /// <summary>
    /// ȷ���������
    /// </summary>
    /// <param name="layerMask"></param>
    public RaySixDirCollision(int layerMask)
    {
        this.layerMask = layerMask;
    }
    /// <summary>
    /// �������߲���
    /// </summary>
    /// <param name="distances"></param>
    public void AddRayLayer(Vector3 offset, float dis, Color color)
    {
        float[] diss = { dis, dis, dis, dis, dis, dis };
        raySixeList.Add(new RaySix(offset, diss, color));
    }
    /// <summary>
    /// ���þ���
    /// </summary>
    /// <param name="layer"></param>
    /// <param name="dRI"></param>
    /// <param name="dis"></param>
    public void SetDistance(int layer, DRI dRI, float dis)
    {
        try
        {
            raySixeList[layer].distances[(int)dRI] = dis;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        } 
    } 
    public void RaySixDirCollisionUpdate(Transform transform, bool isDrawLine = true)
    {
        CreateSixDirRay(transform);
        UpdatePosition(transform);
        if (isDrawLine) DrawRayLine(transform);
    }
    private void UpdatePosition(Transform transform)
    {
        foreach (RaySix item in raySixeList)
        {
            item.frontDir = transform.TransformDirection(new Vector3(0, 0, 1));
            item.afterDir = transform.TransformDirection(new Vector3(0, 0, -1));
            item.upDir = transform.TransformDirection(new Vector3(0, 1, 0));
            item.downDir = transform.TransformDirection(new Vector3(0, -1, 0));
            item.leftDir = transform.TransformDirection(new Vector3(-1, 0, 0));
            item.rightDir = transform.TransformDirection(new Vector3(1, 0, 0));
        }
    }
    private Vector3 centerPos;
    /// <summary>
    /// ����������������ߡ�
    /// </summary>
    /// <param name="transform"></param>
    private void CreateSixDirRay(Transform transform)
    {
        foreach (RaySix item in raySixeList)
        {
            centerPos = transform.position + transform.TransformDirection(item.offset);
            item.front = new Ray(centerPos, item.frontDir);
            item.after = new Ray(centerPos, item.afterDir);
            item.up = new Ray(centerPos, item.upDir);
            item.down = new Ray(centerPos, item.downDir);
            item.left = new Ray(centerPos, item.leftDir);
            item.right = new Ray(centerPos, item.rightDir);
        }
    }
    private void DrawRayLine(Transform transform)
    {

        foreach (RaySix item in raySixeList)
        {
            // ���߲���Debug.DrawLine(��ʼ�㣬������);
            centerPos = transform.position + transform.TransformDirection(item.offset);
            Debug.DrawLine(centerPos, centerPos + item.frontDir * item.distances[0], item.color);
            Debug.DrawLine(centerPos, centerPos + item.afterDir * item.distances[1], item.color);
            Debug.DrawLine(centerPos, centerPos + item.upDir * item.distances[2], item.color);
            Debug.DrawLine(centerPos, centerPos + item.downDir * item.distances[3], item.color);
            Debug.DrawLine(centerPos, centerPos + item.leftDir * item.distances[4], item.color);
            Debug.DrawLine(centerPos, centerPos + item.rightDir * item.distances[5], item.color);
        }
    }
    /// <summary>
    /// ������������߼��
    /// </summary>
    /// <param name="action"></param>
    public void SixRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        ForntRaycast(success, fail);
        AfterRaycast(success, fail);
        UpRaycast(success, fail);
        DownRaycast(success, fail);
        LeftRaycast(success, fail);
        RightRaycast(success, fail);
    }
    #region ��������ֿ����
    // ǰ
    public void ForntRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.front, item.distances[0], DRI.FORNT, success, fail);
        }
    }
    /// <summary>
    /// �ֲ���
    /// </summary>
    /// <param name="success"></param>
    /// <param name="fail"></param>
    public void ForntRaycastToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].front, raySixeList[Layer].distances[0], DRI.FORNT, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }   
    }
    // ��
    public void AfterRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.after, item.distances[1], DRI.AFTER, success, fail);
        }
    }
    public void AfterRaycastToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].after, raySixeList[Layer].distances[1], DRI.AFTER, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    // ��
    public void UpRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.up, item.distances[2], DRI.UP, success, fail);
        }
    }
    public void UpRaycasttToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].up, raySixeList[Layer].distances[2], DRI.UP, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    // ��
    public void DownRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.down, item.distances[3], DRI.DOWN, success, fail);
        }
    }
    public void DownRaycastToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].down, raySixeList[Layer].distances[3], DRI.DOWN, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    // ��
    public void LeftRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.left, item.distances[4], DRI.LEFT, success, fail);
        }
    }
    public void LeftRaycastToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].left, raySixeList[Layer].distances[4], DRI.LEFT, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    // ��
    public void RightRaycast(Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        foreach (RaySix item in raySixeList)
        {
            Raycast(item.right, item.distances[5], DRI.RIGHT, success, fail);
        }
    }
    public void RightRaycastToLayer(int Layer, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        try
        {
            Raycast(raySixeList[Layer].right, raySixeList[Layer].distances[5], DRI.RIGHT, success, fail);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    #endregion

    // ���߼��ͨ�÷�����
    public void Raycast(Ray ray, float distance, DRI dRI, Action<DRI, RaycastHit> success, Action<DRI, RaycastHit> fail)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            if (success != null) success(dRI, hit);
        }
        else
        {
            if (fail != null) fail(dRI, hit);
        }
    }
}