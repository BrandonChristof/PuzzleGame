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

    // 3 move puzzle
    public static float[,] level1 = new float[,]{
        {3f, 999f}, //Optimal solution
        {0f, 4f}
    };

    // 4 move puzzle
    public static float[,] level2 = new float[,]{
        {4f, 999f}, //Optimal solution
        {1f, 4f},
        {0f, 3f},
        {2f, 3f},
        {2f, 2f},
        {-3f, 1f},
        {-2f, 0f},
        {-3f, -2f},
        {3f, -2f},
    };

    // 5 move puzzle
    public static float[,] level3 = new float[,]{
        {5f, 999f}, //Optimal solution
        {0f, 3f},
        {0f, 2f},
        {3f, 1f},
        {4f, 1f},
        {-3f, 0f},
    };

    // 6 move puzzle
    public static float[,] level4 = new float[,]{
        {6f, 999f}, //Optimal solution
        {2f, 3f},
        {-3f, 1f},
        {-2f, -1f},
        {3f, -1f},
        {-2f, -2f},
    };

    // 7 move puzzle
    public static float[,] level5 = new float[,]{
        {7f, 999f}, //Optimal solution
        {-1f, 3f},
        {0f, 3f},
        {-1f, 2f},
        {1f, 1f},
        {4f, 0f},
        {-3f, -2f},
    };

    // 8 move puzzle
    public static float[,] level6 = new float[,]{
        {8f, 999f}, //Optimal solution
        {-1f, 3f},
        {1f, 3f},
        {2f, 3f},
        {-3f, 1f},
        {0f, -1f},
        {3f, -2f},
    };

    // 9 move puzzle
    public static float[,] level7 = new float[,]{
        {9f, 999f}, //Optimal solution
        {-3f, 2f},
        {-1f, 2f},
        {-3f, 1f},
        {-1f, 1f},
        {0f, 0f},
        {2f, 0f},
        {1f, -1f},
        {4f, -1f},
        {0f, -2f},
        {1f, -2f},
    };

    // 10 move puzzle
    public static float[,] level8 = new float[,]{
        {10f, 999f}, //Optimal solution
        {2f, 3f},
        {3f, 2f},
        {-2f, 1f},
        {0f, 1f},
        {1f, -2f},
        {-3f, -3f},
        {-2f, -3f},
    };

    // 11 move puzzle
    public static float[,] level9 = new float[,]{
        {11f, 999f}, //Optimal solution
        {-1f, 3f},
        {-3f, 2f},
        {0f, 1f},
        {1f, 1f},
        {0f, 0f},
        {3f, 0f},
        {-2f, -1f},
        {1f, -2f},
        {4f, -2f},
    };

    // 11 move puzzle
    public static float[,] level10 = new float[,]{
        {11f, 999f}, //Optimal solution
        {-1f, 3f},
        {3f, 3f},
        {-3f, 2f},
        {3f, 2f},
        {-1f, 0f},
        {3f, 0f},
        {-2f, -1f},
        {0f, -2f},
    };


    /* public static float[,] level60 = new float[,]{
        {0f, 4f},
        {-1f, 3f},
        {1f, 3f},
        {-3f, 2f},
        {1f, 1f},
        {2f, 1f},
        {-2f, 0f},
        {2f, 0f},
        {-3f, -1f},
        {-1f, -1f},
        {-1f, -1f},
    }; */

    public static List<float[,]> levels = new List<float[,]>(){
        level1,
        level2,
        level3,
        level4,
        level5,
        level6,
        level7,
        level8,
        level9,
        level10
    };
}
