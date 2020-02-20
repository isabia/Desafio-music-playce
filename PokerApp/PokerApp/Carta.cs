using System;
using System.Collections.Generic;
using System.Text;

namespace PokerApp
{
    class Carta
    {
       
        public enum Naipe
        {
            E = 1, O, C, P
        }

        public enum Valor
        {
            DOIS = 2, TRES, QUATRO, CINCO, SEIS, SETE, OITO,
            NOVE, DEZ, VALETE, DAMA, REI, AIS
        }

       


        public Naipe NaipeUsado { get; set; }
        public Valor ValorUsado { get; set; }
    }
}
