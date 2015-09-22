using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica
{
    class Fabrica
    {
        private Operario[] _operarios;
        private string _razonSocial;

        public Fabrica()
        {
            this._operarios=new Operario[5];
        }

        public Fabrica(string razonSocial): this()
        {
            this._razonSocial = razonSocial;
        }

        public string Mostrar()
        {
            return ("\nRazon social: "+this._razonSocial+"\n\n"+this.MostrarOperarios());
        }

        private float RetornarCostos()
        {
            float acumulador = 0;

            for (int i = 0; i < this._operarios.Length; i++)
            {
                acumulador = acumulador + this._operarios[i].getSalario();
            }

            return acumulador;
        }

        private int ObtenerIndice()
        {
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios.GetValue(i) == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private int ObtenerIndice(Operario op)
        {
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios.GetValue(i) == op)
                {
                    return i;
                }
            } 
            return -1;
        }

        private string MostrarOperarios()
        {
            string todos = null;

            for (int i = 0; i < this._operarios.Length; i++)
            {
                todos = todos + this._operarios[i].Mostrar();
            }
            return todos;
        }

        public static void MostrarCosto(Fabrica fbr)
        {
            Console.WriteLine(fbr.RetornarCostos());
        }

        public static bool operator ==(Fabrica fbr, Operario op)
        {
            for (int i = 0; i < fbr._operarios.Length ; i++)
            {
                if (fbr._operarios.GetValue(i) == op)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Fabrica fbr, Operario op)
        {
            return !(fbr == op);
        }

        public static Fabrica operator +(Fabrica fbr, Operario op)
        {
            if (fbr.ObtenerIndice() == -1)
            {
                Console.WriteLine("No hay mas cupo!");
            }
            else
            {
                if (fbr == op)
                {
                    Console.WriteLine("No se encontro al operario!");
                }
                else
                {
                    fbr._operarios[fbr.ObtenerIndice()] = op;
                }
            }
            return fbr;
        }

        public static Fabrica operator -(Fabrica fbr, Operario op)
        {
            if (fbr.ObtenerIndice() != -1)
            {
                if (fbr == op)
                {
                    fbr._operarios[fbr.ObtenerIndice()] = null;
                }
            }
            return fbr;
        }
    }
}
