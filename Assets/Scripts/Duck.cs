using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    GameManager gm;
    Rigidbody2D rb;
    public float jumpHieght = 10f;

    public GameObject shotSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindObjectOfType<GameManager>();
        Destroy(gameObject, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        DuckShake.Shake();
        shotSprite.SetActive(true);

        transform.rotation = Quaternion.Euler(0, 0, 180f);
        rb.isKinematic = false;


        //Destroy(gameObject);
        gm.updateScore();
    }
}
