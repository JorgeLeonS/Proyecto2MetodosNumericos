using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Math;
public class ME1 : MonoBehaviour
{

    public InputField LambdaInput;
    public InputField MiuInput;
    public InputField KInput;


    public InputField costoCSInput;
    public InputField costoCWInput;
    public Text CostoService_Result;
    public Text CostoEspera_Result;
    public Text CostoTotal_Result;

    public Text L_Result;
    public Text LQ_Result;
    public Text W_Result;
    public Text WQ_Result;
    public Text PB_Result;

    public Text Error_Text;

    public Button Generar_Button;
    public Button CalcularCostos_Button;

    public double s = 1;
    public double l = 0;
    public double desviacion = 0;

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
        double k = double.Parse(KInput.text);
        desviacion = (double)(1 / Mathf.Sqrt((float)k));

        if (miu < lambda)
        {
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Lambda debe ser menor a miu";

        }
        else if (lambda < 0 || miu < 0 || k < 0)
        {
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Los input deben de ser positivos";
        }
        else
        {
            desviacion = desviacion * 1 / miu;
            print("des " + desviacion);
            print("lambda " + lambda);
            print("miu " + miu);


            double p = generarP(lambda, miu);
            double p0 = generarP0(p);

            print("P0 " + p0);
            print("P " + p);


            double lq = generarLQ(lambda, miu, p, desviacion);
            
            double wq = generarWQ(lq, lambda);
            double w = generarW(wq, miu);
            l = generarL(lambda, w);



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
            KInput.interactable = false;

            Generar_Button.interactable = false;

        }

       

    }


    public double generarLQ(double l, double m, double p, double d)
    {
        // resetTable();
        //Recibir los input




        float des = (float)(d);
        float lambda = (float)(l);
        float miu = (float)(m);
        float p0 = (float)(p);
        float result = 0.0f;

        result = (lambda * lambda * des * des + (p0 * p0)) / (2 * (1 - p0));




        return result;

    }

    public double generarW(double a, double b)
    {
        // resetTable();
        //Recibir los input




        float wq = (float)(a);
        float miu = (float)(b);

        float result = 0.0f;

        result = wq + (1 / miu);




        return result;

    }

    public double generarL(double l, double w)
    {
        // resetTable();
        //Recibir los input


        float lambda = (float)(l);

        float w1 = (float)(w);
        float result = 0.0f;

        result = lambda * w1;

        return result;

    }

    public double generarWQ(double l, double lam)
    {
        // resetTable();
        //Recibir los input




        float lq = (float)(l);
        float lambda = (float)(lam);


        float result = 0.0f;

        result = lq / lambda;




        return result;

    }

    public double generarP(double l, double m)
    {
        // resetTable();
        //Recibir los input

        float result = 0f;


        float lambda = (float)(l);
        float miu = (float)(m);


        result = lambda / miu;


        return result;

    }

    public double generarP0(double a)
    {
        // resetTable();
        //Recibir los input

        float result = 0f;


        float p = (float)(a);



        result = 1 - p;


        return result;

    }

    public float factorial(float n)
    {
        // resetTable();
        //Recibir los input


        float sum = 1f;

        for (float i = 1f; i <= n; i++)
        {
            sum = sum * i;
        }

        return sum;

    }


    public void CalcularCostos(){
        bool disableInput = false;
        if (costoCSInput.text == "" && costoCWInput.text == ""){
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Costos vacios";
        } else if(costoCSInput.text == ""){
            double costoCW = double.Parse(costoCWInput.text);
            if (costoCW < 0 )
            {
                Error_Text.GetComponent<UnityEngine.UI.Text>().text = "El costo de espera debe ser positivo";
            }else{
                double costoEspera = l*costoCW;
                double costoTotal = costoEspera;
                CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = "0";
                CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = costoEspera.ToString("0.0000");
                CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");
                disableInput=true;
            }

        }else if(costoCWInput.text == ""){
            double costoCS = double.Parse(costoCSInput.text);
            if (costoCS < 0 )
            {
                Error_Text.GetComponent<UnityEngine.UI.Text>().text = "El costo de servicio debe ser positivo";
            }else{
                double costoServicio = costoCS;
                double costoTotal = costoServicio;
                CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = costoServicio.ToString("0.0000");
                CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = "0";
                CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");
                disableInput=true;
            }
        }else{
            

            double costoCS = double.Parse(costoCSInput.text);
            double costoCW = double.Parse(costoCWInput.text);

            if (costoCS < 0 || costoCW < 0 )
            {
                Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Los costos deben de ser positivos";
            }else{
                
            double costoService = costoCS;
            double costoEspera = l*costoCW;
            double costoTotal = costoService+costoEspera;
            

            CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = costoService.ToString("0.0000");
            CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = costoEspera.ToString("0.0000");
            CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");                
            disableInput=true;
            }

        }

        if(disableInput){
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "";
            costoCSInput.interactable = false;
            costoCWInput.interactable = false;
            CalcularCostos_Button.interactable = false;
        }
    }

}
