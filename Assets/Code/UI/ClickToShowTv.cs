﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowTv : MonoBehaviour
{

    public Camera SceneCamera;
    public GameObject TVDisplay;

    private void OnMouseDown()
    {
        StartCoroutine(Transition());
    }

    public float transitionDuration = 2.5f;
    public Transform target;


    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = SceneCamera.transform.position;
        Quaternion startingRot = SceneCamera.transform.rotation;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);


            SceneCamera.transform.position = Vector3.Lerp(startingPos, target.position, t);
            SceneCamera.transform.rotation = Quaternion.Lerp(startingRot, target.rotation, t);
            yield return 0;
        }

        TVDisplay.SetActive(true);
        this.gameObject.SetActive(false);
        yield break;
    }
}