using System.ComponentModel;

namespace ApiTreino.Enums
{
    public enum EstadoCivil
    {
        [Description("Casado")]

        Casado = 1,

        [Description("Solteiro")]

        Solteiro = 2,

        [Description("Viúvo")]

        Viuvo = 3

    }
}
