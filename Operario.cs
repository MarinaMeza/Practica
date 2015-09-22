using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica
{
    class Operario
    {
        private string _apellido;
        private int _legajo;
        private string _nombre;
        private float _salario;

        public Operario()
        {
            this._salario = 1500;
        }

        public Operario(string nombre, string apellido): this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public Operario(string nombre, string apellido, int legajo): this(nombre, apellido)
        {
            this._legajo = legajo;
        }

        public float getSalario()
        {
            return this._salario;
        }

        public void setAumentarSalario(float aumento)
        {
            this._salario = this._salario + (this._salario * (aumento / 100));
        }

        public string ObtenerNombreYApellido()
        {
            return this._nombre + ", " + this._apellido;
        }

        public string Mostrar()
        {
            return this.ObtenerNombreYApellido() + "\nLegajo: " + this._legajo + "\nSalario: " + this._salario+"\n";
        }

        public static string MostrarR(Operario op)
        {
            return op.Mostrar();
        }

        public static bool operator ==(Operario op1, Operario op2)
        {
            if (op1.ObtenerNombreYApellido() == op2.ObtenerNombreYApellido())
            {
                if (op1._legajo == op2._legajo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Operario op1, Operario op2)
        {
            return !(op1 == op2);
        }
    }
}
