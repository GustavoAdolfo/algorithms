using System;
using Aurora.Core.Interfaces;

namespace Aurora.Core
{
    internal class Dado : IDado
    {
        protected int ValorFace { get; set; }
        public Dado()
        {
            LancarDado();
        }
        public void LancarDado()
        {
            ValorFace = new Random().Next(1,6);
        }

        public int LerValorDaFace()
        {
            return ValorFace;
        }
    }
}