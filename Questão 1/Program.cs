using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    static Conta conta = new Conta(1, "Henrique");

    static void Main(string[] args)
    {
        Thread gastadoraThread = new Thread(AGastadora) { Name = "AGastadora" };
        Thread espertaThread = new Thread(AEsperta) { Name = "AEsperta" };
        Thread economicaThread = new Thread(AEconomica) { Name = "AEconomica" };
        Thread patrocinadoraThread = new Thread(APatrocinadora) { Name = "APatrocinadora" };

        gastadoraThread.Start();
        espertaThread.Start();
        economicaThread.Start();
        patrocinadoraThread.Start();
    }

    static void AGastadora()
    {
        int totalSaques = 0;
        double totalRetirado = 0;
        while (true)
        {
            conta.Sacar(10, Thread.CurrentThread.Name, ref totalSaques, ref totalRetirado);
            Thread.Sleep(3000);
        }
    }

    static void AEsperta()
    {
        int totalSaques = 0;
        double totalRetirado = 0;
        while (true)
        {
            conta.Sacar(50, Thread.CurrentThread.Name, ref totalSaques, ref totalRetirado);
            Thread.Sleep(6000);
        }
    }

    static void AEconomica()
    {
        int totalSaques = 0;
        double totalRetirado = 0;
        while (true)
        {
            conta.Sacar(5, Thread.CurrentThread.Name, ref totalSaques, ref totalRetirado);
            Thread.Sleep(12000);
        }
    }

    static void APatrocinadora()
    {
        while (true)
        {
            lock (conta)
            {
                if (conta.Saldo == 0)
                {
                    conta.Depositar(100);
                    Monitor.PulseAll(conta);
                }
            }
            Thread.Sleep(5000);
        }
    }

}