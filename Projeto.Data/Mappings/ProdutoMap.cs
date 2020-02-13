using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;

namespace Projeto.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        //método utilizado para realizar o mapeamento..
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela..
            builder.ToTable("Produto");

            //chave primária..
            //No EntityFramework todo campo chave primária já é criado
            //como autoincremento (identity), desde que seja um int
            builder.HasKey(p => p.IdProduto);
            
            builder.Property(p => p.IdProduto)
                .HasColumnName("IdProduto");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
        }
    }
}
