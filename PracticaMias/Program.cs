using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace PracticaMias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animales es una clase normal, no abstracta, no es una interfaz,
            //pero tiene un metodo virtual y un metodo abstracto,
            //por lo tanto se puede crear un objeto de la clase Animales,
            //pero no se puede crear un objeto de la clase SerVivo
            //porque es una clase abstracta, y no se puede crear un objeto de la
            //interfaz IHacerRuido porque es una interfaz,
            //pero si se pueden crear objetos de las clases que heredan de Animales
            //y que implementan la interfaz IHacerRuido, como Perro, Gato, Pajaro y Arbol.
            Animales[] animales = new Animales[3];
            animales[0] = new Perro("Firulais", 5, "Labrador","croquetas");
            animales[1] = new Gato("Michi", 3, "Siames","pescado");
            animales[2] = new Pajaro("Piolin", 2, "Canario","semillas");
            string nombreAux = " "; 
            foreach (Animales animal in animales)
            {
                if (animal.Nombre == "Firulais")
                { 
                    nombreAux = animal.Nombre;
                    animal.Nombre = "TERNURA";
                    Console.WriteLine($"Antes me llamaba {nombreAux} ahora me llamo: {animal.Nombre}");
                }
                Console.WriteLine($"Nombre: {animal.Nombre}, Edad: {animal.Edad}");
            }

            Plantas[] plantas = new Plantas[2];
            plantas[0] = new Flor("Rosa", "Rojo", 30);
            plantas[1] = new Arbol("Roble", "Verde", 5);

            foreach (Plantas planta in plantas)
            {
                Console.WriteLine($"Nombre: {planta.Nombre}, Color: {planta.Color}");
            }


            IHacerRuido[] hacerRuidos = new IHacerRuido[4];
            hacerRuidos[0] = new Perro("Firulais", 5, "Labrador","croquetas");
            hacerRuidos[1] = new Gato("Michi", 3, "Siames","pescado");
            hacerRuidos[2] = new Pajaro("Piolin", 2, "Canario","semillas");
            hacerRuidos[3] = new Arbol("Roble", "Verde", 5);

            foreach (IHacerRuido hacerRuido in hacerRuidos)
            {
                hacerRuido.HacerRuido();
                hacerRuido.Servivo();

            }
        }
    }
    public interface IHacerRuido
    {
        void HacerRuido();
        void Servivo();
    }
    public abstract class SerVivo
    {
        public string Alimento { get; set; }
        public SerVivo()
        {
            Alimento = " ";
        }
        public SerVivo(string alimento)
        {
            Alimento = alimento;
        }

        public abstract void Servivo();
    }
    public class Animales : SerVivo
    {
        private string nombre;
        public int Edad;
        public Animales()
        {
            nombre = " ";
            Edad = 0;
            
        }
        public Animales(string nombre, int edad, string alimento):base(alimento)
        {
            this.nombre = nombre;
            this.Edad = edad;
            this.Alimento = alimento;
        }
        public string Nombre
        { 
          get { return nombre; }
          set { nombre = value; }
        }
        //virtual porque recien lo estoy implementando en la clase Animales,
        //y despues lo voy a sobreescribir en las clases Perro, Gato, Pajaro y Arbol.
        public virtual void HacerRuido()
        {
            Console.WriteLine("El animal hace un ruido");
        }
        //override porque estoy sobreescribiendo el metodo abstracto Servivo de la clase SerVivo,
        //y lo estoy implementando en la clase Animales,
        //y despues lo voy a sobreescribir en las clases Perro, Gato, Pajaro y Arbol.
        public override void Servivo()
        {
            Console.WriteLine("Soy un ser vivo");
        }

    }
    public class Perro : Animales, IHacerRuido
    {
        protected string Raza { get; set; }
        public Perro(string nombre, int edad, string raza, string alimento) : base(nombre, edad,alimento)
        {
            Raza = raza;
            Alimento = alimento;
        }
        public override void HacerRuido()
        {
            base.HacerRuido();
            Console.WriteLine("Guau Guau");
        }
        public override void Servivo()
        {
            Console.WriteLine("Soy un perro y soy un ser vivo");
        }
    }
    public class Gato : Animales, IHacerRuido
    {
        public string Raza { get; set; }
        public Gato(string nombre, int edad, string raza, string alimento) : base(nombre, edad, alimento)
        {
            Raza = raza;
            Alimento = alimento;
        }
        public override void HacerRuido()
        {
            base.HacerRuido();
            Console.WriteLine("Miau Miau");
        }
        public override void Servivo()
        {
            Console.WriteLine("Soy un gato y soy un ser vivo");
        }
    }
    public class Pajaro : Animales, IHacerRuido
    {
        public string Especie { get; set; }
        public Pajaro(string nombre, int edad, string especie, string alimento) : base(nombre, edad, alimento)
        {
            Especie = especie;
            Alimento = alimento;
        }
        public override void HacerRuido()
        {
            base.HacerRuido();
            Console.WriteLine("Pio Pio");
        }
        public  override void Servivo()
        {
            Console.WriteLine("Soy un pajaro y soy un ser vivo");
        }
    }
    public class Plantas 
    {
        public string Nombre { get; set; }
        public string Color { get; set; }

        public Plantas()
        {
            Nombre = " ";
            Color = " ";
        }
        public Plantas(string nombre, string color)
        {
            Nombre = nombre;
            Color = color;
        }


    }
    public class Flor : Plantas
    {
        public int Altura { get; set; }
        public Flor(string nombre, string color, int altura) : base(nombre, color)
        {
            Altura = altura;
        }
    }
    public class Arbol : Plantas, IHacerRuido
    {
        public int Edad { get; set; }
        public Arbol(string nombre, string color, int edad) : base(nombre, color)
        {
            Edad = edad;
        }
        public void HacerRuido()
        {
            Console.WriteLine("El viento sopla entre las hojas");
        }
        public void Servivo()
        {
            Console.WriteLine("Soy un arbol y soy un ser vivo");
        }
    }
    
    
}
