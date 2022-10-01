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
                _Instance.name = _Instance.GetType().ToString();
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

    // 12 move puzzle
    public static float[,] level11 = new float[,]{
        {12f, 999f}, //Optimal solution
        {0f, 3f},
        {-2f, 1f},
        {2f, 1f},
        {4f, 0f},
        {-3f, -1f},
        {-2f, -1f},
        {4f, -1f},
    };

    // 12 move puzzle
    public static float[,] level12 = new float[,]{
        {12f, 999f}, //Optimal solution
        {-1f, 4f},
        {0f, 2f},
        {1f, 1f},
        {-3f, 0f},
        {1f, 0f},
        {2f, -1f},
        {-3f, -2f},
        {-1f, -2f},
        {3f, -2f},
        {-3f, -3f},
        {-2f, -3f},
    };

    // 13 move puzzle
    public static float[,] level13 = new float[,]{
        {13f, 999f}, //Optimal solution
        {-1f, 3f},
        {2f, 3f},
        {2f, 2f},
        {-1f, 1f},
        {0f, 0f},
        {-3f, -1f},
        {-2f, -1f},
        {0f, -1f},
        {4f, -1f},
        {4f, -2f},
    };

    public static float[,] level14 = new float[,]{
        {13f, 999f}, //Optimal solution
        {0f, 4f},
        {4f, 4f},
        {0f, 2f},
        {-2f, 1f},
        {3f, 1f},
        {-3f, -1f},
        {1f, -1f},
        {1f, -2f},
    };

    public static float[,] level15 = new float[,]{
        {14f, 999f}, //Optimal solution
        {4f, 4f},
        {1f, 3f},
        {-3f, 2f},
        {0f, 1f},
        {-2f, 0f},
        {-1f, 0f},
        {0f, 0f},
        {1f, 0f},
        {0f, -1f},
        {3f, -2f},
    };

    public static float[,] level16 = new float[,]{
        {14f, 999f}, //Optimal solution
        {-1f, 4f},
        {2f, 4f},
        {-3f, 2f},
        {3f, 1f},
        {4f, 1f},
        {-2f, 0f},
        {-1f, 0f},
        {-1f, -1f},
        {1f, -1f},
        {3f, -1f},
        {1f, -2f},
        {3f, -2f},
    };

    public static float[,] level17 = new float[,]{
        {15f, 999f}, //Optimal solution
        {0f, 4f},
        {0f, 3f},
        {3f, 3f},
        {2f, 2f},
        {3f, 2f},
        {-2f, 1f},
        {-1f, 1f},
        {4f, 0f},
        {-1f, -1f}
    };

    public static float[,] level18 = new float[,]{
        {15f, 999f}, //Optimal solution
        {0f, 3f},
        {0f, 2f},
        {-1f, 1f},
        {0f, 1f},
        {1f, 1f},
        {-3f, 0f},
        {0f, 0f},
        {-1f, -1f},
        {3f, -1f},
        {-2f, -2f},
        {1f, -2f}
    };

    public static float[,] level19 = new float[,]{
        {16f, 999f}, //Optimal solution
        {-1f, 4f},
        {0f, 4f},
        {-2f, 2f},
        {0f, 0f},
        {1f, 0f},
        {-3f, -1f},
        {4f, -1f},
        {-2f, -3f}
    };

    public static float[,] level20 = new float[,]{
        {16f, 999f}, //Optimal solution
        {2f, 4f},
        {3f, 4f},
        {4f, 4f},
        {3f, 3f},
        {4f, 3f},
        {-2f, 2f},
        {-1f, 2f},
        {0f, 2f},
        {-3f, 1f},
        {-3f, 0f},
        {-2f, -2f},
        {3f, -2f},
        {-2f, -3f}
    };

    public static float[,] level21 = new float[,]{
        {16f, 999f}, //Optimal solution
        {1f, 4f},
        {4f, 4f},
        {3f, 4f},
        {4f, 3f},
        {-1f, 2f},
        {-2f, 0f},
        {0f, -1f},
        {3f, -1f},
        {-3f, -2f},
        {-2f, -2f},
        {1f, -2f},
        {3f, -2f},
        {-3f, -3f},
        {-2f, -3f}
    };

    public static float[,] level22 = new float[,]{
        {17f, 999f}, //Optimal solution
        {1f, 3f},
        {1f, 1f},
        {2f, 0f},
        {1f, -1f},
        {0f, -2f},
        {4f, -2f},
        {-2f, -3f}
    };

    public static float[,] level23 = new float[,]{
        {17f, 999f}, //Optimal solution
        {-1f, 3f},
        {-1f, 2f},
        {0f, 2f},
        {3f, 2f},
        {-3f, 1f},
        {-2f, 1f},
        {1f, 1f},
        {3f, 0f},
        {-2f, -2f},
        {-1f, -3f}
    };

    public static float[,] level24 = new float[,]{
        {17f, 999f}, //Optimal solution
        {4f, 4f},
        {1f, 3f},
        {0f, 1f},
        {1f, 1f},
        {-3f, 0f},
        {-2f, 0f},
        {0f, 0f},
        {-3f, -1f},
        {-2f, -1f},
        {0f, -1f},
        {3f, -1f},
        {3f, -2f},
        {-2f, -3f},
        {-1f, -3f}
    };

    public static float[,] level25 = new float[,]{
        {18f, 999f}, //Optimal solution
        {2f, 4f},
        {0f, 3f},
        {4f, 3f},
        {-3f, 2f},
        {-1f, 2f},
        {0f, -1f},
        {1f, -1f},
        {3f, -2f}
    };

    public static float[,] level26 = new float[,]{
        {18f, 999f}, //Optimal solution
        {-1f, 3f},
        {-3f, 2f},
        {4f, 2f},
        {0f, 1f},
        {2f, 1f},
        {-2f, 0f},
        {-3f, -1f},
        {-1f, -1f},
        {1f, -2f}
    };

    public static float[,] level27 = new float[,]{
        {18f, 999f}, //Optimal solution
        {1f, 4f},
        {-1f, 3f},
        {4f, 3f},
        {-2f, 0f},
        {0f, -1f},
        {-3f, -2f},
        {-1f, -2f},
        {3f, -2f}
    };

    public static float[,] level28 = new float[,]{
        {19f, 999f}, //Optimal solution
        {1f, 4f},
        {4f, 4f},
        {0f, 3f},
        {1f, 3f},
        {4f, 2f},
        {-1f, 0f},
        {3f, 0f},
        {0f, -2f}
    };

    public static float[,] level29 = new float[,]{
        {19f, 999f}, //Optimal solution
        {-3f, 1f},
        {-2f, 1f},
        {-1f, 1f},
        {3f, 1f},
        {-2f, 0f},
        {0f, 0f},
        {-2f, -2f},
        {2f, -2f}
    };

    public static float[,] level30 = new float[,]{
        {19f, 999f}, //Optimal solution
        {2f, 4f},
        {4f, 4f},
        {3f, 4f},
        {4f, 3f},
        {3f, 3f},
        {-1f, 2f},
        {3f, 2f},
        {4f, 2f},
        {1f, 1f},
        {-3f, 0f},
        {0f, 0f},
        {0f, -1f},
        {2f, -1f},
        {-2f, -2f},
        {2f, -2f}
    };

    public static float[,] level31 = new float[,]{
        {20f, 999f}, //Optimal solution
        {0f, 4f},
        {1f, 4f},
        {2f, 3f},
        {0f, 2f},
        {1f, 2f},
        {-1f, -1f},
        {2f, -1f},
        {-2f, -2f},
        {3f, -2f},
        {0f, -3f}
    };

    public static float[,] level32 = new float[,]{
        {20f, 999f}, //Optimal solution
        {1f, 4f},
        {2f, 4f},
        {3f, 3f},
        {2f, 2f},
        {-2f, 1f},
        {4f, 1f},
        {0f, 0f},
        {4f, 0f},
        {-3f, -1f},
        {-3f, -2f},
        {-2f, -2f},
        {1f, -2f},
        {4f, -2f}
    };

    public static float[,] level33 = new float[,]{
        {20f, 999f}, //Optimal solution
        {1f, 4f},
        {4f, 2f},
        {-2f, 1f},
        {-1f, 0f},
        {2f, -1f},
        {4f, -1f},
        {-3f, -2f}
    };

    public static float[,] level34 = new float[,]{
        {21f, 999f}, //Optimal solution
        {2f, 4f},
        {3f, 3f},
        {3f, 4f},
        {4f, 4f},
        {4f, 3f},
        {-1f, 2f},
        {4f, 2f},
        {0f, 1f},
        {1f, 1f},
        {2f, 1f},
        {-3f, 0f},
        {4f, 0f},
        {3f, -1f},
        {-3f, -3f},
        {-2f, -3f}
    };

    public static float[,] level35 = new float[,]{
        {21f, 999f}, //Optimal solution
        {0f, 4f},
        {1f, 4f},
        {3f, 3f},
        {-3f, 2f},
        {-2f, 2f},
        {-2f, 1f},
        {3f, 0f},
        {-1f, -1f},
        {-3f, -2f},
        {-1f, -3f}
    };

    public static float[,] level36 = new float[,]{
        {21f, 999f}, //Optimal solution
        {2f, 4f},
        {2f, 2f},
        {3f, 2f},
        {4f, 2f},
        {2f, 1f},
        {-1f, 1f},
        {1f, 1f},
        {3f, 1f},
        {2f, 0f},
        {-1f, -1f},
        {2f, -1f},
        {0f, -2f},
        {-3f, -3f}
    };

    public static float[,] level37 = new float[,]{
        {22f, 999f}, //Optimal solution
        {1f, 4f},
        {-1f, 3f},
        {2f, 3f},
        {3f, 3f},
        {-3f, 2f},
        {3f, 2f},
        {0f, 1f},
        {-3f, 0f},
        {-2f, 0f},
        {2f, 0f},
        {1f, -2f},
        {2f, -2f},
        {3f, -2f}
    };

    public static float[,] level38 = new float[,]{
        {22f, 999f}, //Optimal solution
        {0f, 3f},
        {3f, 3f},
        {1f, 2f},
        {-3f, 1f},
        {2f, 0f},
        {1f, -1f},
        {1f, -2f}
    };

    public static float[,] level39 = new float[,]{
        {22f, 999f}, //Optimal solution
        {1f, 4f},
        {4f, 4f},
        {1f, 3f},
        {-2f, 2f},
        {1f, 2f},
        {0f, 1f},
        {3f, 0f},
        {-3f, -1f},
        {2f, -1f},
        {1f, -2f}
    };

    public static float[,] level40 = new float[,]{
        {23f, 999f}, //Optimal solution
        {3f, 4f},
        {-1f, 3f},
        {0f, 3f},
        {1f, 3f},
        {4f, 3f},
        {4f, 2f},
        {3f, 1f},
        {4f, 0f},
        {-2f, 2f},
        {3f, 2f},
        {2f, 1f},
        {4f, 1f},
        {-2f, 0f},
        {0f, 0f},
        {1f, 0f},
        {2f, 0f},
        {3f, 0f},
        {-3f, -1f},
        {2f, -1f},
        {4f, -1f},
        {-1f, -3f}
    };

    public static float[,] level41 = new float[,]{
        {23f, 999f}, //Optimal solution
        {1f, 4f},
        {-1f, 2f},
        {4f, 2f},
        {-2f, 1f},
        {-1f, 1f},
        {-3f, 0f},
        {-1f, -1f},
        {4f, -1f},
        {2f, -2f}
    };

    public static float[,] level42 = new float[,]{
        {23f, 999f}, //Optimal solution
        {-1f, 4f},
        {2f, 4f},
        {3f, 3f},
        {3f, 1f},
        {-1f, 0f},
        {-3f, -1f},
        {4f, -2f}
    };

    public static float[,] level43 = new float[,]{
        {24f, 999f}, //Optimal solution
        {0f, 4f},
        {2f, 4f},
        {3f, 4f},
        {4f, 4f},
        {0f, 3f},
        {1f, 3f},
        {1f, 4f},
        {3f, 3f},
        {-2f, 2f},
        {3f, 2f},
        {0f, 1f},
        {-3f, 0f},
        {0f, 0f},
        {1f, 0f},
        {4f, 0f},
        {2f, -1f},
        {-3f, -3f}
    };

    public static float[,] level44 = new float[,]{
        {24f, 999f}, //Optimal solution
        {3f, 4f},
        {1f, 2f},
        {4f, 2f},
        {-3f, 1f},
        {-2f, 1f},
        {-1f, 1f},
        {4f, 1f},
        {0f, -1f},
        {-1f, -2f}
    };

    public static float[,] level45 = new float[,]{
        {24f, 999f}, //Optimal solution
        {2f, 4f},
        {4f, 4f},
        {-3f, 2f},
        {-1f, 2f},
        {2f, 2f},
        {-1f, 1f},
        {3f, 1f},
        {-2f, 0f},
        {0f, 0f},
        {2f, 0f},
        {4f, 0f},
        {2f, -2f},
        {-3f, -3f}
    };

    public static float[,] level46 = new float[,]{
        {25f, 999f}, //Optimal solution
        {1f, 4f},
        {-2f, 2f},
        {-3f, 1f},
        {-1f, 1f},
        {3f, 1f},
        {2f, 0f},
        {2f, -2f},
        {-1f, -3f}
    };

    public static float[,] level47 = new float[,]{
        {25f, 999f}, //Optimal solution
        {-1f, 4f},
        {1f, 4f},
        {3f, 3f},
        {-3f, 2f},
        {-2f, 2f},
        {-2f, 0f},
        {-3f, -3f}
    };

    public static float[,] level48 = new float[,]{
        {25f, 999f}, //Optimal solution
        {4f, 3f},
        {-3f, 2f},
        {-2f, 2f},
        {4f, 1f},
        {-1f, 0f},
        {2f, 0f},
        {4f, 0f},
        {-3f, -1f},
        {-2f, -1f},
        {4f, -1f},
        {0f, -2f}
    };

    public static float[,] level49 = new float[,]{
        {26f, 999f}, //Optimal solution
        {0f, 4f},
        {0f, 3f},
        {-2f, 2f},
        {4f, 2f},
        {-1f, 1f},
        {2f, 1f},
        {3f, 1f},
        {1f, 0f},
        {-1f, -1f},
        {2f, -2f},
        {4f, -2f},
        {-3f, -3f}
    };

    public static float[,] level50 = new float[,]{
        {26f, 999f}, //Optimal solution
        {3f, 4f},
        {4f, 4f},
        {4f, 3f},
        {-2f, 2f},
        {-1f, 2f},
        {2f, 2f},
        {0f, 1f},
        {3f, 1f},
        {-3f, 0f},
        {1f, -1f},
        {-2f, -3f}
    };

    public static float[,] level51 = new float[,]{
        {26f, 999f}, //Optimal solution
        {3f, 4f},
        {4f, 4f},
        {1f, 3f},
        {4f, 3f},
        {-1f, 2f},
        {2f, 2f},
        {-2f, 1f},
        {-1f, 1f},
        {1f, 1f},
        {3f, 0f},
        {-3f, -1f},
        {0f, -1f},
        {2f, -2f},
        {-2f, -3f},
        {-1f, -3f}
    };

    public static float[,] level52 = new float[,]{
        {27f, 999f}, //Optimal solution
        {-1f, 3f},
        {0f, 3f},
        {1f, 2f},
        {-2f, 1f},
        {0f, 0f},
        {-1f, -1f},
        {2f, -1f},
        {3f, -1f},
        {-1f, -2f},
        {-3f, -3f}
    };

    public static float[,] level53 = new float[,]{
        {27f, 999f}, //Optimal solution
        {1f, 4f},
        {3f, 4f},
        {1f, 3f},
        {-1f, 1f},
        {4f, 1f},
        {-2f, 0f},
        {-3f, -2f},
        {0f, -2f},
        {1f, -2f},
        {2f, -2f},
        {0f, -3f}
    };

    public static float[,] level54 = new float[,]{
        {28f, 999f}, //Optimal solution
        {0f, 3f},
        {-1f, 2f},
        {3f, 2f},
        {-3f, 1f},
        {1f, 1f},
        {-1f, 0f},
        {0f, 0f},
        {2f, 0f},
        {-1f, -2f}
    };

    public static float[,] level55 = new float[,]{
        {28f, 999f}, //Optimal solution
        {0f, 4f},
        {-1f, 2f},
        {0f, 1f},
        {-2f, 0f},
        {1f, -1f},
        {-3f, -2f},
        {-1f, -2f},
        {3f, -2f},
        {-1f, -3f}
    };

    public static float[,] level56 = new float[,]{
        {29f, 999f}, //Optimal solution
        {0f, 4f},
        {3f, 3f},
        {-1f, 2f},
        {-3f, 1f},
        {-2f, 1f},
        {-1f, 1f},
        {1f, 0f},
        {3f, 0f},
        {4f, 0f},
        {-3f, -1f},
        {-2f, -1f},
        {-1f, -3f}
    };

    public static float[,] level57 = new float[,]{
        {29f, 999f}, //Optimal solution
        {2f, 4f},
        {4f, 4f},
        {4f, 3f},
        {3f, 2f},
        {-2f, 1f},
        {0f, 1f},
        {4f, 0f},
        {-3f, -1f},
        {-1f, -2f},
        {-1f, -3f}
    };

    public static float[,] level58 = new float[,]{
        {30f, 999f}, //Optimal solution
        {-1f, 4f},
        {0f, 4f},
        {-1f, 3f},
        {2f, 3f},
        {3f, 3f},
        {4f, 3f},
        {0f, 1f},
        {2f, 0f},
        {-2f, -1f},
        {3f, -1f},
        {4f, -1f}
    };

    public static float[,] level59 = new float[,]{
        {30f, 999f}, //Optimal solution
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
    };

    public static float[,] level60 = new float[,]{
        {31f, 999f}, //Optimal solution
        {-1f, 4f},
        {0f, 4f},
        {1f, 4f},
        {4f, 4f},
        {2f, 3f},
        {-1f, 2f},
        {0f, 2f},
        {1f, 2f},
        {3f, 1f},
        {-3f, -1f},
    };

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
        level10,
        level11,
        level12,
        level13,
        level14,
        level15,
        level16,
        level17,
        level18,
        level19,
        level20,
        level21,
        level22,
        level23,
        level24,
        level25,
        level26,
        level27,
        level28,
        level29,
        level30,
        level31,
        level32,
        level33,
        level34,
        level35,
        level36,
        level37,
        level38,
        level39,
        level40,
        level41,
        level42,
        level43,
        level44,
        level45,
        level46,
        level47,
        level48,
        level49,
        level50,
        level51,
        level52,
        level53,
        level54,
        level55,
        level56,
        level57,
        level58,
        level59,
        level60,
    };
}
