﻿// <auto-generated />
using System;
using AppDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppDespesas.Migrations
{
    [DbContext(typeof(AppDespesasContext))]
    partial class AppDespesasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppDespesas.Models.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Despesa");
                });

            modelBuilder.Entity("AppDespesas.Models.RegistroDespesas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int?>("DespesaId");

                    b.Property<string>("Historico");

                    b.Property<int>("Pagamento");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("DespesaId");

                    b.ToTable("registrosDespesas");
                });

            modelBuilder.Entity("AppDespesas.Models.RegistroDespesas", b =>
                {
                    b.HasOne("AppDespesas.Models.Despesa", "Despesa")
                        .WithMany("Registros")
                        .HasForeignKey("DespesaId");
                });
#pragma warning restore 612, 618
        }
    }
}