using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Movement
{
    moveRight,
    moveLeft,
    moveUp,
    moveDown,
    moveZig,
    moveZag
}

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
    #endregion

    #region Kill Region

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
        
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }
}
