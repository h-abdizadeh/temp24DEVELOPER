using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCube : MonoBehaviour
{
    public bool throwThat = false, inCharge, afterThrow, throwSound;
    public float chargePower;
    [SerializeField] Material throwMaterial;
    [SerializeField] Slider chargeSlider;

    Rigidbody rb;

    SliderControl sliderControl;
    TargetStand targetStand;
    PlayerCamera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sliderControl = FindFirstObjectByType<SliderControl>();
        targetStand = FindFirstObjectByType<TargetStand>();
        playerCamera = FindFirstObjectByType<PlayerCamera>();
        chargeSlider = /*GameObject.*/FindFirstObjectByType<Slider>();
        throwMaterial = transform.GetComponent<MeshRenderer>().materials[0];

    }

    // Update is called once per frame
    void Update()
    {

        if (inCharge)
        {
            if (chargePower < 5)
                chargePower += Time.deltaTime;
            else
                chargePower = 0;

            chargeSlider.value = chargePower;
        }
        else
        {
            if (chargeSlider.value > 0)
                chargeSlider.value -= 2*Time.deltaTime;
            else
                chargePower = chargeSlider.value = 0;
        }

        var enemies = FindObjectsByType<GameObject>(FindObjectsSortMode.None).Where(g => g.transform.name.Contains("enemy")).ToList();

        if (throwThat && chargePower > 1)
        {
            var inAirSound = transform.GetComponents<AudioSource>()[0];
            if (!inAirSound.isPlaying && !throwSound)
            {
                inAirSound.Play();
                playerCamera.score = playerCamera.score > 0 ? playerCamera.score - 1 : 0;
                throwSound = true;
            }

            transform.parent = null;
            var alpha = 1;
            var newColor = new Color(throwMaterial.color.r,
               throwMaterial.color.g,
               throwMaterial.color.b,
              alpha);
            throwMaterial.color = newColor;

            var camDirection = Camera.main.transform.forward;
            var targetDirection = new Vector3(camDirection.x, camDirection.y, camDirection.z);


            rb.AddForce(targetDirection *chargePower, ForceMode.Impulse);

            afterThrow = true;
            chargePower -= Time.deltaTime;
        }
        else
        {
            throwThat = false;
            throwSound = false;

        }

        if(transform.parent is not  null)
            enemies.ForEach(e => e.GetComponent<Collider>().isTrigger = true);
        else
            enemies.ForEach(e => e.GetComponent<Collider>().isTrigger = false);




    }

    private void OnCollisionEnter(Collision collision)
    {
        chargePower = Time.deltaTime;
        var collideSound = transform.GetComponents<AudioSource>()[1];
        if (!collideSound.isPlaying)
        {
            collideSound.Play();
        }
    }


}
