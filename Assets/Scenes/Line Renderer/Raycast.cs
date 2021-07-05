using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;
      if(Physics.Raycast(this.transform.position, this.transform.forward, out hit))
      {
            Vector3 point = hit.point;
            this.line.SetPosition(0, this.transform.position);
            this.line.SetPosition(1, point);
      }
    }
}
