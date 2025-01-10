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

    bool Roullette()
    {

        int _bale = Random.Range(0, relode);

        if (_bale == 0)
        {
            relode--;
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
}