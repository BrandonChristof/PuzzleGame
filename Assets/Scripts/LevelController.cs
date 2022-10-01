using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject standard_win;
    public GameObject star_win;
    public GameObject lose;

    public AudioSource audio_source;
    public AudioClip[] notes = new AudioClip[4];

    private GameObject[] squares;
    public GameObject[] finish;
    public GameObject wall;
    private HashSet<Vector3> walls = new HashSet<Vector3>();
    private int[,] coords = new int[5,2] {{0, 0}, {0, 1}, {1, 0}, {0, -1}, {-1, 0}}; //None, Up, Right, Down, Left
    private enum Directions {
        None,
        Up,
        Right,
        Down,
        Left
    }
    public int curr_level;
    public float optimal_moves;
    public int num_moves;
    public int counter = 0;
    private bool moving = false;
    private bool moved = false;
    private int dir = 0;
    private bool tap, swipe_left, swipe_right, swipe_up, swipe_down;
    private bool is_dragging = false;
    private Vector2 start_touch, swipe_delta;

    private void Awake(){
        curr_level = LevelSelect.GetLevel();
    }
    void Start()
    {
        Application.targetFrameRate = 60;

        float wid = Screen.width;
        float het = Screen.height;
        float ratio = (wid/het);
        Debug.Log(ratio);
        if (ratio > 0.7f){
            ratio = 8f;
        }
        else if (ratio > 0.5f){
            ratio = 10f;
        }
        else{
            ratio = 12f;
        }

        Camera.main.orthographicSize = ratio;
        

        squares = GameObject.FindGameObjectsWithTag("square");
        finish = GameObject.FindGameObjectsWithTag("finish");
        CreateLevel(Levels.levels[curr_level-1]);
        optimal_moves = Levels.levels[curr_level-1][0, 0];

        GameObject[] wall_list = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject w in wall_list) {
            Vector3 wall = new Vector3(w.transform.position.x, w.transform.position.y, 0f);
            walls.Add(wall);
        }
    }

    void Update(){
        if(!moving){
            dir = GetSwipeValue();
        }
    }

    void FixedUpdate()
    {
        if(moving){
            MoveSquares();
        }
    }

    int GetSwipeValue(){

        if(Input.GetMouseButtonDown(0)){
            tap = true;
            is_dragging = true;
            start_touch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0)){
            is_dragging = false;
        }

        swipe_delta = Vector2.zero;

        if(is_dragging){
            if(Input.touches.Length > 0){
                swipe_delta = Input.touches[0].position - start_touch;
            }
            else if(Input.GetMouseButton(0)){
                swipe_delta = (Vector2)Input.mousePosition - start_touch;
            }
        }

        return CheckDelta(swipe_delta);
    }

    int CheckDelta(Vector2 delta){
        Directions d = Directions.None;
        if(delta.magnitude > 125){
            moving = true;
            moved = false;
            float x = delta.x;
            float y = delta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y)){
                if(x < 0){
                    d = Directions.Left;
                }
                else{
                    d = Directions.Right;
                }
            }
            else{
                if(y < 0){
                    d = Directions.Down;
                }
                else{
                    d = Directions.Up;
                }
            }
        }
        return (int) d;
    }

    void MoveSquares(){
        if (!moved){
            num_moves++;
        }
        
        moving = false;
        List<Vector3> square_positions = new List<Vector3>();
        
        
        foreach (GameObject s in squares) {
            if (s==null){ continue; }

            Vector3 square = new Vector3(s.transform.position.x, s.transform.position.y, 0f);
            square_positions.Add(square);
        }
        
        foreach (GameObject s in squares) {
            if (s==null){ continue; }

            s.transform.position += new Vector3(coords[dir, 0], coords[dir, 1], 0f);

            if (walls.Contains(s.transform.position)){
                s.transform.position -= new Vector3(coords[dir, 0], coords[dir, 1], 0f);
            }
            else if (square_positions.Contains(s.transform.position)){
                s.transform.position -= new Vector3(coords[dir, 0], coords[dir, 1], 0);
            }
            else{
                // Slowdown movement
                //float slow_x = Mathf.Round(coords[dir, 0]*(0.9f) * 100f * 0.01f);
                //float slow_y = Mathf.Round(coords[dir, 1]*(0.9f) * 100f * 0.01f);
                s.transform.position -= new Vector3(coords[dir, 0]*0.5f, coords[dir, 1]*0.5f, 0f);
            }

            if (finish[0].transform.position == s.transform.position){
                if (BackgroundMusic.sound_effects){
                    audio_source.PlayOneShot(notes[counter], 0.33f);
                }                
                counter++;
                Destroy(s);
            }

            if (!square_positions.Contains(s.transform.position)){
                moving = true;
                moved = true;
            }
        }

        if (!moving && !moved){
            num_moves--;
        }
        if (!moving){
            CheckGameStatus();
        }
    }

    public void CheckGameStatus(){
        if (counter == 0){
            return;
        }
        else if (counter != 4){
            lose.SetActive(true);
            this.enabled = false;
        }
        else{
            int rank = 1;
            if (num_moves <= optimal_moves){
                rank = 2;
            }

            //SaveSystem.SetData(SceneManager.GetActiveScene().buildIndex-1, num_moves, rank);
            SaveSystem.SetData(curr_level-1, num_moves, rank);

            if (rank == 1){
                standard_win.SetActive(true);
                this.enabled = false;
            }
            else{
                star_win.SetActive(true);
                this.enabled = false;
            }
        }
    }

    public void CreateLevel(float[,] level_data){

        float[,] borders = Levels.borders;
        for (int v = 0; v < borders.GetLength(0); v++){
            float x = borders[v, 0];
            float y = borders[v, 1];
            Instantiate(wall, new Vector3(x, y, 0f), Quaternion.identity);
        }

        for (int v = 1; v < level_data.GetLength(0); v++){
            float x = level_data[v, 0];
            float y = level_data[v, 1];
            Instantiate(wall, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}
