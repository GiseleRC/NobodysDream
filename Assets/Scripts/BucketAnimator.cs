using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketAnimator : MonoBehaviour
{
    public Animator bucketAnimator;
    public BoxCollider bc;
    public CapsuleCollider cc;

    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        if (planeMode == GameState.PlaneMode.Ghost)
        {
            bucketAnimator.Play("BaldeUp");
        }
        else if (planeMode == GameState.PlaneMode.Dream)
        {
            bucketAnimator.Play("BaldeDown");
        }
    }

    public void ActivateCollider()
    {
        bc.enabled = true;
        cc.enabled = true;
    }

    public void DeactiveCollider()
    {
        bc.enabled = false;
        cc.enabled = false;
    }
}
