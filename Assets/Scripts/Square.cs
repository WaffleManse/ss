using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float posX = Random.Range(-3.0f, 3.01f);
        float posY = Random.Range(3.0f, 5.0f);

        transform.position = new Vector2(posX, posY);

        float size = Random.Range(0.5f, 1.51f);
        transform.localScale = new Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }
}
