using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            string? numeroInput = Console.ReadLine();
            if (!int.TryParse(numeroInput, out int numero))
            {
                Console.WriteLine("Número da conta inválido. Encerrando.");
                return;
            }

            Console.Write("Entre o titular da conta: ");
            string? titular = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(titular))
            {
                Console.WriteLine("Titular inválido. Encerrando.");
                return;
            }

            Console.Write("Haverá depósito inicial? (s/n)? ");
            string? respInput = Console.ReadLine();
            char resp = respInput != null && respInput.Length > 0 ? respInput[0] : 'n';

            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre o valor de depósito inicial: ");
                string? depositoInput = Console.ReadLine();
                if (!double.TryParse(depositoInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double depositoInicial))
                {
                    Console.WriteLine("Valor de depósito inválido. Encerrando.");
                    return;
                }
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.WriteLine("Entre um valor para depósito: ");
            double quantiaDep = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(quantiaDep);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.WriteLine("Entre um valor para saque: ");
            double quantiaSaq = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Saque(quantiaSaq);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);
            
        }
    }
}