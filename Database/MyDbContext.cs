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


            builder.Entity<Equipe>()
            .HasMany(e => e.carros)
            .WithOne(e => e.equipe)
            .HasForeignKey(e => e.id_equipe)
            .HasPrincipalKey(e => e.id_equipe);

             builder.Entity<Equipe>();


            builder.Entity<Usuario>().ToTable("usuario");
            builder.Entity<Usuario>().Property(p => p.id_usuario). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().HasKey(p => p.id_usuario);

            builder.Entity<Classificacao>().ToTable("classificacao"); 
            builder.Entity<Classificacao>().Property(p => p.id_classificacao). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Classificacao>().HasKey(p => p.id_classificacao);
            
            builder.Entity<Campeonato>().ToTable("campeonato");
            builder.Entity<Campeonato>().Property(p => p.id_campeonato). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campeonato>().HasKey(p => p.id_campeonato);
            builder.Entity<Campeonato>();
            
            builder.Entity<Equipe>().ToTable("equipe");
            builder.Entity<Equipe>()
            .HasMany(e => e.classificacoes)
            .WithOne(e => e.equipe)
            .HasForeignKey(e => e.id_equipe);
           // .HasPrincipalKey(e => e.id_partida);
            builder.Entity<Equipe>().Property(p => p.id_equipe). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Equipe>().HasKey(p => p.id_equipe);


          /*   builder.Entity<Equipe>().ToTable("equipe");
            builder.Entity<Equipe>()
            .HasMany(e => e.campeonatos)
            .WithOne(e => e.equipe)
            .HasForeignKey(e => e.id_equipe);
           // .HasPrincipalKey(e => e.id_partida);
            builder.Entity<Campeonato>().Property(p => p.id_equipe). IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campeonato>().HasKey(p => p.id_equipe);*/
        }

    }
}