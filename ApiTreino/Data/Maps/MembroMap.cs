using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiTreino.Models;




namespace ApiTreino.Data.Maps




{
    public class MembroMap : IEntityTypeConfiguration<MembroModel>
    { 

    
        public void Configure(EntityTypeBuilder<MembroModel> builder)
        {
            builder.HasKey(x => x.nome);
            builder.Property(x => x.sexo);
            builder.Property(x => x.cpf).HasMaxLength(11);
            builder.Property(x=> x.idade).HasMaxLength(3);
            builder.Property(x=> x.casado);
            builder.Property(x => x.situacaomembresia);
            builder.Property(x => x.dataRecepcao);
            builder.Property(x => x.modorecepcao);



        }

    }
}

