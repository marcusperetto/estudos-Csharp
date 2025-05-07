using System;
using System.Collections.Generic;
using System.Globalization;

namespace Funcionarios;

    // Classe Funcionario com encapsulamento
    class Funcionario
    {
        // Propriedades privadas com getters públicos
        private int _id;
        private string _nome;
        private double _salario;

        // Construtor
        public Funcionario(int id, string nome, double salario)
        {
            _id = id;
            _nome = nome;
            _salario = salario;
        }

        // Propriedades públicas para leitura
        public int Id
        {
            get { return _id; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; } // Permite alterar o nome, se necessário
        }

        public double Salario
        {
            get { return _salario; }
        }

        // Método para aumentar o salário com base em uma porcentagem
        public void AumentarSalario(double porcentagem)
        {
            if (porcentagem > 0)
            {
                _salario += _salario * (porcentagem / 100);
            }
        }

        // Sobrescreve ToString para exibir os dados do funcionário
        public override string ToString()
        {
            return $"{_id}, {_nome}, {_salario.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }