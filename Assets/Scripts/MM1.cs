using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Math;
public class MM1 : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField LambdaInput;
    public InputField MiuInput;
    // public GameObject CanvasReference;
    // public GameObject Row;
    // public GameObject TablePrefab;
    // public GameObject Semilla;
    // public GameObject Generador;
    // public GameObject Numero_aleatorio;
    // public GameObject Ri;
    // public GameObject Content;
    // public GameObject Errortext;

    public void generarNumeros(){
        // resetTable();
        //Recibir los input
        int lambda = int.Parse(LambdaInput.text);
        int miu = int.Parse(MiuInput.text);

        double p = (double)(lambda) / (double)(miu);

        print(p.ToString("0.00"));

        
    }

    // public void createNewRow(string semilla, string generador, string nAleatorio, float ri){
    //     //Instanciar nueva fila
    //     GameObject new_row = Instantiate(Row,new Vector3(0,0,0) , Quaternion.identity) as GameObject;
    //     //Unirla a la tabla
    //     new_row.transform.SetParent (Content.transform, false);
        
    //     //Unir los objetos de texto con el codigo
    //     Semilla = new_row.transform.Find("Semilla").gameObject;
    //     Generador = new_row.transform.Find("Generador").gameObject;
    //     Numero_aleatorio = new_row.transform.Find("Numero aleatorio").gameObject;
    //     Ri = new_row.transform.Find("Ri").gameObject;

    //     //Poner los valores correspondientes
    //     Semilla.GetComponent<Text>().text =semilla;
    //     Generador.GetComponent<Text>().text = generador;
    //     Numero_aleatorio.GetComponent<Text>().text = nAleatorio;
    //     Ri.GetComponent<Text>().text= ri.ToString("0.0000");
    // }
    // public void resetValues(){
    //     semillaInput.text = "";
    //     nInput.text="";
    //     resetTable();
    // }

    // public void resetTable(){
    //     if (GameObject.Find("Table")){
    //         Destroy(GameObject.Find("Table"));
    //     }else{
    //         Destroy(GameObject.Find("Table(Clone)"));
    //     }   
    //     GameObject new_Table = Instantiate(TablePrefab,new Vector3(-504.9432f,150.2171f,-266.1887f) , Quaternion.identity) as GameObject;
    //     new_Table.transform.SetParent (CanvasReference.transform, false);
    //     Content = new_Table.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
    // }

}
