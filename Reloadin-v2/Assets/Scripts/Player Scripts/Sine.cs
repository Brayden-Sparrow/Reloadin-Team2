using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sine : MonoBehaviour
{
    
    
    public enum options { x_Movement, y_Movement, z_Movement, Width, Height, Depth, Size, x_Rotate, y_Rotate, z_Rotate, Opacity };
    [Tooltip("Select which property of the object to modify")]
    public options Options;

    public enum wave { sine, cosine, tan};
    [Tooltip("Select the kind of wave function used to calculate the movement")]
    public wave Wave;

    [Tooltip("The time in seconds for a complete cycle")]
    public float period;

    [Tooltip("Add a random number of seconds to the period, up to this value.")]
    public float period_random;

    [Tooltip("The initital time in seconds through the cycle")]
    public float period_offset;

    [Tooltip("Add a random number of seconds to the inital time, up to this value")]
    public float period_offset_random;

    [Tooltip("The maximum change to transform by, etc.\nUse between 0-1 for opacity")]
    public float magnitude;

    [Tooltip("Add a random number to the magnitude, up to this value")]
    public float magnitude_random;


    [Tooltip("Whether the behavior is initially enabled or disabled")]
    public bool is_enabled;

    private float current_period = 0.0f;
    private float incrementer = 0.0f; //Goes up by 1 every cycle
    private float current_magnitude = 0.0f;
    private float offset = 0.0f;

    private float starting_width;
    private float starting_height;
    private float starting_depth;

    private float starting_x_rotation;
    private float starting_y_rotation;
    private float starting_z_rotation;

    private Renderer renderer;
    // Interal variables

    // Start is called before the first frame update
    void Start()
    {
        current_period = period_offset + Random.Range(0, period_offset_random);
        current_magnitude = magnitude + Random.Range(0, magnitude);

        starting_width = transform.localScale.x;
        starting_height = transform.localScale.y;
        starting_depth = transform.localScale.z;

        starting_x_rotation = transform.localRotation.x;
        starting_y_rotation = transform.localRotation.y;
        starting_z_rotation = transform.localRotation.z;
        

        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_enabled)
        {
            switch (Wave)
            {
                case wave.sine:


                    offset = Mathf.Sin(current_period / period) * current_magnitude / 2;
                    current_period += Time.deltaTime * 10;

                    if (current_period == float.MaxValue - 1)
                        current_period = 0.0f;
                    break;



                case wave.cosine:
                    offset = Mathf.Cos(current_period / period) * current_magnitude / 2;
                    current_period += Time.deltaTime * 10;

                    if (current_period == float.MaxValue - 1)
                        current_period = 0.0f;
                    break;

                case wave.tan:
                    offset = Mathf.Tan(current_period / period) * current_magnitude / 2;
                    current_period += Time.deltaTime * 10;

                    if (current_period == float.MaxValue - 1)
                        current_period = 0.0f;
                    break;
            }

            switch (Options)
            {
                case options.x_Movement:
                    transform.position = new Vector3(offset, 0, 0);
                    break;

                case options.y_Movement:
                    transform.position = new Vector3(0, offset, 0);
                    break;

                case options.z_Movement:
                    transform.position = new Vector3(0, 0, offset);
                    break;

                case options.Width:
                    transform.localScale = new Vector3(starting_width + (starting_width * offset), transform.localScale.y, transform.localScale.z);
                    break;

                case options.Height:

                    transform.localScale = new Vector3(transform.localScale.x, starting_height + (starting_height * offset), transform.localScale.z);
                    break;

                case options.Depth:

                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, starting_depth + (starting_depth * offset));
                    break;

                case options.x_Rotate:
                    transform.rotation = Quaternion.Euler(starting_x_rotation + (offset * 360), transform.localRotation.y, transform.localRotation.z);
                    break;

                case options.y_Rotate:
                    transform.rotation = Quaternion.Euler(transform.localRotation.x, starting_y_rotation + (offset * 360), transform.localRotation.z);
                    break;

                case options.z_Rotate:
                    transform.Rotate(new Vector3(transform.localRotation.x, transform.localRotation.y, starting_z_rotation + offset));
                    transform.rotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, starting_z_rotation + (offset * 360));

                    break;

                case options.Size:
                    transform.localScale = new Vector3(starting_width + offset, starting_height + offset, starting_depth + offset);
                    break;

                case options.Opacity:
                    float temp_offset = offset / 100;

                    if (temp_offset < 0.0f)
                        temp_offset = 0.0f;
                    if (temp_offset > 1.0f)
                        temp_offset = 1.0f;

                    var newColor = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, temp_offset);
                    renderer.material.color = newColor;

                    if (temp_offset == 0.0f)
                        renderer.enabled = false;
                    else
                        renderer.enabled = true;
                    break;
            }
        }


    }


}
