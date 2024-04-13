using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

enum PowerUp
{
    None,
    Blaster,
    Spread
}

///NEED TO DOS:
/// BIND PLAYER MOVEMENT WITHIN SCREEN


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
    public GameObject playerBulletSpreadPrefab;
    public GameObject playerBulletBlastPrefab;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private bool shield = false;

    InputAction moveAction;
    PlayerInput playerInput;

    [SerializeField]
    private Transform shootPoint;

    private Rigidbody myRigidBody;
    #endregion
    [SerializeField]
    private PowerUp currPower = PowerUp.None;

    //private int powerUp = 2;


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
        switch (currPower)
        {
            case PowerUp.None:
                if (canShoot)
                {
                    GameObject playerBulletInstance = Instantiate(playerBulletPrefeb, shootPoint.position, shootPoint.rotation);
                    StartCoroutine(Shooting(fireRate));
                }
                break;

            case PowerUp.Blaster:
                if (canShoot)
                {
                    GameObject playerBulletInstance = Instantiate(playerBulletPrefeb, shootPoint.position, shootPoint.rotation);
                    StartCoroutine(Shooting(fireRate));
                }
                break;

            case PowerUp.Spread:
                {
                    GameObject playerBulletInstance = Instantiate(playerBulletSpreadPrefab, shootPoint.position, shootPoint.rotation);
                    StartCoroutine(Shooting(fireRate));
                }
                break;
        }
        
    }


    private void Respawn()
    {
        if (!shield)
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
        else
        {
            shield = false;
        }
    }

    //IEnumerators
    private IEnumerator Shooting(float fireRate)
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    private IEnumerator PowerUpTimer(float puTimer)
    {
        yield return new WaitForSeconds(puTimer);

        if (currPower != PowerUp.None)
        {
            currPower = PowerUp.None;
        }
    }
}
