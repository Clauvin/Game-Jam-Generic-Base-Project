using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Library in progress for fast prototyping in Unity.
/// 
/// Version 4, updated for jams.
/// </summary>

namespace SupportV4Jam
{
    public enum Game_Scenes
    {
        Logos = 0,
        Main_Screen = 1,
        Introduction = 2,
        Stage_1 = 3,
        Stage_2 = 4,
        Stage_3 = 5,
        Conclusion = 6,
        Credits = 7
    }

    /// <summary>
    /// Class LoadScene.
    /// 
    /// Responsible for loading scenes... and closing the game.
    /// 
    /// Changes a lot depending of the project
    /// </summary>
    public static class LoadScene
    {
        public static void Load(int cena)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(cena, LoadSceneMode.Single);
        }

        public static void LoadLogos() { Load((int)Game_Scenes.Logos); }

        public static void LoadMainScreen() { Load((int)Game_Scenes.Main_Screen); }

        public static void LoadIntroduction() { Load((int)Game_Scenes.Introduction); }

        public static void LoadStage1() { Load((int)Game_Scenes.Stage_1); }

        public static void LoadStage2() { Load((int)Game_Scenes.Stage_2); }

        public static void LoadStage3() { Load((int)Game_Scenes.Stage_3); }

        public static void LoadConclusion() { Load((int)Game_Scenes.Conclusion); }

        public static void LoadCredits() { Load((int)Game_Scenes.Credits); }

        public static void CloseGame() { Application.Quit(); }
    }



    /// <summary>
    /// Classe MathManipulators
    /// 
    /// Manages math calculations.
    /// 
    /// Needs to be tested.
    /// </summary>
    public static class MathManipulators
    {
        public static float DegreeToRadian(float degree) { return degree * Mathf.PI / 180; }

        public static float RadianToDegree(float radian) { return radian * 180 / Mathf.PI; }

        public static float ValueChecker(float min, float original_value, float max)
        {
            float value = original_value;

            if (value < min) value = min;
            else if (value > max) value = max;

            return value;
        }

        public static int RollDice(int maximum_value)
        {
            return Random.Range(1, maximum_value + 1);

        }

        /// <summary>
        /// Function which uses Random.Range between 0 and 1.0 to then compare the result with alive_chance.
        /// If result is lower or equal than alive_chance, returns true, else returns false.
        /// </summary>
        /// <param name="alive_chance">Must be between 0 and 1. Values lower or higher will be transformed.</param>
        /// <returns>True or false.</returns>
        public static bool OpenSchrodingerBox(float alive_chance)
        {
            alive_chance = ValueChecker(0, alive_chance, 1.0f);

            float value = Random.Range(0, 1.0f);
            bool result = value <= alive_chance;
            return result;
        }
    }

    /// <summary>
    /// Class which has functions that return strings about common text which has to be
    /// shown to the player / programmer.
    /// </summary>
    public static class CommonStrings
    {
        public static string NotImplemented() { return "Não implementado"; }
        public static string DontExistForThis(string masculino_ou_feminino_ou_outros, string coisa)
        {
            return "Não existe para ess" + masculino_ou_feminino_ou_outros + " " + coisa + ".";
        }

        public static string ShowCounting(string text)
        {
            return Gambiarra.Gambiarra_Contador_Crescente() + " - " + text;
        }
    }

    /// <summary>
    /// Class to simplify improvised debuggings.
    /// </summary>
    public static class Gambiarra
    {
        public static bool gambiarra_boolean = true;

        private static int gambiarra_contador = 0;

        public static int Gambiarra_Contador_Crescente()
        {
            gambiarra_contador++;
            return gambiarra_contador;
        }
    }

    public static class SpinTheSkybox
    {
        static float initial_position = 0.0f;
        static float actual_position = 0.0f;

        static float rotation_multiplier = 0.2f;

        static float sky_rotation;

        public static void UpdateInitialPosition(float initial)
        {
            initial_position = initial;
        }

        public static void UpdateActualPosition(float actual)
        {
            actual_position = actual;
        }

        public static void UpdateSkyRotation()
        {
            sky_rotation = (actual_position - initial_position) * rotation_multiplier;

            RenderSettings.skybox.SetFloat("_Rotation", sky_rotation);
        }

        public static void UpdateSkyRotation(float actual)
        {
            UpdateActualPosition(actual);
            UpdateSkyRotation();
        }
    }

}
