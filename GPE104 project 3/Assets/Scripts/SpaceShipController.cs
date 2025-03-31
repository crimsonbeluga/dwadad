using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipController : MonoBehaviour
{
    public static SpaceShipController Instance { get; private set; }

    [Header("Mouse Settings")]
    public float sensitivity = 100f;
    public float clampAngle = 85f;

    [Header("KeyCode Bindings")]
    public KeyCode forwardKey;
    public KeyCode rollRight;
    public KeyCode rollLeft;
    public KeyCode shoot;

    

    private SpaceShipPawn spaceShipPawnScript;
    private Bulletsettings BulletsettingsScript;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spaceShipPawnScript = GetComponent<SpaceShipPawn>();
        BulletsettingsScript = GetComponent<Bulletsettings>();
    }

    void Update()
    {
        HandleMouseLook();
        HandleForwardMovementAndDrag();
        rollLeftKey();
        rollRightKey();
        shootKey();

    }

    private void HandleMouseLook()
    {
        spaceShipPawnScript.RotateShip(Input.mousePosition, sensitivity, clampAngle);
    }

    private void rollRightKey()
    {
        if (Input.GetKey(rollRight))
        {
            spaceShipPawnScript.HandleRollRight();
        }
    }
    private void  shootKey()
    {
        if (Input.GetKeyDown(shoot))

        {
            BulletsettingsScript.HandleShooting();


        }
    }


    private void rollLeftKey()
    {
        if (Input.GetKey(rollLeft))
        {
            spaceShipPawnScript.HandleRollLeft();
        }
    }

    private void HandleForwardMovementAndDrag()
    {
        bool isMovingForward = Input.GetKey(forwardKey);
        if (isMovingForward)
        {
            spaceShipPawnScript.MoveForward();
        }
        else
        {
            spaceShipPawnScript.ApplyDrag();
        }
    }

  

}
