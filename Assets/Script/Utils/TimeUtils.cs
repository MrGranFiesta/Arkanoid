using UnityEngine;

public class TimeUtils
{
    //Da formato al texto
    public static string FormatedTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int seg = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", min, seg);
    }
}
