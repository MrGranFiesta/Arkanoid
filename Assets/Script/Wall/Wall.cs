using UnityEngine;

public class Wall : MonoBehaviour
{
    /*
        Warnigns
    Esta clase se va a eliminar en el futuro porque se hizo
    cuando no sabia manejar bien Unity y es innecesaria
     */

    //Expone la posicion del muro
    public float getPositionX()
    {
        return transform.position.x;
    }

    //Expone el tamaño del muro
    public float getScaleX()
    {
        return transform.localScale.x;
    }
}
