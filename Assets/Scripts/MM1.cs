﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Math;
public class MM1 : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField LambdaInput;
    public InputField MiuInput;
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

    public double l = 0;


    public void generarNumeros(){
        //Recibir los input
        double lambda = double.Parse(LambdaInput.text);
        double miu = double.Parse(MiuInput.text);

        if(miu < lambda)
        {
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Lambda debe ser menor a miu";

        }
        else if (lambda < 0 || miu < 0 )
        {
            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "Los input deben de ser positivos";
        }
        else
        {

            Error_Text.GetComponent<UnityEngine.UI.Text>().text = "";

            double p = lambda / miu;

            print(p.ToString("0.00"));
            generarLQ(lambda, miu);
            l = generarL(lambda, miu);
            L_Result.GetComponent<UnityEngine.UI.Text>().text = l.ToString("0.00");
            generarWQ(lambda, miu);
            generarW(lambda, miu);
            PB_Result.GetComponent<UnityEngine.UI.Text>().text = p.ToString("0.00");

            costoCSInput.interactable = true;
            costoCWInput.interactable = true;
            CalcularCostos_Button.interactable = true;

            LambdaInput.interactable = false;
            MiuInput.interactable = false;
            Generar_Button.interactable = false;

        }

    }

    public void generarLQ(double lambda, double miu)
    {
        // resetTable();
        //Recibir los input

        double result = 0;

        result = (lambda * lambda) / (miu * (miu - lambda));


        
        LQ_Result.GetComponent<UnityEngine.UI.Text>().text = result.ToString("0.00") ;

    }
    public double generarL(double lambda, double miu)
    {
        // resetTable();
        //Recibir los input

        double result = 0;

        result = (lambda ) / (miu - lambda);

        return result;

        // L_Result.GetComponent<UnityEngine.UI.Text>().text = result.ToString("0.00");

    }
    public void generarWQ(double lambda, double miu)
    {
        double lq = 0;

        lq = (lambda * lambda) / (miu * (miu - lambda));

        double result = 0;

        result = lq / lambda;



        WQ_Result.GetComponent<UnityEngine.UI.Text>().text = result.ToString("0.00");



    }

    public void generarW(double lambda, double miu)
    {
        double l = 0;

        l = (lambda) / (miu - lambda);

        double result = 0;

        result = l / lambda;



        W_Result.GetComponent<UnityEngine.UI.Text>().text = result.ToString("0.00");



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
