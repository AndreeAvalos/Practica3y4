using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica3_4.Helpers
{
    public class TransferenciaHelper
    {


        public static Respuesta set_Transferencia(int Cuenta_Recibe, int Cuenta_Da, double monto_debitar, string password)
        {
            //Existe cuenta y coincide la contrasena la cual va a hacer la transferencia
            if (correct_Cuenta(Cuenta_Da, password))
            {
                //Verificamos si la cuenta que recibe la transferencia existe
                if (exist_Cuenta(Cuenta_Recibe))
                {
                    //verificamos si la cuenta tiene suficientes fondos
                    if (get_Saldo(Cuenta_Da, monto_debitar))
                    {
                        //Si tiene fondos suficientes, entonces debitamos y cerramos la transaccion
                        // con un resultado exitoso.
                        set_Saldo(Cuenta_Recibe, monto_debitar);
                        return new Respuesta("Transaccion realizada con exito.", true);
                    }
                    return new Respuesta("No tiene suficientes para realizar la transaccion", false);
                }
                return new Respuesta("No existe cuenta a la cual transferir el monto", false);
            }
            //Si no encuentra entonces regresa false hacia la peticion
            return new Respuesta("No existe cuenta a la cual debitar o contraseña invalida", false);
        }
        private static bool correct_Cuenta(int num_cuenta, string pass)
        {
            foreach (Usuario item in cargarData.users)
            {
                if (item.Cuenta == num_cuenta && item.Password.Equals(pass)) return true;
            }
            return false;
        }
        private static bool exist_Cuenta(int num_cuenta)
        {
            foreach (Usuario item in cargarData.users)
            {
                if (item.Cuenta == num_cuenta) return true;
            }
            return false;
        }
        private static bool get_Saldo(int num_cuenta, double saldo_a_debitar)
        {

            foreach (Usuario item in cargarData.users)
            {
                if (item.Cuenta == num_cuenta && item.Saldo >= saldo_a_debitar) return true;
            }
            return false;
        }

        private static void set_Saldo(int num_cuenta, double saldo)
        {
            foreach (Usuario item in cargarData.users)
            {
                if (item.Cuenta == num_cuenta) item.Saldo += saldo;
            }
        }
    }
}