using UnityEngine;
using System.Collections;

public class Movecontrol : MonoBehaviour {
    public float speed;
    public float rotationspeed;
    public KeyCode shootKey;
    public string horizontalAxie;
    public string verticalAxie;
    public bulletControll bulletPrefab;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizantalInput = Input.GetAxis(horizontalAxie);
        float VerticalInput = Input.GetAxis(verticalAxie);

        Vector2 vel = new Vector2(0, VerticalInput * speed);

        //will rotate the provided vector by the rotation of your object
        //we use it that even when the object is rotated,pressing up will make this move forward
        Vector2 velbasedOnRotation = transform.TransformVector(vel);


        rb.velocity = velbasedOnRotation;

        transform.Rotate(0, 0, -horizantalInput * rotationspeed);

        if(Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
	}
    void Shoot()
    {
       bulletControll bulletClone = (bulletControll)Instantiate(bulletPrefab, transform.position,transform.rotation);
       bulletClone.owner = this;
    }
}
