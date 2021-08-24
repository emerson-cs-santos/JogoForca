using System;
using System.Collections.Generic;

namespace Jogo_da_forca
{
    class Program
    {
        public class PalavraBase
        {
            public char Letra { get; set; }
            public string Status { get; set; }
        }

        public class Jogo
        {
            private string   Palavra         = "";
            private string   Dica            = "";
            private int      Vida            = 6;
            private string   PalavraStatus   = "";
            private string   Jogada          = "";
            private string   Aviso           = "";
            private PalavraBase[] LetrasPalavra;

            public Jogo( int Vida )
            {
                this.Vida = Vida;
                Console.WriteLine("Jogo da forca");

                while (Palavra.Length == 0)
                {
                    Console.WriteLine("Digite a Palavra que deve ser adivinhada:");
                    Palavra = Console.ReadLine();
                }

                this.LetrasPalavra = new PalavraBase[Palavra.Length];

                int PalavraIndex = 0;

                foreach (char letra in Palavra)
                {
                    LetrasPalavra[PalavraIndex] = new PalavraBase();

                    LetrasPalavra[PalavraIndex].Status = "nao";
                    LetrasPalavra[PalavraIndex].Letra = letra;

                    PalavraIndex++;
                }

                Console.WriteLine("Digite a Dica:");
                Dica = Console.ReadLine();
            }

            private void StatusExibir()
            {
                Console.Clear();

                if (Aviso.Length != 0)
                {
                    Console.WriteLine("Aviso: " + Aviso);
                    Aviso = "";
                }

                Console.WriteLine("Jogo da forca");
                Console.WriteLine("Regras: Digite apenas uma Letra! Maiúsculo e Minusculo não são diferenciados!");
                Console.WriteLine("");

                Console.WriteLine("Vida: " + Vida);
                Console.WriteLine("Dica: " + Dica);
                Console.WriteLine("Digite @ para sair.");
                Console.WriteLine("");
            }

            private void PalavrasDescobertas(bool exibir)
            {
                PalavraStatus = "";
                foreach (PalavraBase palavraAtualizar in LetrasPalavra)
                {
                    if (palavraAtualizar.Status == "sim")
                    {
                        PalavraStatus += palavraAtualizar.Letra;
                    }
                    else
                    {
                        PalavraStatus += "_";
                    }
                }

                if (exibir)
                {
                    Console.WriteLine("Palavra Status: " + PalavraStatus);
                    Console.WriteLine("");
                }
            }

            public void ExecutarJogo()
            {
                while (Vida > 0 & Palavra != PalavraStatus)
                {
                    this.StatusExibir();

                    this.PalavrasDescobertas(true);

                    Console.WriteLine("Fazer Jogada...");
                    Jogada = Console.ReadLine();

                    if (Jogada.Length != 1)
                    {
                        Aviso = "Apenas digite uma Letra!";
                    }
                    else
                    {
                        bool achou = false;

                        char JogadaChar = char.Parse(Jogada);

                        if (Jogada == "@")
                        {
                            Vida = 0;
                        }
                        else
                        {
                            foreach (PalavraBase checarPalavra in LetrasPalavra)
                            {
                                if (checarPalavra.Status == "nao")
                                {
                                    char Letra = char.ToUpper(checarPalavra.Letra);
                                    char JogadaComparar = char.ToUpper(JogadaChar);

                                    if (Letra == JogadaComparar)
                                    {
                                        checarPalavra.Status = "sim";
                                        achou = true;
                                    }
                                }
                            }

                            if (!achou)
                            {
                                Vida--;
                            }
                        }
                    }

                    this.PalavrasDescobertas(false);
                }

                if (PalavraStatus == Palavra)
                {
                    Console.WriteLine("Vencedor! Palavra é: " + Palavra);
                }

                if (Vida < 0 || Vida == 0)
                {
                    this.StatusExibir();
                    Console.WriteLine("Vida acabou, mais sorte na próxima!");
                }

                Console.WriteLine("Game Over!!");
            }

        }

