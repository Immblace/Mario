using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 3f;
    public Vector3 bulletmove;





    private void Update()
    {
        transform.Translate(bulletmove * Speed * Time.deltaTime);
    }


}
