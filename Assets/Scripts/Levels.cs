using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    private static Levels _Instance;
    public static Levels Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<Levels>();
                // name it for easy recognition
                _Instance.name = _Instance.GetType().ToString();
                // mark root as DontDestroyOnLoad();
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }

    public static float[,] borders = new float[,]{
        {5f, -4f},
        //{5f, -3f},
        {5f, -2f},
        {5f, -1f},
        {5f, 0f},
        {5f, 1f},
        {5f, 2f},
        {5f, 3f},
        {5f, 4f},
        {5f, 5f},

        {-4f, -4f},
        {-4f, -3f},
        {-4f, -2f},
        {-4f, -1f},
        {-4f, 0f},
        {-4f, 1f},
        {-4f, 2f},
        {-4f, 3f},
        {-4f, 4f},
        {-4f, 5f},

        {4f, -4f},
        {3f, -4f},
        {2f, -4f},
        {1f, -4},
        {0f, -4},
        {-1f, -4},
        {-2f, -4},
        {-3f, -4},

        {4f, 5f},
        {3f, 5f},
        {2f, 5f},
        {1f, 5f},
        {0f, 5f},
        {-1f, 5f},
        {-2f, 5f},
        {-3f, 5f},
    };

    public static float[,] level1 = new float[,]{
        {0f, 0f},
        {1f, 1f},
        {-2f, -2f},
        {2f, 2f}
    };

    public static float[,] level2 = new float[,]{
        {-1f, -1f},
        {-2f, -2f}
    };

    public static List<float[,]> levels = new List<float[,]>(){
        level1,
        level2
    };
}
