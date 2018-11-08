using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour {

    float mv_pos_x;
    float mv_pos_y;
    float mv_speed;

    public Instanciador( float iv_pos_x, float iv_pos_y, float iv_speed ){

        mv_pos_x = iv_pos_x;
        mv_pos_y = iv_pos_y;
        mv_speed = iv_speed;

    }

    public void InstanciarObjeto ( GameObject io_prefab ) {
        
        Instantiate( io_prefab );
        Debug.Log("foi");

    }

}