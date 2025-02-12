﻿// <auto-generated />
using System;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgendamentoEntidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("agendamentoEntidades");
                });

            modelBuilder.Entity("ContatoCorretorEntidade", b =>
                {
                    b.Property<string>("Nome")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Telefone")
                        .HasColumnType("integer");

                    b.HasKey("Nome");

                    b.ToTable("ContatoCorretorEntidade");
                });

            modelBuilder.Entity("ImobiliariaEntidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link_detalhes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Preco")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contatoCorretorNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("contatoCorretorNome");

                    b.ToTable("imobiliariaEntidades");
                });

            modelBuilder.Entity("UsuarioEntidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Telefone")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("usuarioEntidades");
                });

            modelBuilder.Entity("ImobiliariaEntidade", b =>
                {
                    b.HasOne("ContatoCorretorEntidade", "contatoCorretor")
                        .WithMany()
                        .HasForeignKey("contatoCorretorNome")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contatoCorretor");
                });
#pragma warning restore 612, 618
        }
    }
}