        static void Main(string[] args)
        {
            Jogo Game = new Jogo(6);

            Game.ExecutarJogo();


            //Console.WriteLine("Jogo da forca");

            //string Palavra = "";
            //string Dica = "";
            //int Vida = 6;
            //string PalavraStatus = "";
            //string Jogada = "";
            //string Aviso = "";

            //while(Palavra.Length == 0)
            //{
            //    Console.WriteLine("Digite a Palavra que deve ser adivinhada:");
            //    Palavra = Console.ReadLine();
            //}

            //PalavraBase[] LetrasPalavra = new PalavraBase[Palavra.Length];

            //int tamanhoP = 0;

            //foreach (char c in Palavra)
            //{
            //    LetrasPalavra[tamanhoP] = new PalavraBase();

            //    LetrasPalavra[tamanhoP].Status = "nao";
            //    LetrasPalavra[tamanhoP].Letra = c;

            //    tamanhoP++;
            //}

            //Console.WriteLine("Digite a Dica:");
            //Dica = Console.ReadLine();

            //while (Vida > 0 & Palavra != PalavraStatus)
            //{
            //    Console.Clear();
            //    if( Aviso.Length != 0)
            //    {
            //        Console.WriteLine(Aviso);
            //        Aviso = "";
            //    }

            //    Console.WriteLine("Jogo da forca");
            //    Console.WriteLine("Regras: Digite apenas uma Letra! Maiúsculo e Minusculo não são diferenciados!");
            //    Console.WriteLine("");

            //    Console.WriteLine("Vida: " + Vida);
            //    Console.WriteLine("Dica: " + Dica);
            //    Console.WriteLine("");

            //    Console.WriteLine("Digite @ para sair.");

            //    PalavraStatus = "";
            //    foreach (PalavraBase a in LetrasPalavra)
            //    {
            //        if (a.Status == "sim")
            //        {
            //            PalavraStatus += a.Letra;
            //        }
            //        else
            //        {
            //            PalavraStatus += "_";
            //        }
            //    }

            //    //Exibir chars que foram descobertos
            //    Console.WriteLine("Palavra Status: " + PalavraStatus);
            //    Console.WriteLine("");

            //    Console.WriteLine("Fazer Jogada...");
            //    Jogada = Console.ReadLine();

            //    if (Jogada.Length != 1)
            //    {
            //        Aviso = "Apenas digite uma Letra!";
            //    }
            //    else
            //    {
            //        bool achou = false;

            //        // convertendo Jogada para char, para assim conseguir comparar com chave, cada chave é uma Letra da Palavra
            //        char JogadaChar = char.Parse(Jogada);

            //        if (Jogada == "@")
            //        {
            //            Vida = 0;
            //        }
            //        else
            //        {
            //            foreach (PalavraBase a in LetrasPalavra)
            //            {
            //                if (a.Status == "nao")
            //                {
            //                    char Letra = char.ToUpper(a.Letra);
            //                    char JogadaComparar = char.ToUpper(JogadaChar);

            //                    if (Letra == JogadaComparar)
            //                    {
            //                        a.Status = "sim";
            //                        achou = true;
            //                    }
            //                }
            //            }

            //            if (!achou)
            //            {
            //                Vida--;
            //            }
            //        }
            //    }

            //    PalavraStatus = "";
            //    foreach (PalavraBase a in LetrasPalavra)
            //    {
            //        if (a.Status == "sim")
            //        {
            //            PalavraStatus += a.Letra;
            //        }
            //        else
            //        {
            //            PalavraStatus += "_";
            //        }
            //    }
            //}

            //// Se todos foram descobertos vencedor
            //if (PalavraStatus == Palavra)
            //{
            //    Console.WriteLine("Vencedor! Palavra é: " + Palavra);
            //}

            //// Se Vida = 0, perdeu
            //if (Vida < 0 || Vida == 0)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Jogo da forca");
            //    Console.WriteLine("Vida: " + Vida);
            //    Console.WriteLine("Dica: " + Dica);
            //    Console.WriteLine("Palavra Status: " + PalavraStatus);

            //    Console.WriteLine("");
            //    Console.WriteLine("Vida acabou, mais sorte na próxima!");
            //}

            //Console.WriteLine("Game Over!!");
        }
    }
}
