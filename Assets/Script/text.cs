using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    public int buff;
    public int buff1;
    public int baseAp;
    public int equipment;
    public int a;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        //buff = equipment + buff1;
    }
    void Update()
    {
        buff1 = 0;
        buff = equipment + buff1;
        //buff = 1000;
        a = buff * 2 / 10;
        buff1 += (baseAp + a);
        buff = equipment + buff1;
    }
}
