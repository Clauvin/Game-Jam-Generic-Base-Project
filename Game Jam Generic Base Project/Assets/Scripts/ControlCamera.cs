using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupportV4Jam
{

public class ControlCamera : MonoBehaviour
{
    Transform main_camera_transform;

    void Awake()
    {
        main_camera_transform = GetComponent<Transform>();
    }

    public void CoRoutineRotateCameraSphere(float x_angle, float y_angle, float z_angle,
                                            float miliseconds_it_takes_to_rotate,
                                            float moves_each_many_miliseconds)
    {
        StartCoroutine(RotateCameraSphere(x_angle, y_angle, z_angle,
                                            miliseconds_it_takes_to_rotate,
                                            moves_each_many_miliseconds));
    }

    public void CoRoutineTranslateCamera(float x_position, float y_position, float z_position,
                                        float miliseconds_it_takes_to_translate,
                                        float moves_each_many_miliseconds)
    {
        StartCoroutine(TranslateCamera(x_position, y_position, z_position,
                                            miliseconds_it_takes_to_translate,
                                            moves_each_many_miliseconds));
    }

    public void CoRoutineRotateCamera(float x_angle, float y_angle, float z_angle,
                                            float miliseconds_it_takes_to_rotate,
                                            float moves_each_many_miliseconds)
    {
        StartCoroutine(RotateCamera(x_angle, y_angle, z_angle,
                                    miliseconds_it_takes_to_rotate,
                                    moves_each_many_miliseconds));
    }

    private IEnumerator RotateCameraSphere(float x_angle, float y_angle, float z_angle,
                                            float miliseconds_it_takes_to_rotate,
                                            float moves_each_many_miliseconds)
    {
        float moves_each_many_seconds = 0;
        float how_many_increments = 0;
        Vector3 rotate_camera_sphere_increment = new Vector3();

        CameraInnerCalculations(x_angle, y_angle, z_angle,
                                    miliseconds_it_takes_to_rotate,
                                    moves_each_many_miliseconds,
                                    out moves_each_many_seconds,
                                    out how_many_increments,
                                    out rotate_camera_sphere_increment);

        for (int i = 0; i < how_many_increments; i++)
        {
            main_camera_transform.Rotate(rotate_camera_sphere_increment);
            yield return new WaitForSeconds(moves_each_many_seconds);
        }
    }

    private IEnumerator TranslateCamera(float x_position, float y_position, float z_position,
                                        float miliseconds_it_takes_to_translate,
                                        float moves_each_many_miliseconds)
    {
        float moves_each_many_seconds = 0;
        float how_many_increments = 0;
        Vector3 translate_camera_increment = new Vector3();

        CameraInnerCalculations(x_position, y_position, z_position,
                                    miliseconds_it_takes_to_translate,
                                    moves_each_many_miliseconds,
                                    out moves_each_many_seconds,
                                    out how_many_increments,
                                    out translate_camera_increment);

        for (int i = 0; i < how_many_increments; i++)
        {
            main_camera_transform.Translate(translate_camera_increment); // translate_camera_increment);
            yield return new WaitForSeconds(moves_each_many_seconds);
        }
    }

    private IEnumerator RotateCamera(float x_angle, float y_angle, float z_angle,
                                        float miliseconds_it_takes_to_rotate,
                                        float moves_each_many_miliseconds)
    {
        float moves_each_many_seconds = 0;
        float how_many_increments = 0;
        Vector3 rotate_camera_increment = new Vector3();

        CameraInnerCalculations(x_angle, y_angle, z_angle,
                                    miliseconds_it_takes_to_rotate,
                                    moves_each_many_miliseconds,
                                    out moves_each_many_seconds,
                                    out how_many_increments,
                                    out rotate_camera_increment);

        for (int i = 0; i < how_many_increments; i++)
        {
            main_camera_transform.Rotate(rotate_camera_increment);
            yield return new WaitForSeconds(moves_each_many_seconds);
        }
    }

    private void CameraInnerCalculations(float x, float y, float z,
                                            float miliseconds_it_takes_to_rotate,
                                            float moves_each_many_miliseconds,
                                            out float moves_each_many_seconds,
                                            out float how_many_increments,
                                            out Vector3 movement_vector)
    {
        moves_each_many_seconds = moves_each_many_miliseconds / 1000;

        /// gambiarra? Sim. Por alguma razão, o valor que deveria ser o correto em moves_each_many_seconds
        /// na verdade faz o código funcionar na METADE da velocidade esperada.
        /// Portanto, aqui dividimos o valor de moves_each_many_seconds por dois para resolver o problema.
        float fixing_gambiarra = 2.0f;
        moves_each_many_seconds /= fixing_gambiarra;

        how_many_increments = Convert.ToInt32(miliseconds_it_takes_to_rotate / moves_each_many_miliseconds);
        Debug.Log(how_many_increments + " " + moves_each_many_seconds);
        movement_vector = new Vector3(x / how_many_increments, y / how_many_increments, z / how_many_increments);
    }


}

}