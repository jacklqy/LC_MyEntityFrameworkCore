using System;
using Asp.NetCore.EFCore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Asp.NetCore.EFCore.Models
{
    public partial class LcDbContext : DbContext
    {
        ///记录控制台日志：
        ///1.  Microsoft.Extensions.Logging
        ///Microsoft.Extensions.Logging.Console 
        ///2. 定义日志工厂
        ///3. OnConfiguring配置使用日志工厂 
        /// <summary>
        /// 指定静态ILoggerFactory
        /// </summary>
        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public LcDbContext()
        {
        }

        public LcDbContext(DbContextOptions<LcDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbDebuglog> TbDebuglogs { get; set; }
        public virtual DbSet<TbError> TbErrors { get; set; }
        public virtual DbSet<TbLog> TbLogs { get; set; }
        public virtual DbSet<TbMq> TbMqs { get; set; }
        public virtual DbSet<TbTxt> TbTxts { get; set; }

        private string Connstring = null;
        public DbContext ToWriteOrRead(string conn)
        {
            Connstring = conn;
            return this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connstring);
            }

            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseLoggerFactory(MyLoggerFactory)
            //         .UseLazyLoadingProxies() //控制台日志
            //        .UseSqlServer(Conn);
            //}
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<TbDebuglog>(entity =>
            {
                entity.ToTable("tb_debuglog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.Methodname)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("methodname");

                entity.Property(e => e.Mqpath)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("mqpath");

                entity.Property(e => e.Mqpathid).HasColumnName("mqpathid");
            });

            modelBuilder.Entity<TbError>(entity =>
            {
                entity.ToTable("tb_error");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.Methodname)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("methodname");

                entity.Property(e => e.Mqpath)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("mqpath");

                entity.Property(e => e.Mqpathid).HasColumnName("mqpathid");
            });

            modelBuilder.Entity<TbLog>(entity =>
            {
                entity.ToTable("tb_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.Methodname)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("methodname");

                entity.Property(e => e.Mqpath)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("mqpath");

                entity.Property(e => e.Mqpathid).HasColumnName("mqpathid");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime");
            });

            modelBuilder.Entity<TbMq>(entity =>
            {
                entity.ToTable("tb_mq");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Mqname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mqname");
            });

            modelBuilder.Entity<TbTxt>(entity =>
            {
                entity.ToTable("tb_txt");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .HasColumnName("id");

                entity.Property(e => e.Txt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("txt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
