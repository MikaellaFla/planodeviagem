using System;
using SQLite;

namespace PlanejamentoDeViagem
{
    public enum Motivo
    {
        Passeio,
        Trabalho
    }

    public enum Transporte
    {
        Avião,
        Carro,
        Ônibus,
        Outro
    }
    [Table("viagem")]
    public class Viagem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Destino { get; set; }

        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }

        [MaxLength(50)]
        public string Motivo { get; set; }

        [MaxLength(50)]
        public string Transporte { get; set; }

        [MaxLength(100)]
        public string Estadia { get; set; }

        [MaxLength(50)]
        public string CodigoPassagem { get; set; }

        [MaxLength(50)]
        public string CodigoReserva { get; set; }

        [MaxLength(100)]
        public string AeroportoIda { get; set; }

        [MaxLength(100)]
        public string AeroportoChegada { get; set; }

        [MaxLength(100)]
        public string CiaAerea { get; set; }

        [Ignore]
        public List<Itinerario> Itinerarios { get; set; }

    }
}