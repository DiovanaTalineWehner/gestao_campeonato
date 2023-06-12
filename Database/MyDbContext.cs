using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using gestao_campeonato.Models;

namespace gestao_campeonato.Database
{

    public class MyDbContext : IdentityDbContext<IdentityUser>
    {
        //context tem a propriedade equipe
        //public virtual DbSet<Equipe> Equipes {get;set;}
        public virtual DbSet<Carro> Carro {get;set;}
        public virtual DbSet<Equipe> Equipe {get;set;}
        public virtual DbSet<Usuario> Usuario {get;set;}
        public virtual DbSet<Campeonato> Campeonato {get;set;} 
        public virtual DbSet<Classificacao> Classificacao {get;set;}
        public virtual DbSet<Partida> Partida {get;set;}
        public virtual DbSet<Local_Campeonato> Local_Campeonato {get;set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            builder.Entity<Carro>().ToTable("carro");
            builder.Entity<Carro>().HasKey(p => p.id_carro);
            builder.Entity<Carro>().Property(p => p.id_carro).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Carro>().Property(p => p.nome_carro).IsRequired().HasMaxLength(45);

                        
            builder.Entity<Equipe>().ToTable("equipe");
            builder.Entity<Equipe>().Property(p => p.id_equipe).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Equipe>().HasKey(p => p.id_equipe);
          //  builder.Entity<Equipe>().Property(p => p.nome_equipe).IsRequired().HasMaxLength(45);


            builder.Entity<Equipe>()
            .HasMany(e => e.carros)
            .WithOne(e => e.equipe)
            .HasForeignKey(e => e.id_equipe)
            .HasPrincipalKey(e => e.id_equipe);

             builder.Entity<Equipe>()
            .HasMany(e => e.partidas)
            .WithOne(e => e.equipe)
            .HasForeignKey(e => e.id_equipe);
         //   .HasPrincipalKey(e => e.id_equipe);


            builder.Entity<Usuario>().ToTable("usuario");
            builder.Entity<Usuario>().Property(p => p.id_usuario). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().HasKey(p => p.id_usuario);

            builder.Entity<Classificacao>().ToTable("classificacao"); 
            builder.Entity<Classificacao>().Property(p => p.id_classificacao). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Classificacao>().HasKey(p => p.id_classificacao);

            builder.Entity<Local_Campeonato>().ToTable("local_campeonato");
            builder.Entity<Local_Campeonato>().Property(p => p.id_local_campeonato). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Local_Campeonato>().HasKey(p => p.id_local_campeonato);
            builder.Entity<Local_Campeonato>()
            .HasMany(e => e.campeonatos)
            .WithOne(e => e.local_campeonato)
            .HasForeignKey(e => e.id_local_campeonato);
          //  .HasPrincipalKey(e => e.id_local_campeonato);
        
            builder.Entity<Campeonato>().ToTable("campeonato");
            builder.Entity<Campeonato>().Property(p => p.id_campeonato). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campeonato>().HasKey(p => p.id_campeonato);
            builder.Entity<Campeonato>()
            .HasMany(e => e.partidas)
            .WithOne(e => e.campeonato)
            .HasForeignKey(e => e.id_campeonato);
           // .HasPrincipalKey(e => e.id_campeonato);

            builder.Entity<Partida>().ToTable("partida");
            builder.Entity<Partida>()
            .HasMany(e => e.classificacoes)
            .WithOne(e => e.partida)
            .HasForeignKey(e => e.id_partida);
           // .HasPrincipalKey(e => e.id_partida);
            builder.Entity<Partida>().Property(p => p.id_partida). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Partida>().HasKey(p => p.id_partida);
        }

    }
}