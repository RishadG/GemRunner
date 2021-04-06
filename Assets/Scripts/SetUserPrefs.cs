using UnityEngine;
using UnityEngine.UI;

public class SetUserPrefs : MonoBehaviour
{
    public Slider[] PrefSliders;
    public Text[] PrefText;
    public float FOV = 124f;
    public float CameraX = 2.48f, CameraY = 4.6f, CameraZ = 0;
    public float MaxSpeed = 10f, jumpPower = 300f;
    // Start is called before the first frame update
    private void Awake()
    {
        // set the default values;
        setupDefaults();
    }

    private void setupDefaults()
    {
        // set FOV
        if (PlayerPrefs.HasKey("FOV"))
        {
            setSlider(PrefSliders[0], PrefText[0], PlayerPrefs.GetFloat("FOV"));
        }
        else
        {
            setSlider(PrefSliders[0], PrefText[0], FOV);
        }
        // set Camera X
        if (PlayerPrefs.HasKey("CameraX"))
        {
            setSlider(PrefSliders[1], PrefText[1], Mathf.Round(PlayerPrefs.GetFloat("CameraX")  * 100f) / 100f);
        }
        else
        {
            setSlider(PrefSliders[1], PrefText[1], CameraX);
        }
        // set Camera Y
        if (PlayerPrefs.HasKey("CameraY"))
        {
            setSlider(PrefSliders[2], PrefText[2], Mathf.Round(PlayerPrefs.GetFloat("CameraY") * 100f) / 100f);
        }
        else
        {
            setSlider(PrefSliders[2], PrefText[2], CameraY);
        }
        // set Camera Z
        if (PlayerPrefs.HasKey("CameraZ"))
        {
            setSlider(PrefSliders[3], PrefText[3], Mathf.Round(PlayerPrefs.GetFloat("CameraZ") * 100f) / 100f);
        }
        else
        {
            setSlider(PrefSliders[3], PrefText[3], CameraZ);
        }
        // Set max speed
        if (PlayerPrefs.HasKey("MaxSpeed"))
        {
            setSlider(PrefSliders[4], PrefText[4], PlayerPrefs.GetFloat("MaxSpeed"));
        }
        else
        {
            setSlider(PrefSliders[4], PrefText[4], MaxSpeed);
        }
        // set jump power
        if (PlayerPrefs.HasKey("JumpPower"))
        {
            setSlider(PrefSliders[5], PrefText[5], PlayerPrefs.GetFloat("JumpPower"));
        }
        else
        {
            setSlider(PrefSliders[5], PrefText[5], jumpPower);
        }

    }
    public void setSkin(int skin)
    {
        PlayerPrefs.SetInt("matChoice",skin);
        PlayerPrefs.Save();
    }
 
    public void setFOV(Slider S)
    {
        float SliderVal = S.value;
        PrefText[0].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("FOV", SliderVal);
        PlayerPrefs.Save();
    }
    public void setCameraX(Slider S)
    {
        float SliderVal = Mathf.Round(S.value * 100f) / 100f;
        PrefText[1].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("CameraX", SliderVal);
        PlayerPrefs.Save();
    }
    public void setCameraY(Slider S)
    {
        float SliderVal = Mathf.Round(S.value * 100f) / 100f;
        PrefText[2].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("CameraY", SliderVal);
        PlayerPrefs.Save();
    }
    public void setCameraZ(Slider S)
    {
        float SliderVal = Mathf.Round(S.value * 100f) / 100f; 
        PrefText[3].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("CameraZ", SliderVal);
        PlayerPrefs.Save();
    }
    public void setMaxSpeed(Slider S)
    {
        float SliderVal = S.value;
        PrefText[4].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("MaxSpeed", SliderVal);
        PlayerPrefs.Save();
    }

    public void setJumpPower(Slider S)
    {
        float SliderVal = S.value;
        PrefText[5].text = SliderVal.ToString();
        PlayerPrefs.SetFloat("JumpPower", SliderVal);
        PlayerPrefs.Save();
    }

    void setSlider(Slider slider, Text text, float val)
    {
        slider.value = val;
        text.text = val.ToString();
    }
    public void setDefaults()
    {
        setSlider(PrefSliders[0], PrefText[0], FOV);
        setSlider(PrefSliders[1], PrefText[1], CameraX);
        setSlider(PrefSliders[2], PrefText[2], CameraY);
        setSlider(PrefSliders[3], PrefText[3], CameraZ);
        setSlider(PrefSliders[4], PrefText[4], MaxSpeed);
        setSlider(PrefSliders[5], PrefText[5], jumpPower);

    }
}
