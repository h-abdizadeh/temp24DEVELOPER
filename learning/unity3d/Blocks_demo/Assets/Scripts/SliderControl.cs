using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] TMP_Text sliderBtnText;
    [SerializeField] ThrowCube throwCube;
    TargetStand targetStand;
    //public bool afterThrow,changeTarget;
    // Start is called before the first frame update
    void Start()
    {
        targetStand=FindFirstObjectByType<TargetStand>();
        sliderBtnText =GameObject.FindGameObjectWithTag("chargeBtnText").GetComponent<TMP_Text>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        throwCube = FindFirstObjectByType<ThrowCube>();

        var value = GetComponent<Slider>().value;
        if (value is 0 && throwCube.afterThrow)
        {
            sliderBtnText.text = "NEXT";
        }
         else if (!throwCube.afterThrow && !targetStand.changeTarget)
        {
            sliderBtnText.text = "CHARGE";
        }
    }
}
