using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class Tire : MonoBehaviour
{
    int relode = 6;
    private void Start()
    {
        bool resulta = Roullette();
        Debug.Log(relode);
    }

    public bool Roullette()
    {

        int _bale = Random.Range(0, relode);

        if (_bale == 0)
        {
            relode = 6;
            Debug.Log("true");
            return true;
          
        }
        else
        {
            relode--;
            Debug.Log("false");
            return false;

        }
    }

    bool Roullette2()
    {

        int _bale = Random.Range(0, relode);

        if (_bale == 0)
        {
            
            Debug.Log("true");
            return true;

        }
        else
        {
            
            Debug.Log("false");
            return false;

        }
    }
}