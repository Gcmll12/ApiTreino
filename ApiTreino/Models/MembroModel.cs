using ApiTreino.Enums;
using Microsoft.VisualBasic;

namespace ApiTreino.Models
{
    public class MembroModel
    {
        public required string nome { get; set; }

        public string? sexo { get; set; }

        public string? cpf { get; set; }

        public int? idade { get; set; }

        public EstadoCivil? casado { get; set; }

        public SitiuacaoMembresia? situacaomembresia { get; set; }

        public DateTime? dataRecepcao {get; set;}

        public ModoRecepcao? modorecepcao { get; set; }



    }
}
