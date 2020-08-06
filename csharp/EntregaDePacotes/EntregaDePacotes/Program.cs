using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EntregaDePacotes
{
    public class Program
    {
        private const int PESOMAXIMO = 100;
        private const int MAXIMOPACOTES = 2;

        static void Main(string[] args)
        {
            if (args != null || args.Length == 0)
            {
                Console.WriteLine("Informe os pesos dos volumes em numeros inteiros separados por espaco:");
                var volumes = Console.ReadLine();
                args = volumes.Split(' ');
            }

            var retorno1 = CalcularViagensUsandoLinq(args);
            var retorno2 = CalcularViagensSemLinq(args);
        }

        public static int CalcularViagensUsandoLinq(string[] args)
        {
            List<int> pesosDosVolumes = args.Select(Int32.Parse).ToList();
            List<KeyValuePair<KeyValuePair<int, int>, int>> listaParesComSoma = new List<KeyValuePair<KeyValuePair<int, int>, int>>();

            if (pesosDosVolumes == null || !pesosDosVolumes.Any())
                return 0;

            while (pesosDosVolumes.Count > 0)
            {
                var primeiro = pesosDosVolumes.First();
                pesosDosVolumes.Remove(primeiro);
                var parComZero = new KeyValuePair<int, int>(primeiro, 0);
                var somaComZero = new KeyValuePair<KeyValuePair<int, int>, int>(parComZero, (primeiro + 0));
                listaParesComSoma.Add(somaComZero);
                foreach (var peso in pesosDosVolumes)
                {
                    var pares = new KeyValuePair<int, int>(primeiro, peso);
                    var soma = new KeyValuePair<KeyValuePair<int, int>, int>(pares, (primeiro + peso));
                    listaParesComSoma.Add(soma);
                }
            }

            listaParesComSoma = listaParesComSoma.Where(item => item.Value <= 100).ToList();

            var listaProvisoria = new List<KeyValuePair<KeyValuePair<int, int>, int>>();

            foreach (var i in args)
            {
                var chave = Convert.ToInt32(i);
                var listaChave = listaParesComSoma.Where(item => item.Key.Key == chave).ToList();
                foreach (var par in listaChave)
                {
                    if (listaProvisoria.Any(x => x.Key.Value == par.Key.Value && x.Value > par.Value))
                    {
                        if (par.Key.Value != 0)
                        {
                            listaParesComSoma.Remove(par);
                            continue;
                        }
                    }

                    var paralelos = listaParesComSoma.Where(item => !item.Key.Key.Equals(par.Key.Key) &&
                                                                    item.Key.Value.Equals(par.Key.Value) && par.Key.Value != 0).ToList();

                    if (paralelos != null && paralelos.Any())
                    {
                        if (par.Value < paralelos.Min(item => item.Value))
                        {
                            listaParesComSoma.Remove(par);
                        }
                    }
                }

                KeyValuePair<KeyValuePair<int, int>, int> q0 = (from x in listaParesComSoma
                                                                where x.Key.Key == chave && x.Value == (from y in listaParesComSoma
                                                                                                        where y.Key.Key == chave
                                                                                                        select y).Max(z => z.Value)
                                                                select x).FirstOrDefault();
                listaProvisoria.Add(q0);
            }

            listaParesComSoma = listaParesComSoma.Where(x => listaProvisoria.Contains(x)).ToList();
            listaProvisoria.Clear();
            foreach (var par in listaParesComSoma)
            {
                var valorComoChave = listaParesComSoma.Where(x => x.Key.Key == par.Key.Value).ToList();

                if (valorComoChave.Any(v => v.Value > par.Value))
                {
                    if (listaParesComSoma.Count(x => x.Key.Key == par.Key.Key) <= 1)
                    {
                        continue;
                    }

                    listaProvisoria.Add(par);
                    listaProvisoria.AddRange(
                        valorComoChave.Where(x => x.Key.Key == par.Value &&
                                                  x.Value < valorComoChave.Max(y => y.Value)));

                }
                else
                {
                    listaProvisoria.AddRange(valorComoChave);
                }
            }

            listaParesComSoma = listaParesComSoma.Except(listaProvisoria).ToList();

            return listaParesComSoma.Count;
        }

        public static int CalcularViagensSemLinq(string[] args)
        {
            var dimensao = args.Length;
            var pesosDosVolumes = new List<KeyValuePair<KeyValuePair<int, int>, int>>();
            for (var i = 0; i < dimensao; i++)
            {
                var chave = int.Parse(args[i]);
                var parComZero = new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(chave, 0), (chave + 0));
                pesosDosVolumes.Add(parComZero);
                for (var j = i + 1; j < dimensao; j++)
                {
                    var valorChave = int.Parse(args[j]);
                    var soma = chave + valorChave;
                    if (soma <= 100)
                    {
                        pesosDosVolumes.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(chave, valorChave), soma));
                    }
                } 
            }

            var listaSemiFinal = new List<KeyValuePair<KeyValuePair<int, int>, int>>();
            var listaFinal = new List<KeyValuePair<KeyValuePair<int, int>, int>>();
            var listaSubstituicaoChavesParalelas = new List<KeyValuePair<KeyValuePair<int, int>, int>>();
            var listaSubstituicaoValorComoChave = new List<KeyValuePair<KeyValuePair<int, int>, int>>();

            //Verificando qual a maior soma da chave
            foreach (var pesoDoPar in pesosDosVolumes)
            {
                var chave = pesoDoPar.Key.Key;
                var valorChave = pesoDoPar.Key.Value;
                
                //maior peso da chave
                var maiorPesoDaChave = 0;
                var listaDaChave = pesosDosVolumes.FindAll(c => c.Key.Key == chave);
                foreach (var parValor in listaDaChave)
                {
                    maiorPesoDaChave = maiorPesoDaChave < parValor.Value ? parValor.Value : maiorPesoDaChave;
                }
                var parEscolhido1 = pesosDosVolumes.FindLast(c => c.Key.Key == chave && c.Value == maiorPesoDaChave);

                //maior peso da chave como valor
                var maiorPesoDaChaveComoValor = 0;
                var listaDeChaveComoValor = pesosDosVolumes.FindAll(c => c.Key.Value == chave);
                foreach (var keyValuePair in listaDeChaveComoValor)
                {
                    maiorPesoDaChaveComoValor = maiorPesoDaChaveComoValor < keyValuePair.Value
                        ? keyValuePair.Value
                        : maiorPesoDaChaveComoValor;
                }
                var parEscolhido2 =
                    pesosDosVolumes.FindLast(c => c.Key.Value == chave && c.Value == maiorPesoDaChaveComoValor);
                
                if (!listaSemiFinal.Contains(parEscolhido1))
                {
                    listaSemiFinal.Add(parEscolhido1);
                }

                if (!listaSemiFinal.Contains(parEscolhido2))
                {
                    listaSemiFinal.Add(parEscolhido2);
                }
            }

            listaSemiFinal.RemoveAll(c => c.Value == 0);
            listaSemiFinal.Sort(new CompararLista());
            listaSemiFinal.Reverse();


            foreach (var semiFinal in listaSemiFinal)
            {
                if (!listaFinal.Exists(c => c.Key.Key == semiFinal.Key.Key || c.Key.Value == semiFinal.Key.Value
                                            || c.Key.Value == semiFinal.Key.Key || c.Key.Value == semiFinal.Key.Value))
                {
                    listaFinal.Add(semiFinal);
                }
            }

            //buscando pesos que não foram incluídos
            foreach (var peso in args)
            {
                int.TryParse(peso, out int p);
                if (p == 0)
                {
                    continue;
                }
                if (!listaFinal.Exists(c => c.Key.Key == p || c.Key.Value == p))
                {
                    var filtro = pesosDosVolumes.FindAll(c => c.Key.Key == p || c.Key.Value == p);
                    var maiorPeso = 0;
                    var adicionado = false;
                    foreach (var keyValuePair in filtro)
                    {
                        maiorPeso = maiorPeso < keyValuePair.Value ? keyValuePair.Value : maiorPeso;
                    }
                    var parEscolhido =
                        pesosDosVolumes.FindLast(c => (c.Key.Key == p || c.Key.Value == p) && c.Value == maiorPeso);
                    if (!listaFinal.Exists(c => c.Key.Key == parEscolhido.Key.Key || c.Key.Value == parEscolhido.Key.Key
                                                || c.Key.Value == parEscolhido.Key.Value ||
                                                c.Key.Value == parEscolhido.Key.Value))
                    {
                        listaFinal.Add(parEscolhido);
                        adicionado = true;
                    }
                    else
                    {
                        while (!adicionado && filtro.Count > 0)
                        {
                            filtro.Remove(parEscolhido);
                            maiorPeso = 0;
                            foreach (var keyValuePair in filtro)
                            {
                                maiorPeso = maiorPeso < keyValuePair.Value ? keyValuePair.Value : maiorPeso;
                            }
                            parEscolhido =
                                pesosDosVolumes.FindLast(c => (c.Key.Key == p || c.Key.Value == p) && c.Value == maiorPeso);
                            if (parEscolhido.Key.Value == 0)
                            {
                                listaFinal.Add(parEscolhido);
                                adicionado = true;
                                continue;
                            }

                            if (listaFinal.Exists(c => c.Key.Key == parEscolhido.Key.Key ||
                                                       c.Key.Value == parEscolhido.Key.Key
                                                       || c.Key.Value == parEscolhido.Key.Value ||
                                                       c.Key.Value == parEscolhido.Key.Value))
                            {
                                continue;
                            }

                            listaFinal.Add(parEscolhido);
                            adicionado = true;
                        }
                    }
                }
            }

            return listaFinal.Count;
        }
    }

    public class CompararLista : IComparer<KeyValuePair<KeyValuePair<int, int>, int>>
    {
        public int Compare(KeyValuePair<KeyValuePair<int, int>, int> x, KeyValuePair<KeyValuePair<int, int>, int> y)
        {
            if (x.Key.Key == 0 && y.Key.Key == 0)
            {
                if (x.Key.Value == 0 && y.Key.Value == 0)
                {
                    return 0;
                }
                if (x.Key.Value > y.Key.Value)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            if (x.Value > y.Value)
            {
                return 1;
            } else if (x.Value < y.Value)
            {
                return -1;
            }
            else
            {
                if (x.Key.Key > y.Key.Key)
                {
                    return 1;
                } else if (x.Key.Key < y.Key.Key)
                {
                    return -1;
                }
                else
                {
                    if (x.Key.Value > y.Key.Value)
                    {
                        return 1;
                    }
                    else if (x.Key.Value < y.Key.Value)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
