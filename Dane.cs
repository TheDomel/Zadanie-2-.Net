using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2.Net
{
    public class Dane : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string pierwsza = "";
        public string druga = "";
        public string io = "0";
        public string stringOperatora = "";
        public string poprzedniOperator = "";
        public string działanie = "";
        public string wynik = "";
        public string równaSię = "";


        public bool fOperatora = false;
        public bool fBufor = false;
        public bool fWynik = false;
        public bool fLiczby = false;
        public bool fPrzecinek = false;
        public bool fZnak = false;
        public bool fDziałanie = false;

        public string Historia
        {
            get
            {
                return $"{Pierwsza} {StringOperatora} {Druga} {równaSię}";
            }
        }

        public string Io
        {
            get { return io; }
            set
            {
                io = value;
                OnPropetyChanged();
            }
        }

        public string StringOperatora
        {
            get { return stringOperatora; }
            set
            {
                stringOperatora = value;
                OnPropetyChanged();
            }
        }
        public string PoprzedniOperator
        {
            get { return poprzedniOperator; }
            set
            {
                poprzedniOperator = value;
                OnPropetyChanged();
            }
        }

        public string Pierwsza
        {
            get { return pierwsza; }
            set
            {
                pierwsza = value;
                OnPropetyChanged();
                OnPropetyChanged("Historia");
            }
        }

        public string Druga
        {
            get { return druga; }
            set
            {
                druga = value;
                OnPropetyChanged();
                OnPropetyChanged("Historia");
            }
        }

        public string Działanie
        {
            get { return działanie; }
            set
            {
                działanie = value;
                OnPropetyChanged();
                OnPropetyChanged("Historia");
            }
        }

        public string Wynik
        {
            get { return wynik; }
            set
            {
                wynik = value;
                OnPropetyChanged();
                OnPropetyChanged("Historia");
            }
        }

        public string RównaSię
        {
            get { return równaSię; }
            set
            {
                równaSię = value;
                OnPropetyChanged();
                OnPropetyChanged("Historia");
            }
        }

        public void Litery(string litera)
        {
            if (fWynik == false)
            {
                if (fLiczby == false)
                {
                    if (Io == "0")
                        Io = "";
                    Io += litera;

                }
                else
                {
                    Io = "";
                    Io += litera;
                    fLiczby = false;
                }
            }
            else
            {
                Resetuj();
                if (Io == "0")
                    Io = "";
                Io += litera;
            }


        }
        public void Resetuj()
        {
            fOperatora = false;
            fBufor = false;
            fWynik = false;
            fLiczby = false;
            fPrzecinek = false;
            fZnak = false;
            fDziałanie = false;


            Io = "0";
            StringOperatora = "";
            poprzedniOperator = "";
            Pierwsza = "";
            Druga = "";
            działanie = "";
            Wynik = "";
            RównaSię = "";

        }


        public void Operatory(string pobierzOerator)
        {
            StringOperatora = pobierzOerator;
            fLiczby = true;
            fPrzecinek = false;
            if (fOperatora == false)
            {
                Pierwsza = Io;
                fOperatora = true;
            }
            else
            {
                if (fWynik == false)
                {
                    double wynik;
                    if (PoprzedniOperator == "+")
                    {
                        Druga = Io;
                        wynik = Convert.ToDouble(Pierwsza) + Convert.ToDouble(Druga);
                        Io = Convert.ToString(wynik);
                        Pierwsza = Io;
                        Druga = "";
                    }
                    if (PoprzedniOperator == "-")
                    {
                        Druga = Io;
                        wynik = Convert.ToDouble(Pierwsza) - Convert.ToDouble(Druga);
                        Io = Convert.ToString(wynik);
                        Pierwsza = Io;
                        Druga = "";
                    }
                    if (PoprzedniOperator == "×")
                    {
                        Druga = Io;
                        wynik = Convert.ToDouble(Pierwsza) * Convert.ToDouble(Druga);
                        Io = Convert.ToString(wynik);
                        Pierwsza = Io;
                        Druga = "";
                    }
                    if (PoprzedniOperator == "÷")
                    {
                        Druga = Io;
                        wynik = Convert.ToDouble(Pierwsza) / Convert.ToDouble(Druga);
                        Io = Convert.ToString(wynik);
                        Pierwsza = Io;
                        Druga = "";
                    }
                }
                else
                {
                    fWynik = false;
                    Pierwsza = Io;
                    Druga = "";
                    RównaSię = "";
                }

            }
            PoprzedniOperator = StringOperatora;
        }

        public void Dopisz(string przecinek)
        {
            if (fWynik == false)
            {
                if (fPrzecinek == false)
                {
                    Io += przecinek;
                    fPrzecinek = true;
                }

            }
            else
            {
                Resetuj();
                Io += przecinek;
                fPrzecinek = true;
            }
        }

        public void działaniaJednoargumentowe(string pobierzDziałanie)
        {
            Druga = "";
            PoprzedniOperator = "";
            RównaSię = "";
            StringOperatora = "";
            Działanie = pobierzDziałanie;
            fDziałanie = true;
            Pierwsza = io;
            Wykonaj();
        }

        public void Wykonaj()
        {
            double wynik;
            if (StringOperatora == "+")
            {
                Druga = Io;
                wynik = Convert.ToDouble(Pierwsza) + Convert.ToDouble(Druga);
                Io = Convert.ToString(wynik);
                fWynik = true;
                RównaSię = "=";
            }
            if (StringOperatora == "-")
            {
                Druga = Io;
                wynik = Convert.ToDouble(Pierwsza) - Convert.ToDouble(Druga);
                Io = Convert.ToString(wynik);
                fWynik = true;
                RównaSię = "=";
            }
            if (StringOperatora == "×")
            {
                Druga = Io;
                wynik = Convert.ToDouble(Pierwsza) * Convert.ToDouble(Druga);
                Io = Convert.ToString(wynik);
                fWynik = true;
                RównaSię = "=";
            }
            if (StringOperatora == "÷")
            {
                Druga = Io;
                wynik = Convert.ToDouble(Pierwsza) / Convert.ToDouble(Druga);
                Io = Convert.ToString(wynik);
                fWynik = true;
                RównaSię = "=";
            }
            if (Działanie == "1/x")
            {
                wynik = 1 / Convert.ToDouble(Pierwsza);
                Io = Convert.ToString(wynik);
                Pierwsza = "1/(" + Pierwsza + ")";

            }
            if (Działanie == "x²")
            {
                wynik = Convert.ToDouble(Pierwsza) * Convert.ToDouble(Pierwsza);
                Io = Convert.ToString(wynik);
                Pierwsza = "sqrt(" + Pierwsza + ")";
            }
            if (Działanie == "√x")
            {
                wynik = Math.Sqrt(Convert.ToDouble(Pierwsza));
                Io = Convert.ToString(wynik);
                Pierwsza = "√(" + Pierwsza + ")";
            }
        }

        public void ZmieńZnak()
        {
            if (Io != "0")
                if (fZnak == false)
                {
                    Io = "-" + Io;
                    fZnak = true;
                }
                else
                {
                    Io = Io.Substring(1);
                    fZnak = false;
                }
        }

        public void DziałanieProcentowe()
        {
            if (Pierwsza == "" || Pierwsza == "0")
            {
                Pierwsza = "0";
            }
            else
            {
                Druga = Io;
                double wynik;
                double liczbaDruga;

                liczbaDruga = (Convert.ToDouble(Druga) * Convert.ToDouble(Pierwsza)) / 100;
                if (poprzedniOperator == "+")
                {
                    wynik = Convert.ToDouble(Pierwsza) + liczbaDruga;
                    Druga = Convert.ToString(liczbaDruga);
                    Io = Convert.ToString(wynik);
                    fWynik = true;
                }

            }
        }

        public void PrzełączOperator(string operatorPrzełącz)
        {
            if (fLiczby == true)
            {
                StringOperatora = operatorPrzełącz;
                fOperatora = false;
            }

        }

        public void Cofnij()
        {
            Io = Io.Substring(0, Io.Length - 1);
            if (Io == "")
            {
                Io = "0";
            }
        }

    }
}
