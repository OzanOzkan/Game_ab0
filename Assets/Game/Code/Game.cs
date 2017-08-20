using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    // Scenes
    protected static class Scenes
    {
        public static string MainMenu { get { return "MainMenu"; } }
        public static string InfoScreen { get { return "InfoScreen"; } }
        public static string GameScreen { get { return "GameScreen"; } }
    }

    // Rules
    protected static class Rules
    {
        public static float MoveTimeLimit { get { return 10; } }
    }

    // Difficulty
    protected static class Difficulty
    {
        public enum Levels
        {
            eDL_EASY = 0,
            eDL_MEDIUM,
            eDL_HARD
        }

        private static Difficulty.Levels m_currentDifficulty;

        public static Difficulty.Levels Current
        {
            get { return m_currentDifficulty; }
            set { m_currentDifficulty = value; }
        }
    }

    // States
    protected static class State
    {
        private static int m_iCurrentScore;
        public static int CurrentScore
        {
            get { return m_iCurrentScore; }
            set { m_iCurrentScore = value; }
        }
    }
}
