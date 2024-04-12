using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum PowerUp
{
    Blaster,
    Spread,
    Shield
}

/// <summary>
/// Moves the player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float fireRate = 1f;

    [SerializeField]
    private bool canShoot = true;

    public GameObject playerBulletPrefeb;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private int score = 0;

    InputAction moveAction;
    PlayerInput playerInput;

    [SerializeField]
    private Transform shootPoint;

    private Rigidbody myRigidBody;
    #endregion

    #region Bound Region
    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = this.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        
        Vector2 myVector = moveAction.ReadValue<Vector2>();

        transform.position += new Vector3(myVector.x, 0, myVector.y) * speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        if (canShoot)
        {
            GameObject playerBulletInstance = Instantiate(playerBulletPrefeb, shootPoint.position, shootPoint.rotation);
            StartCoroutine(Shooting(fireRate));
        }
    }


    private void Respawn()
    {
        if (lives > 0)
        {
            lives--;
        }
        else
        {
            //Go to game over screen
        }
    }

    //IEnumerators
    private IEnumerator Shooting(float fireRate)
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
