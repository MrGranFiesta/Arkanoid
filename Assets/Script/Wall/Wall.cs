using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float getPositionX()
    {
        return this.transform.position.x;
    }

    public float getScaleX()
    {
        return this.transform.localScale.x;
    }
}
