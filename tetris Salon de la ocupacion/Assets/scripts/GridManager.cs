using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;
    public pieceMovement pieceMovement;
    public static Transform[,] grid = pieceMovement.grid;
    ScoreManager scoreManager = null;
    int score = 100;

    private void Start()
    {
        // en el start, buscar el score manager por el tag, y hacer un get component al igual que antes este no es un prefab, no se engancha via interfaz, se espera a que nuestro prefab se instancie y posterior mente referenciamos
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }


        public void AddToGrid()
        {
                foreach (Transform children in transform) // se añaden todos los hijos del objeto en cuestion al grid
                {
                    int roundedX = Mathf.RoundToInt(children.transform.position.x);
                    int roundedY = Mathf.RoundToInt(children.transform.position.y);
                    grid[roundedX,roundedY] = children;

                }
        }


        public void CheckForLines()
        {
            for (int i = height-1; i >= 0; i--)
            {
                if(HasLine(i)) //hay una linea, si si..
                {
                    DeleteLine(i); //eliminamos...
                    RowDown(i); //Bajamos el resto del grud una linea
                    scoreManager.AddScore(score); // añadimos puntuacion...
                }
            }
        }

        bool HasLine(int i)
        {
            for(int j = 0; j < width; j++) //recorremos el grid a una altura i hasta width, comprobando si existe algun null.
            {
                if(grid[j,i] == null)
                    return(false);
            }
            return(true);
        }

        void DeleteLine(int i) // eliminamos todos los objetos de la linea
        {
            for(int j = 0; j < width; j++)
            {
                Destroy(grid[j,i].gameObject);
                grid[j, i] = null;
            }
        }

        void RowDown(int i)
        {
            for (int y = i; y < height; y++) // a partir de nuestra linea, si los objetos no son nulos se bajan de posicion.
            {
                for(int j = 0; j < width; j++)
                {
                    if(grid[j,y] != null)
                    {
                        grid[j, y - 1] = grid[j,y];
                        grid[j,y] = null;
                        grid[j,y -1].transform.position += Vector3.down;
                    }
                }
            }
        }
}
