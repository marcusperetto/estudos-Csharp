using System;
using System.Collections.Generic;
using System.Globalization;


namespace Funcionarios
{
class Program
    {
        static void Main(string[] args)
        {
            // Lista para armazenar os funcionários
            List<Funcionario> funcionarios = [];

            // Leitura do número de funcionários
            Console.Write("Quantos funcionários serão registrados? ");
            int n = int.Parse(Console.ReadLine());

            // Cadastro dos funcionários
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nFuncionário #{i + 1}:");
                
                // Leitura do ID
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                // Verifica se o ID já existe
                while (funcionarios.Exists(f => f.Id == id))
                {
                    Console.Write("Id já existente! Tente novamente: ");
                    id = int.Parse(Console.ReadLine());
                }

                // Leitura do nome
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                // Leitura do salário
                Console.Write("Salário: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                // Adiciona o funcionário à lista
                funcionarios.Add(new Funcionario(id, nome, salario));
            }

            // Aumento de salário
            Console.Write("\nDigite o id do funcionário que terá salário aumentado: ");
            int idBusca = int.Parse(Console.ReadLine());

            // Busca o funcionário pelo ID
            Funcionario funcionario = funcionarios.Find(f => f.Id == idBusca);

            if (funcionario == null)
            {
                Console.WriteLine("Id não encontrado!");
            }
            else
            {
                Console.Write("Digite a porcentagem de aumento: ");
                double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                funcionario.AumentarSalario(porcentagem);
            }

            // Exibição da listagem atualizada
            Console.WriteLine("\nListagem atualizada dos funcionários:");
            foreach (Funcionario f in funcionarios)
            {
                Console.WriteLine(f);
            }
        }
    }
}