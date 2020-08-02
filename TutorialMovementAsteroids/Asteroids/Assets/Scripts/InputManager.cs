using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float vertical{

        get{return Input.GetAxis("Vertical");}

    }

    
    public static float horizontal{

        get{return Input.GetAxis("Horizontal");}

    }

     public static bool fire{

        get{return Input.GetKey(KeyCode.Return);
        
        }

    }


}
