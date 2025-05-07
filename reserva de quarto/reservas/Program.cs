using System;
using System.Globalization;

namespace Course 
{ 
   class Program
    {
        static void Main(string[] args)
        {
            // Array para armazenar até 10 reservas (quartos 0 a 9)
            Rooms[] reserva = new Rooms[10];

            Console.WriteLine("Deseja fazer uma reserva? (s/n)");
            string resp = Console.ReadLine();

            // Loop para fazer reservas enquanto o usuário quiser
            while (resp.ToLower() == "s")
            {
                Console.WriteLine("Insira o nome da pessoa responsável pela reserva: ");
                string name = Console.ReadLine();

                Console.WriteLine("Insira o email de " + name + " para reserva: ");
                string email = Console.ReadLine();

                // Solicitando o número do quarto com validação
                Console.WriteLine(name + ", insira o número do quarto (0 a 9) que deseja reservar: ");
                if (!int.TryParse(Console.ReadLine(), out int room) || room < 0 || room > 9)
                {
                    Console.WriteLine("Erro: Número do quarto inválido. Deve ser entre 0 e 9.");
                    continue; // Volta ao início do loop
                }

                // Verificando se o quarto já está ocupado
                if (reserva[room] != null)
                {
                    Console.WriteLine("Erro: O quarto " + room + " já está ocupado.");
                    continue; // Volta ao início do loop
                }

                // Criando a reserva
                reserva[room] = new Rooms { Room = room, Name = name, Email = email };
                Console.WriteLine("Reserva feita com sucesso para o quarto " + room + "!");

                Console.WriteLine("Deseja fazer outra reserva? (s/n)");
                resp = Console.ReadLine();
            }

            // Exibindo as reservas feitas
            Console.WriteLine("\nReservas realizadas:");
            bool hasReservations = false; // Para verificar se há reservas

            for (int i = 0; i < reserva.Length; i++)
            {
                if (reserva[i] != null)
                {
                    hasReservations = true;
                    Console.WriteLine($"Quarto {reserva[i].Room}: {reserva[i].Name}, {reserva[i].Email}");
                }
            }

            // Caso não haja reservas
            if (!hasReservations)
            {
                Console.WriteLine("Nenhuma reserva foi feita.");
            }
        }
    }
}