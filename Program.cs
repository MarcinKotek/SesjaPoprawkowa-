using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BiuroPodrozy_Marcin_Kotek
{
    class Program
    {
        class SrodekLokomocji<T>
        {
           
            private int[] array;
            private T[] genericArray;
            
            public SrodekLokomocji(int size)
            {
                array = new int[size + 1];
                genericArray = new T[size + 1];
            }
            public int getItem(int index)
            {
                return array[index];
            }
            public T getGenericItem(int index)
            {
                return genericArray[index];
            }
            public void setValue(int index, int value)
            {
                array[index] = value;
            }
            public void setGenericValue(int index, T value)
            {
                genericArray[index] = value;
            }
        }

        static void Main(string[] args)
        {
            SrodekLokomocji i = new Autobus();
            i.ToString();
            
            SrodekLokomocji j = new Pociąg();
            j.ObliczCene();

            SrodekLokomocji k = new Express();
            k.ObliczCene();

            SrodekLokomocji l = new Podroz();
            l.City();
            Console.ReadKey();
        }
    }

    public abstract class SrodekLokomocji
    {
        public int iloscMiejsc { get; set; }
        protected double cenaBiletu { get; set; }

        virtual public void ObliczCene() 
        {
           
        }

        virtual public void City()
        {

        }
    }
    public class Autobus : SrodekLokomocji
    {

        new int iloscMiejsc = 50;
        new double cenaBiletu = 50;
        
        public override string ToString()
        {
            
            Console.WriteLine("Autobus: ilosc miejsc: " + iloscMiejsc + ",cena biletu: " + cenaBiletu);
            return base.ToString();
        }
    }
    public class Pociąg : SrodekLokomocji
    {
        
        new int iloscMiejsc = 50;
        new double dlugoscTrasy = 200;
        double Trasa;
        double mnoznik = 1.43;
               
        public override void ObliczCene()
        {
            if (dlugoscTrasy > 100) Trasa = dlugoscTrasy * mnoznik;
            if (dlugoscTrasy <= 100) Trasa = 50;
            Console.WriteLine("Pociąg: ilosc miejsc: " + iloscMiejsc + ", dlugosc trasy: " + dlugoscTrasy + ", cena biletu: " + Trasa);
             base.ObliczCene();
        }
    }
    public class Express : SrodekLokomocji
    {
        double dlugoscTrasy = 200;
        public override void ObliczCene()
        {
            cenaBiletu = 200;
            iloscMiejsc = 50;
            Console.WriteLine("Express: ilosc miejsc: " + iloscMiejsc + ", dlugosc trasy: " + dlugoscTrasy + ", cena biletu: " + cenaBiletu);
            base.ObliczCene();
        }
    }
    public class Podroz : IComparable<T>
    {
        private string miasto;
        private int ileDni;

        public int CompareTo()
        {

        }
        public override void City()
        {
            miasto = "Warszawa";
            ileDni = 3;
            Console.WriteLine("Miasto: " + miasto + ", liczba dni: " + ileDni);

            base.City();
        }
    }
}
