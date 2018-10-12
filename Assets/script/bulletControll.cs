using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class bulletControll : MonoBehaviour {
    public float speed;
    private float lifetime;
    public GameObject prefab;
    public Movecontrol owner;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        lifetime = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Movecontrol playerHit = col.GetComponent<Movecontrol>();
        if(playerHit!=null)
        {
            
            if (playerHit == owner)
            {
                return;
            }
            print(owner.name + "has won!");
            SceneManager.LoadScene(0);
        }
       /* if(col.gameObject.tag!="Player")
        {
            Destroy(this.gameObject);
            Crash();
        }*/
        Destroy(this.gameObject);
        Crash();
    }
    void Crash()
    {
       Object gameobject =  Instantiate(prefab,this.transform.position,this.transform.rotation);
       Destroy(gameobject, lifetime);
    }
}
