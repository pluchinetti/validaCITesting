using System;
using System.Linq;

namespace Person
{
    public class Person
    {
        public Person(string fullname, string id)  // Método constructor.
        {
            this.Fullname = fullname;
            this.Id = id;
        }
        public string Fullname { get; set; }    // Declaración de los atributos de la clase, y de los métodos get y set.
        public string Id { get; set; }

        public void IntroduceYourself() // Método para la impresión en pantalla de los datos de la persona.
        {
            Console.WriteLine("Nombre completo: " +this.Fullname + " | Nº de C. I.: " + this.Id);
        }

        public bool ValidateId() // Algoritmo para validación de Nº de C. I. modificado. Original: https://es.wikipedia.org/wiki/C%C3%A9dula_de_Identidad_de_Uruguay
        //public bool ValidateId(string ID, out string errorMsg)
        {
            string ci = this.Id;
            //errorMsg = "";
            long verificadorFormato;
            //Validar largo
            if (ci.Length == 8 && long.TryParse(ci, out verificadorFormato))
            {
                var vectorStrCI = ci.ToCharArray();
                var vectorCI = vectorStrCI.Select(c => int.Parse(c.ToString())).ToArray();
                var vectorReferencia = "2987634".ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
                var verificadorIngresado = vectorCI[7];
                //Calcular número verificador
                int numeroVerificadorRaw = 0;
                for (int i = 0; i < vectorReferencia.Length; i++)
                {
                    numeroVerificadorRaw = numeroVerificadorRaw + (vectorCI[i] * vectorReferencia[i]);
                }
                int verificadorCalculado = 10 - (numeroVerificadorRaw % 10);
                if(verificadorCalculado != verificadorIngresado)
                {
                    //errorMsg = "Número verificador ingresado inválido";
                    return false;
                }
            }
            else
            {
                //errorMsg = "Formato de cédula de identidad inválido";
                return false;
            }
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Person john = new Person("John Doe", "1.234.567-8");
            Person john = new Person("John Doe", "47405029");
            Person jane = new Person("Jane Doe", "8.765.432-1");
            john.IntroduceYourself();
            jane.IntroduceYourself();
            
            if (john.ValidateId())
                Console.WriteLine("Cédula correcta.");
            else
                Console.WriteLine("Cédula incorrecta.");                
        }
    }
}
