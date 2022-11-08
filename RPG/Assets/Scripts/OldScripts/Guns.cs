using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] private float AdditionalDeg = 0;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    bool FaceRight = true;
    void Update()
    {
        if (Input.mousePosition.x < 0 && FaceRight)
        {
            Flip();
        }
        else if (Input.mousePosition.x > 0 && !FaceRight)
        {
            Flip();

        }
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 Dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                float Angle = 0;
                if (transform.parent.transform.localScale.x > 0)
                {
                    Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;

                }
                else
                {
                    Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
                }
                Instantiate(bullet, shotPoint.transform.position, Quaternion.AngleAxis(Angle, Vector3.forward));
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
    private void FixedUpdate()
    {
        Vector3 Dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float Angle = 0;
        if (transform.parent.transform.localScale.x > 0)
        {
            Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
        }
        else
        {
            Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg + 180;
        }
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

    }
    void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 A = transform.localScale;
        A.y *= -1;

        transform.localScale = A;

    }

}
