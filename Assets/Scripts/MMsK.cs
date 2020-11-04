using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Math;
public class MMsK : MonoBehaviour
{

    public InputField LambdaInput;
    public InputField MiuInput;
    public InputField SInput;
    public InputField KInput;
    public Text L_Result;
    public Text LQ_Result;
    public Text T_Result;
    public Text TQ_Result;
    public Text TS_Result;
    public Text W_Result;
    public Text WQ_Result;
    public Text PB_Result;
    public Text Error_Text;

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
        double s = double.Parse(SInput.text);
        double k = double.Parse(KInput.text);

        /*    if (miu < lambda)
            {
                Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Pon los input bien";

            }
            else
            {
                float fac = factorial(0f);
                print("factorial 0 " + fac);

                float fac1 = factorial(1f);
                print("factorial 1 " + fac1);

                double p0 = generarP0(lambda, miu, s);

                print("P0 " + p0);          
                double lq = generarLQ(lambda, miu);
                LQ_Result.GetComponent<UnityEngine.UI.Text>().text = lq.ToString("0.00");
                generarL(lambda, miu);
                generarWQ(lambda, miu);
                generarW(lambda, miu);
                double p =  generarP(lambda, miu, s);
                PB_Result.GetComponent<UnityEngine.UI.Text>().text = p.ToString("0.00");


            }*/


        double p0 = generarP0(lambda, miu, s);

        print("P0 " + p0);
      
        double p = generarP(lambda, miu, s);
        print("P " + p);
        double lq = generarLQ(lambda, miu, p0, p, s);
        
        double l = generarL(lambda, miu ,lq);
        double wq = generarWQ(lambda, lq);
        double w = generarW(wq, miu);
        
        PB_Result.GetComponent<UnityEngine.UI.Text>().text = p.ToString("0.0000");
        L_Result.GetComponent<UnityEngine.UI.Text>().text = l.ToString("0.0000");
        LQ_Result.GetComponent<UnityEngine.UI.Text>().text = lq.ToString("0.0000");
        WQ_Result.GetComponent<UnityEngine.UI.Text>().text = wq.ToString("0.0000");
        W_Result.GetComponent<UnityEngine.UI.Text>().text = w.ToString("0.0000");



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
