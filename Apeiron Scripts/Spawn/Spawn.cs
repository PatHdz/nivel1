using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawn;
    private List<string> shapeList;

    private void Awake(){
        shapeList = new List<string>() {"Arch", "Heart", "Circle", "Diamond", "Hexagon", "Octagon", "Oval", "Parallelogram", "Pentagon", "Rectangle", "Square", "Trapeze", "Triangle"};
        ShapeSpawning();
    }

    private void ShapeSpawning(){
        float x;
        float y;
        for (int i = 0; i < spawn.Count; i++){
            x = Random.Range(-7f, 7f);
            y = Random.Range(-3f, 3f);
            GameObject auto = Instantiate(spawn[i], new Vector3(x, y, 0), Quaternion.identity);
            auto.gameObject.tag = shapeList[i];
            auto.transform.parent = this.transform;
            }
    }
}
