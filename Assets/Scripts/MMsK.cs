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
        double k = double.Parse(KInput.text);

        if(lambda < miu*s){
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "";

            double p0 = generarP0(lambda, miu, s, k);

            print("P0 " + p0);
        
            double p = generarP(lambda, miu, s);
            print("P " + p);
            double lq = generarLQ(lambda, miu, p0, p, s, k);

            double pk = generarPn(s, k, lambda, miu, p0);
            print(pk);

            double lambdae = lambda*(1-pk);
            print(lambdae);

            double wq = lq/lambdae;
            double w = wq+(1/miu);
            l = lambdae*w;
            
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
            KInput.interactable = false;
            Generar_Button.interactable = false;
        }else{
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Lambda no puede ser mayor a miu * s";
        }

    }

    public double generarPn(double s1, double k1, double lambda1, double miu1, double p0){

        float n = (float)(k1);
        double pn = 0;

        float s = (float)(s1);
        float lambda = (float)(lambda1);
        float miu = (float)(miu1);

        if(n<s){
            pn = (Mathf.Pow((lambda/miu),n)/factorial(n))*p0;
        }else{
            pn = (Mathf.Pow((lambda/miu),n)/(factorial(s)*Mathf.Pow(s, n-s)))*p0;
        }
        return pn;
    }

    public double generarLQ(double lambda, double miu, double p0, double p, double s, double k)
    {
        // resetTable();
        //Recibir los input

        double resultLqMMS = 0;
        double timesMMSK = 0;

        resultLqMMS = ( p0 * Mathf.Pow((float)(lambda / miu), (float)s ) * p ) / ( factorial((float)s) * Mathf.Pow((float)(1 - p), 2));

        float p1 = (float)(p);
        float k1 = (float)(k);
        float s1 = (float)(s);

        timesMMSK = (1-(Mathf.Pow(p1, k1-s1))-((k1-s1)*Mathf.Pow(p1, k1-s1))*(1-p1));

        return resultLqMMS*timesMMSK;

    }

    public double generarP0(double l, double m, double s1, double k1)
    {
        // resetTable();
        //Recibir los input

        float result = 0f;
        float sum = 1f;


        float lambda = (float)(l);
        float miu = (float)(m);
        float s = (float)(s1);
        float k = (float)(k1);
        float a = 0f;
        float b = 0f;
        float c = 0f;
        for (float n = 0; n <= s; n++)
        {
            
            a = a + Mathf.Pow(lambda / miu, n) / factorial(n);
           
           // print(" primera sumatoria " + a);
          
        }
        b = b + (Mathf.Pow(lambda / miu, s) / factorial(s));
      //  print(" segunda sumatoria " + b);

        for(float n1=s+1;n1<=k;n1++){

            c = c + Mathf.Pow((lambda) / (s*miu), (n1-s));

        }
    
        // c = 1 / (1 - (lambda / (s * miu)));
       // print(" tercer termino " + c);
        sum = a + b * c;
        result = 1 / sum;

    //    print("P0"+ result);




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

    public void CalcularCostos(){

        if(costoCSInput.text == ""){
            double costoCW = double.Parse(costoCWInput.text);
            double costoEspera = l*costoCW;
            double costoTotal = costoEspera;
            CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = "0";
            CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = costoEspera.ToString("0.0000");
            CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");

        }else if(costoCWInput.text == ""){
            double costoCS = double.Parse(costoCSInput.text);
            double costoServicio = s*costoCS;
            double costoTotal = costoServicio;
            CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = costoServicio.ToString("0.0000");
            CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = "0";
            CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");
        }else{
            double costoCS = double.Parse(costoCSInput.text);
            double costoCW = double.Parse(costoCWInput.text);



            double costoService = s*costoCS;
            double costoEspera = l*costoCW;
            double costoTotal = costoService+costoEspera;
            

            CostoService_Result.GetComponent<UnityEngine.UI.Text>().text = costoService.ToString("0.0000");
            CostoEspera_Result.GetComponent<UnityEngine.UI.Text>().text = costoEspera.ToString("0.0000");
            CostoTotal_Result.GetComponent<UnityEngine.UI.Text>().text = costoTotal.ToString("0.0000");
        }

        costoCSInput.interactable = false;
        costoCWInput.interactable = false;
        CalcularCostos_Button.interactable = false;
    }

}
