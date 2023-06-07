using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketAnimator : MonoBehaviour
{
    public Animator bucketAnimator;

    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        if (planeMode == GameState.PlaneMode.Ghost)
        {
            bucketAnimator.Play("BucketUp");
        }
        else if (planeMode == GameState.PlaneMode.Dream)
        {
            bucketAnimator.Play("BucketDown");
        }
    }
}
