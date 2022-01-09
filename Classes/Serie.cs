using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Tipo Tipo { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int AnoCanon { get; set; }
        private int AnoCanonCorrigido { get; set; }
        private string Periodo { get; set; }
        private Audiencia Audiencia { get; set; }
        private Fase Fase { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Serie(int id, Tipo tipo, string titulo, string descricao, int anoCanon, string periodo, Audiencia audiencia, Fase fase, int ano)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Periodo = periodo;
            this.AnoCanon = anoCanon;
            this.Fase = fase;
            this.Audiencia = audiencia;
            this.Ano = ano;
            this.Excluido = false;

            if (this.Periodo == "BBY")
            {
                AnoCanonCorrigido = -this.AnoCanon;
            }
            else
            {
                AnoCanonCorrigido = this.AnoCanon;
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano que se passa dentro do Cânone: " + this.AnoCanon + " " + this.Periodo + Environment.NewLine;
            retorno += "Audiência recomendada: " + this.Audiencia + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public int retornaAnoCanon()
        {
            return this.AnoCanonCorrigido;
        }
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}