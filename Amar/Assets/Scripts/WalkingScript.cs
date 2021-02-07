using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    private readonly int staticSpeed = 10;

    private readonly float decaySpeed = 1.15f;
    private int facing = -1;
    private Rigidbody2D rb;

    private float x, y;
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * staticSpeed;
        y = Input.GetAxisRaw("Vertical") * staticSpeed;
    }

    private void SpeedDecay()
    {
    }

    private void FixedUpdate()
    {
        var move = new Vector2(x, y);
        rb.AddForce(move, ForceMode2D.Force);
        float clampedX, clampedY;
        clampedX = Mathf.Clamp(rb.velocity.x, -10, 10);
        clampedY = Mathf.Clamp(rb.velocity.y, -10, 10);

        if ( (x == 0 || x*clampedX<0) && clampedX != 0) clampedX /= decaySpeed;

        if ((y == 0 || y*clampedY<0) && clampedY != 0) clampedY /= decaySpeed;

        rb.velocity = new Vector3(clampedX, clampedY);

        if (x > 0)
            facing = 1;
        else if (x < 0)
            facing = -1;

        var lScale = gameObject.transform.localScale;
        if (facing > 0)
            gameObject.transform.localScale = new Vector3(Mathf.Abs(lScale.x) * -1f, lScale.y, lScale.z);
        else
            gameObject.transform.localScale = new Vector3(Mathf.Abs(lScale.x), lScale.y, lScale.z);
    }
}