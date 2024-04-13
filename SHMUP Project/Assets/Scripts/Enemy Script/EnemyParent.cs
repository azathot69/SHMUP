using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Initializes a script to be used by all enemies
/// </summary>
public class EnemyParent : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float startingX;
    [SerializeField]
    private float startingY;
    [SerializeField]
    private float health = 1;
    [SerializeField]
    private int points = 0;
    #endregion

    #region Kill Region
    private float killY = -8;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        //Despawn when reaching zone
        if (transform.position.z <= killY)
        {
            Despawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Bullet":
                if (health > 0)
                {
                    health--;
                }
                else
                {
                    Score.instance.score += points;
                    Destroy(this.gameObject);
                }

                break;

            case "Player":
                if (health > 0)
                {
                    health--;
                }
                else
                {
                    //Add to score
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }
}
