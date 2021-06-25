using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Veiculo
    {
        public Veiculo(string marca, string modelo, string quilometragem, DateTime ano)
        {
            Marca = marca;
            Modelo = modelo;
            Quilometragem = quilometragem;
            Ano= ano;
        }

        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Quilometragem { get; private set; }
        public DateTime Ano { get; private set; }


        public void AtualizarVeiculo(string marca, string modelo, string quilometragem, DateTime ano)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Quilometragem = quilometragem;
            this.Ano = ano;
        }
    }
}
