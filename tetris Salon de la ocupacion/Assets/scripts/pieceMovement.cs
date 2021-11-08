using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceMovement : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f;
    float PreviousTime = 0;
    public static int width = 10;
    public static int height = 20;
    /*************************************************************************/
    public pieceRotation pieceRotation; // Referencia a script de rotacion
    public GridManager GridManager; //Referencia a script de management del grid
    public static Transform[,] grid = new Transform[width,height]; //Creamos el grid

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onRange(-1))
            transform.position += Vector3.left; //Vector3.left(-1,0,0), revisamos si la posicion hacia la que vamos es valida
        else if (Input.GetKeyDown(KeyCode.RightArrow) && onRange(1))
            transform.position += Vector3.right; //V3.right(1,0,0)
        //Para el DownArrow usamos GetKey en lugar de GetKeyDown,asi se mantiene true mientras este presionada la tecla.
        if (Time.time - PreviousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += Vector3.down; //(0,-1,0)
            PreviousTime = Time.time; //time.time: tiempo desde el inicio de la applicacion
            if(!(onRange(0))) // on range es 0, ya que side se usa para el mov horizontal no el vertical, comprobamos si esta posicion es valida, si  no lo es vector up rectifica
            {
                transform.position += Vector3.up;
                GridManager.AddToGrid(); //añadimos piezas al grid
                GridManager.CheckForLines(); //comprobamos si se ha creado una linea
                this.enabled = false; //paramos scripts de movimiento y rotacion
                pieceRotation.enabled = false;
                FindObjectOfType<SpawnPiece>().NewPiece(); // referenciar de esta forma es necesario ya que el script de spawn se encuentra en un objeto ya creado no uno que se instancia
            }
        }
    }

    public bool onRange(int side)
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x) + side; //dado que la posicion puede tener pequeñas variaciones hacemos un redondeo
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
                return(false); // comprobamos si la pieza esta en nuestra area de juego
            if (grid[roundedX,roundedY] != null) //comprobamos si esta dentro del grid
            {
                if (roundedY >= 18) //si esta en el grid y supera nuestra area de juego por encima es game over
                {
                    FindObjectOfType<SpawnPiece>().EndSpawning();
                }
                return(false);
            }
        }
        return(true);

    }
}
