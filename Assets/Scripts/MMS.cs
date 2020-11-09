using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Math;
public class MMS : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField LambdaInput;
    public InputField MiuInput;
    public InputField SInput;
    public InputField costoCSInput;
    public InputField costoCWInput;
    

    public Text L_Result;
    public Text LQ_Result;
    public Text W_Result;
    public Text WQ_Result;
    public Text PB_Result;

    public Text CostoService_Result;
    public Text CostoEspera_Result;
    public Text CostoTotal_Result;

    public Button Generar_Button;
    public Button CalcularCostos_Button;
    

    public Text Error_Text;

    public double s = 0;
    public double l = 0;

    // public GameObject CanvasReference;
    // public GameObject Row;
    // public GameObject TablePrefab;
    // public GameObject Semilla;
    // public GameObject Generador;
    // public GameObject Numero_aleatorio;
    // public GameObject Ri;
    // public GameObject Content;
    // public GameObject Errortext;

    public void generarNumeros()
    {
        // resetTable();
        //Recibir los input
        double lambda = double.Parse(LambdaInput.text);
        double miu = double.Parse(MiuInput.text);
        s = double.Parse(SInput.text);

        if(lambda < miu*s){
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "";
            double p0 = generarP0(lambda, miu, s);

            print("P0 " + p0);

            double p = generarP(lambda, miu, s);
            print("P " + p);
            double lq = generarLQ(lambda, miu, p0, p, s);

            l = generarL(lambda, miu ,lq);
            double wq = generarWQ(lambda, lq);
            double w = generarW(wq, miu);

            PB_Result.GetComponent<UnityEngine.UI.Text>().text = p.ToString("0.0000");
            L_Result.GetComponent<UnityEngine.UI.Text>().text = l.ToString("0.0000");
            LQ_Result.GetComponent<UnityEngine.UI.Text>().text = lq.ToString("0.0000");
            WQ_Result.GetComponent<UnityEngine.UI.Text>().text = wq.ToString("0.0000");
            W_Result.GetComponent<UnityEngine.UI.Text>().text = w.ToString("0.0000");

            costoCSInput.interactable = true;
            costoCWInput.interactable = true;
            CalcularCostos_Button.interactable = true;

            LambdaInput.interactable = false;
            MiuInput.interactable = false;
            SInput.interactable = false;
            Generar_Button.interactable = false;
        }else
        {
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Lambda no puede ser mayor a miu * s";
        }
    }

    public void CalcularCostos(){
        double costoL = double.Parse(costoCSInput.text);
        double costoLq = double.Parse(costoCWInput.text);

        double costoService = l*costoLq;
        double costoEspera = s*costoL;
        double costoTotal = costoService+costoEspera;
        

        CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = costoService.ToString("0.0000");
        CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = costoEspera.ToString("0.0000");
        CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");

        costoCSInput.interactable = false;
        costoCWInput.interactable = false;
        CalcularCostos_Button.interactable = false;
    }

    public double generarLQ(double lambda, double miu, double p0, double p, double s)
    {
        // resetTable();
        //Recibir los input

        double result = 0;

        result = ( p0 * Mathf.Pow((float)(lambda / miu), (float)s ) * p ) / ( factorial((float)s) * Mathf.Pow((float)(1 - p), 2))   ;



       
        return result;

    }

    public double generarP0(double l, double m, double s1)
    {
        // resetTable();
        //Recibir los input

        float result = 0f;
        float sum = 1f;


        float lambda = (float)(l);
        float miu = (float)(m);
        float s = (float)(s1);
        float a = 0f;
        float b = 0f;
        float c = 0f;
        for (float n = 0; n < s; n++)
        {
            
            a = a + Mathf.Pow(lambda / miu, n) / factorial(n);
           
           // print(" primera sumatoria " + a);
          
        }
        b = b + (Mathf.Pow(lambda / miu, s) / factorial(s));
      //  print(" segunda sumatoria " + b);
        c = 1 / (1 - (lambda / (s * miu)));
       // print(" tercer termino " + c);
        sum = a + b * c;
        result = 1 / sum;

       // print("P0"+ result);




        return result;

    }
    public float factorial(float n)
    {
    // resetTable();
    //Recibir los input


    float sum = 1f;

       for(float i = 1f; i <= n; i++)
    {
        sum = sum * i;
    }

    return sum;
  
    }
    public double generarP(double lambda, double miu, double s)
    {
        // resetTable();
        //Recibir los input

        double result = 0;

        result = lambda / (s*miu);
        print(result);

        return result;


       

    }
    public double generarL(double lambda, double miu , double lq)
    {
        // resetTable();
        //Recibir los input

        double result = 0;

        result = lq + (lambda) / miu ;
        return result;



    

    }
    public double generarWQ(double lambda, double lq)
    {
       

        double result = 0;

        result = lq / lambda;



        return result;



    }
    public double generarW(double wq, double miu)
    {
       

        double result = 0;

        result = wq + 1/ miu;



        return result;



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
