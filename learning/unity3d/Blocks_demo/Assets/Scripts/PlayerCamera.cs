using TMPro;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target, cubePlace;
        //[SerializeField] Vector3      orangeCube;
    [SerializeField] GameObject prefabCube, createdCube;
    [SerializeField] TMP_Text scoreBoard;
    Vector3 defaultStandPos;
    public bool turnRight, turnLeft, turnTop, turnDown;
    public int score;
    float turnScale;

    TargetStand targetStand;

    // Start is called before the first frame update
    void Start()
    {
        targetStand = FindFirstObjectByType<TargetStand>();
        transform.LookAt(target);
        defaultStandPos = target.position;
        SetNewCube();
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = $"SCORE\n{score}";

        var standPos = target.position;
        if (targetStand.changeTarget)
        {
            if (standPos != defaultStandPos)
            {
                transform.LookAt(target);
                defaultStandPos = standPos;
            }
            Destroy(createdCube);
            SetNewCube();
            targetStand.changeTarget = false;
        }
        //orangeCube = transform.eulerAngles;
        turnScale = 10 * Time.deltaTime;
        if (turnRight)
            transform.rotation =
                Quaternion.Euler(transform.eulerAngles.x,
                transform.eulerAngles.y + turnScale,
                transform.eulerAngles.z);
        else if (turnLeft)
            transform.rotation =
                Quaternion.Euler(transform.eulerAngles.x,
                transform.eulerAngles.y - turnScale,
                transform.eulerAngles.z);
        else if (turnTop && transform.eulerAngles.x>315)
            transform.rotation =
                Quaternion.Euler(transform.eulerAngles.x - turnScale,
                transform.eulerAngles.y,
                transform.eulerAngles.z);
        else if (turnDown && transform.eulerAngles.x <359)
            transform.rotation =
                Quaternion.Euler(transform.eulerAngles.x + turnScale,
                transform.eulerAngles.y,
                transform.eulerAngles.z);


    }

    public void SetNewCube()
    {
        for (int i = 0; i < 1; i++)
            createdCube = Instantiate(prefabCube, cubePlace);
    }
}
