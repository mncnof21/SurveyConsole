using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class survdbContext : DbContext
    {
        public survdbContext()
        {
        }

        public survdbContext(DbContextOptions<survdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Magent> Magents { get; set; }
        public virtual DbSet<MasterBranch> MasterBranches { get; set; }
        public virtual DbSet<MasterDocChecklist> MasterDocChecklists { get; set; }
        public virtual DbSet<MasterForm> MasterForms { get; set; }
        public virtual DbSet<MasterFormDetail> MasterFormDetails { get; set; }
        public virtual DbSet<MasterKelengkapan> MasterKelengkapans { get; set; }
        public virtual DbSet<MasterPertanyaan> MasterPertanyaans { get; set; }
        public virtual DbSet<MasterPertanyaanQuisioner> MasterPertanyaanQuisioners { get; set; }
        public virtual DbSet<MasterPointCheckIdnumber> MasterPointCheckIdnumbers { get; set; }
        public virtual DbSet<MasterPointCheckPhysical> MasterPointCheckPhysicals { get; set; }
        public virtual DbSet<MasterQuisioner> MasterQuisioners { get; set; }
        public virtual DbSet<MasterZipCode> MasterZipCodes { get; set; }
        public virtual DbSet<SurveyresultClient> SurveyresultClients { get; set; }
        public virtual DbSet<SurveyresultQuisioner> SurveyresultQuisioners { get; set; }
        public virtual DbSet<SurveyresultUpload> SurveyresultUploads { get; set; }
        public virtual DbSet<TapplCust> TapplCusts { get; set; }
        public virtual DbSet<Tasklist> Tasklists { get; set; }
        public virtual DbSet<TvalidationCollateral> TvalidationCollaterals { get; set; }
        public virtual DbSet<TvalidationCollateralIdnumber> TvalidationCollateralIdnumbers { get; set; }
        public virtual DbSet<TvalidationCollateralPhysical> TvalidationCollateralPhysicals { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAuth> UserAuths { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<VwMasterFormUpload> VwMasterFormUploads { get; set; }
        public virtual DbSet<VwQuisioner> VwQuisioners { get; set; }
        public virtual DbSet<VwResultQuisioner> VwResultQuisioners { get; set; }
        public virtual DbSet<VwResultUpload> VwResultUploads { get; set; }
        public virtual DbSet<VwUser> VwUsers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Indonesian_Indonesia.1252");

            modelBuilder.Entity<Magent>(entity =>
            {
                entity.ToTable("MAGENT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.AgentId)
                    .HasMaxLength(255)
                    .HasColumnName("AGENT_ID");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(255)
                    .HasColumnName("AGENT_NAME");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREATED_DATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FilePhoto)
                    .HasMaxLength(255)
                    .HasColumnName("FILE_PHOTO");

                entity.Property(e => e.HpNo)
                    .HasMaxLength(255)
                    .HasColumnName("HP_NO");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Nik)
                    .HasMaxLength(255)
                    .HasColumnName("NIK");

                entity.Property(e => e.NikAddress)
                    .HasMaxLength(255)
                    .HasColumnName("NIK_ADDRESS");

                entity.Property(e => e.NikName)
                    .HasMaxLength(255)
                    .HasColumnName("NIK_NAME");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<MasterBranch>(entity =>
            {
                entity.ToTable("MASTER_BRANCH");

                entity.HasIndex(e => e.CCode, "UNIQ_BRANCH_CODE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("C_CODE");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("C_NAME");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<MasterDocChecklist>(entity =>
            {
                entity.ToTable("MASTER_DOC_CHECKLIST");

                entity.HasIndex(e => e.Credate, "IDX_DOC_CHECKLIST")
                    .HasSortOrder(new[] { SortOrder.Descending });

                entity.HasIndex(e => e.Kode, "UNIQ_DOC_CHECKLIST_KODE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Kode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("KODE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<MasterForm>(entity =>
            {
                entity.ToTable("MASTER_FORM");

                entity.HasIndex(e => e.Credate, "IDX_MASTER_FORM")
                    .HasSortOrder(new[] { SortOrder.Descending });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .HasColumnName("DESC");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<MasterFormDetail>(entity =>
            {
                entity.ToTable("MASTER_FORM_DETAIL");

                entity.HasIndex(e => e.Credate, "IDX_FORM_KELENGKAPAN")
                    .HasSortOrder(new[] { SortOrder.Descending });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Count)
                    .HasColumnName("COUNT")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idform).HasColumnName("IDFORM");

                entity.Property(e => e.Idkelengkapan).HasColumnName("IDKELENGKAPAN");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdformNavigation)
                    .WithMany(p => p.MasterFormDetails)
                    .HasForeignKey(d => d.Idform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FORMGROUP_MASTERFORM");

                entity.HasOne(d => d.IdkelengkapanNavigation)
                    .WithMany(p => p.MasterFormDetails)
                    .HasForeignKey(d => d.Idkelengkapan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FORMGROUP_MASTERKELENGKAPAN");
            });

            modelBuilder.Entity<MasterKelengkapan>(entity =>
            {
                entity.ToTable("MASTER_KELENGKAPAN");

                entity.HasIndex(e => e.Credate, "IDX_KELENGKAPAN")
                    .HasSortOrder(new[] { SortOrder.Descending });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("DESC");

                entity.Property(e => e.Formname)
                    .HasMaxLength(255)
                    .HasColumnName("FORMNAME");

                entity.Property(e => e.IdDocChecklist).HasColumnName("ID_DOC_CHECKLIST");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Position).HasColumnName("POSITION");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.IdDocChecklistNavigation)
                    .WithMany(p => p.MasterKelengkapans)
                    .HasForeignKey(d => d.IdDocChecklist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOC_CHECKLIST");
            });

            modelBuilder.Entity<MasterPertanyaan>(entity =>
            {
                entity.ToTable("MASTER_PERTANYAAN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasColumnName("ISACTIVE");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Pertanyaan)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .HasColumnName("PERTANYAAN");

                entity.Property(e => e.Position).HasColumnName("POSITION");

                entity.Property(e => e.QuestionTypeFlag).HasColumnName("QUESTION_TYPE_FLAG");
            });

            modelBuilder.Entity<MasterPertanyaanQuisioner>(entity =>
            {
                entity.ToTable("MASTER_PERTANYAAN_QUISIONER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Descs)
                    .HasMaxLength(500)
                    .HasColumnName("DESCS");

                entity.Property(e => e.Idpertanyaan).HasColumnName("IDPERTANYAAN");

                entity.Property(e => e.Idquisioner).HasColumnName("IDQUISIONER");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasColumnName("ISACTIVE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdpertanyaanNavigation)
                    .WithMany(p => p.MasterPertanyaanQuisioners)
                    .HasForeignKey(d => d.Idpertanyaan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERTANYAAN");

                entity.HasOne(d => d.IdquisionerNavigation)
                    .WithMany(p => p.MasterPertanyaanQuisioners)
                    .HasForeignKey(d => d.Idquisioner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUISIONER");
            });

            modelBuilder.Entity<MasterPointCheckIdnumber>(entity =>
            {
                entity.ToTable("MASTER_POINT_CHECK_IDNUMBER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(100)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.PointCheckIdnumberDesc)
                    .HasMaxLength(255)
                    .HasColumnName("POINT_CHECK_IDNUMBER_DESC");
            });

            modelBuilder.Entity<MasterPointCheckPhysical>(entity =>
            {
                entity.ToTable("MASTER_POINT_CHECK_PHYSICAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryPoint)
                    .HasMaxLength(255)
                    .HasColumnName("CATEGORY_POINT");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(100)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.PointCheckPhysicalDesc).HasColumnName("POINT_CHECK_PHYSICAL_DESC");

                entity.Property(e => e.PointCheckPhysicalNote).HasColumnName("POINT_CHECK_PHYSICAL_NOTE");

                entity.Property(e => e.PointNumber).HasColumnName("POINT_NUMBER");
            });

            modelBuilder.Entity<MasterQuisioner>(entity =>
            {
                entity.ToTable("MASTER_QUISIONER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("DESC");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasColumnName("ISACTIVE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<MasterZipCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MASTER_ZIP_CODE");

                entity.Property(e => e.Areatagih)
                    .HasMaxLength(255)
                    .HasColumnName("AREATAGIH");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Kecamatan)
                    .HasMaxLength(255)
                    .HasColumnName("KECAMATAN");

                entity.Property(e => e.Kelurahan)
                    .HasMaxLength(255)
                    .HasColumnName("KELURAHAN");

                entity.Property(e => e.Kodepos)
                    .HasMaxLength(255)
                    .HasColumnName("KODEPOS");

                entity.Property(e => e.Kota)
                    .HasMaxLength(255)
                    .HasColumnName("KOTA");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.SysZipid).HasColumnName("SYS_ZIPID");
            });

            modelBuilder.Entity<SurveyresultClient>(entity =>
            {
                entity.ToTable("SURVEYRESULT_CLIENT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(5000)
                    .HasColumnName("ALAMAT");

                entity.Property(e => e.Ao)
                    .HasMaxLength(255)
                    .HasColumnName("AO");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Faxno)
                    .HasMaxLength(25)
                    .HasColumnName("FAXNO");

                entity.Property(e => e.GelarBelakang)
                    .HasMaxLength(500)
                    .HasColumnName("GELAR_BELAKANG");

                entity.Property(e => e.GelarDepan)
                    .HasMaxLength(500)
                    .HasColumnName("GELAR_DEPAN");

                entity.Property(e => e.Hpno)
                    .HasMaxLength(25)
                    .HasColumnName("HPNO");

                entity.Property(e => e.Kecamatan)
                    .HasMaxLength(255)
                    .HasColumnName("KECAMATAN");

                entity.Property(e => e.Kelurahan)
                    .HasMaxLength(255)
                    .HasColumnName("KELURAHAN");

                entity.Property(e => e.Kodepos)
                    .HasMaxLength(255)
                    .HasColumnName("KODEPOS");

                entity.Property(e => e.KtpExpireFrom)
                    .HasColumnType("date")
                    .HasColumnName("KTP_EXPIRE_FROM");

                entity.Property(e => e.KtpExpireTo)
                    .HasColumnType("date")
                    .HasColumnName("KTP_EXPIRE_TO");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("LAT");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("LNG");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nama)
                    .HasMaxLength(500)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NamaKtp)
                    .HasMaxLength(500)
                    .HasColumnName("NAMA_KTP");

                entity.Property(e => e.Namaibu)
                    .HasMaxLength(500)
                    .HasColumnName("NAMAIBU");

                entity.Property(e => e.NoKtp)
                    .HasMaxLength(255)
                    .HasColumnName("NO_KTP");

                entity.Property(e => e.Nopol)
                    .HasMaxLength(255)
                    .HasColumnName("NOPOL");

                entity.Property(e => e.Rt)
                    .HasMaxLength(5)
                    .HasColumnName("RT");

                entity.Property(e => e.Rw)
                    .HasMaxLength(5)
                    .HasColumnName("RW");

                entity.Property(e => e.Taskid).HasColumnName("TASKID");

                entity.Property(e => e.Telpno)
                    .HasMaxLength(25)
                    .HasColumnName("TELPNO");

                entity.Property(e => e.Tempatlahir)
                    .HasMaxLength(500)
                    .HasColumnName("TEMPATLAHIR");

                entity.Property(e => e.Tgllahir)
                    .HasColumnType("date")
                    .HasColumnName("TGLLAHIR");
            });

            modelBuilder.Entity<SurveyresultQuisioner>(entity =>
            {
                entity.ToTable("SURVEYRESULT_QUISIONER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idquisioner).HasColumnName("IDQUISIONER");

                entity.Property(e => e.Idquisionerdetail).HasColumnName("IDQUISIONERDETAIL");

                entity.Property(e => e.Idsurveyclient).HasColumnName("IDSURVEYCLIENT");

                entity.Property(e => e.Jawaban)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("JAWABAN");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdquisionerdetailNavigation)
                    .WithMany(p => p.SurveyresultQuisioners)
                    .HasForeignKey(d => d.Idquisionerdetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERTANYAAN");

                entity.HasOne(d => d.IdsurveyclientNavigation)
                    .WithMany(p => p.SurveyresultQuisioners)
                    .HasForeignKey(d => d.Idsurveyclient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEYRESULT_CLIENT");
            });

            modelBuilder.Entity<SurveyresultUpload>(entity =>
            {
                entity.ToTable("SURVEYRESULT_UPLOAD");

                entity.HasIndex(e => e.Credate, "IDX_SURVEYRESULT")
                    .HasSortOrder(new[] { SortOrder.Descending });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Idformdetail).HasColumnName("IDFORMDETAIL");

                entity.Property(e => e.Idresultclient).HasColumnName("IDRESULTCLIENT");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .HasColumnName("PATH");

                entity.HasOne(d => d.IdformdetailNavigation)
                    .WithMany(p => p.SurveyresultUploads)
                    .HasForeignKey(d => d.Idformdetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SURVEYRESULT_FORMDETAIL");

                entity.HasOne(d => d.IdresultclientNavigation)
                    .WithMany(p => p.SurveyresultUploads)
                    .HasForeignKey(d => d.Idresultclient)
                    .HasConstraintName("FK_SURVEY_CLIENT");
            });

            modelBuilder.Entity<TapplCust>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TAPPL_CUST");

                entity.Property(e => e.Address).HasColumnName("ADDRESS");

                entity.Property(e => e.ApplId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.ApplStatus)
                    .HasMaxLength(50)
                    .HasColumnName("APPL_STATUS");

                entity.Property(e => e.ApplType)
                    .HasMaxLength(50)
                    .HasColumnName("APPL_TYPE");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(50)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CustDesc1)
                    .HasMaxLength(50)
                    .HasColumnName("CUST_DESC1");

                entity.Property(e => e.CustDesc2).HasColumnName("CUST_DESC2");

                entity.Property(e => e.CustName)
                    .HasMaxLength(250)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.CustNik)
                    .HasMaxLength(50)
                    .HasColumnName("CUST_NIK");

                entity.Property(e => e.JumUnit).HasColumnName("JUM_UNIT");

                entity.Property(e => e.Latitude).HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");

                entity.Property(e => e.Notes).HasColumnName("NOTES");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE");

                entity.Property(e => e.ProductFacility)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCT_FACILITY");

                entity.Property(e => e.PromiseDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("PROMISE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.YearUnit).HasColumnName("YEAR_UNIT");
            });

            modelBuilder.Entity<Tasklist>(entity =>
            {
                entity.ToTable("TASKLIST");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(5000)
                    .HasColumnName("ALAMAT");

                entity.Property(e => e.Ccode)
                    .HasMaxLength(5)
                    .HasColumnName("CCODE");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsPush).HasColumnName("IS_PUSH");

                entity.Property(e => e.ItrackApplid)
                    .HasMaxLength(500)
                    .HasColumnName("ITRACK_APPLID");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nama)
                    .HasMaxLength(500)
                    .HasColumnName("NAMA");

                entity.Property(e => e.Nik)
                    .HasMaxLength(255)
                    .HasColumnName("NIK");

                entity.Property(e => e.Nopol)
                    .HasMaxLength(255)
                    .HasColumnName("NOPOL");

                entity.Property(e => e.Notelp)
                    .HasMaxLength(100)
                    .HasColumnName("NOTELP");

                entity.Property(e => e.SiapApplid)
                    .HasMaxLength(2500)
                    .HasColumnName("SIAP_APPLID");
            });

            modelBuilder.Entity<TvalidationCollateral>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ApplId)
                    .HasMaxLength(100)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.CustName)
                    .HasMaxLength(255)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.Modby)
                    .HasMaxLength(100)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Nopol)
                    .HasMaxLength(50)
                    .HasColumnName("NOPOL");

                entity.Property(e => e.ReasonResult).HasColumnName("REASON_RESULT");

                entity.Property(e => e.RecommendationResult).HasColumnName("RECOMMENDATION_RESULT");

                entity.Property(e => e.ResiNumber)
                    .HasMaxLength(100)
                    .HasColumnName("RESI_NUMBER");
            });

            modelBuilder.Entity<TvalidationCollateralIdnumber>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL_IDNUMBER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CheckValue)
                    .HasMaxLength(255)
                    .HasColumnName("CHECK_VALUE");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IdcheckIdnumber)
                    .HasMaxLength(255)
                    .HasColumnName("IDCHECK_IDNUMBER");

                entity.Property(e => e.IdvalidationCollateral).HasColumnName("IDVALIDATION_COLLATERAL");

                entity.Property(e => e.IsValid).HasColumnName("IS_VALID");

                entity.Property(e => e.Modby)
                    .HasMaxLength(100)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("MODDATE");
            });

            modelBuilder.Entity<TvalidationCollateralPhysical>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL_PHYSICAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IdcheckPhysical)
                    .HasMaxLength(255)
                    .HasColumnName("IDCHECK_PHYSICAL");

                entity.Property(e => e.IdvalidationCollateral).HasColumnName("IDVALIDATION_COLLATERAL");

                entity.Property(e => e.IsValid).HasColumnName("IS_VALID");

                entity.Property(e => e.Modby)
                    .HasMaxLength(100)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Reason).HasColumnName("REASON");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.HasIndex(e => e.Nik, "UNIQ_USER")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Nama)
                    .HasMaxLength(255)
                    .HasColumnName("NAMA");

                entity.Property(e => e.Nik)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("NIK");
            });

            modelBuilder.Entity<UserAuth>(entity =>
            {
                entity.ToTable("USER_AUTH");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Attempt)
                    .HasColumnName("ATTEMPT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Authtoken)
                    .HasMaxLength(5000)
                    .HasColumnName("AUTHTOKEN");

                entity.Property(e => e.AuthtokenExpire)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("AUTHTOKEN_EXPIRE");

                entity.Property(e => e.Blockuntil)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("BLOCKUNTIL");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Firebasetoken)
                    .HasMaxLength(5000)
                    .HasColumnName("FIREBASETOKEN");

                entity.Property(e => e.Forgottoken)
                    .HasMaxLength(5000)
                    .HasColumnName("FORGOTTOKEN");

                entity.Property(e => e.ForgottokenExpire)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("FORGOTTOKEN_EXPIRE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Lastlogin)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("LASTLOGIN");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Nik)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("NIK");

                entity.Property(e => e.Osextid)
                    .HasMaxLength(255)
                    .HasColumnName("OSEXTID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .HasColumnName("PASSWORD");

                entity.HasOne(d => d.NikNavigation)
                    .WithMany(p => p.UserAuths)
                    .HasPrincipalKey(p => p.Nik)
                    .HasForeignKey(d => d.Nik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_AUTH");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("USER_ROLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("C_CODE");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("GROUP_CODE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.CCodeNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasPrincipalKey(p => p.CCode)
                    .HasForeignKey(d => d.CCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_BRANCH");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasPrincipalKey(p => p.Nik)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ROLE");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.ToTable("USER_TASK");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(255)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(255)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.SurveyorNik)
                    .HasMaxLength(500)
                    .HasColumnName("SURVEYOR_NIK");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.HasOne(d => d.SurveyorNikNavigation)
                    .WithMany(p => p.UserTasks)
                    .HasPrincipalKey(p => p.Nik)
                    .HasForeignKey(d => d.SurveyorNik)
                    .HasConstraintName("FK_USER");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TASK");
            });

            modelBuilder.Entity<VwMasterFormUpload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VW_MASTER_FORM_UPLOAD");

                entity.Property(e => e.Count).HasColumnName("COUNT");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.Formname)
                    .HasMaxLength(255)
                    .HasColumnName("FORMNAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idform).HasColumnName("IDFORM");

                entity.Property(e => e.Kelengkapan)
                    .HasMaxLength(255)
                    .HasColumnName("KELENGKAPAN");

                entity.Property(e => e.Kode)
                    .HasMaxLength(255)
                    .HasColumnName("KODE");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Position).HasColumnName("POSITION");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<VwQuisioner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VW_QUISIONER");

                entity.Property(e => e.Creby)
                    .HasMaxLength(255)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpertanyaan).HasColumnName("IDPERTANYAAN");

                entity.Property(e => e.Idquisioner).HasColumnName("IDQUISIONER");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Modby)
                    .HasMaxLength(255)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Pertanyaan)
                    .HasMaxLength(1500)
                    .HasColumnName("PERTANYAAN");

                entity.Property(e => e.Position).HasColumnName("POSITION");

                entity.Property(e => e.QuestionTypeFlag).HasColumnName("QUESTION_TYPE_FLAG");
            });

            modelBuilder.Entity<VwResultQuisioner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VW_RESULT_QUISIONER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idresultclient).HasColumnName("IDRESULTCLIENT");

                entity.Property(e => e.Jawaban)
                    .HasMaxLength(1000)
                    .HasColumnName("JAWABAN");

                entity.Property(e => e.Nama)
                    .HasMaxLength(500)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NoKtp)
                    .HasMaxLength(255)
                    .HasColumnName("NO_KTP");

                entity.Property(e => e.Pertanyaan)
                    .HasMaxLength(1500)
                    .HasColumnName("PERTANYAAN");

                entity.Property(e => e.QuestionTypeFlag).HasColumnName("QUESTION_TYPE_FLAG");
            });

            modelBuilder.Entity<VwResultUpload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VW_RESULT_UPLOAD");

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .HasColumnName("DESC");

                entity.Property(e => e.Filename)
                    .HasMaxLength(2500)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Formname)
                    .HasMaxLength(255)
                    .HasColumnName("FORMNAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idresultclient).HasColumnName("IDRESULTCLIENT");

                entity.Property(e => e.Kode)
                    .HasMaxLength(255)
                    .HasColumnName("KODE");

                entity.Property(e => e.Nama)
                    .HasMaxLength(500)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NoKtp)
                    .HasMaxLength(255)
                    .HasColumnName("NO_KTP");

                entity.Property(e => e.Path)
                    .HasMaxLength(2500)
                    .HasColumnName("PATH");
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VW_USER");

                entity.Property(e => e.Attempt).HasColumnName("ATTEMPT");

                entity.Property(e => e.Authtoken)
                    .HasMaxLength(5000)
                    .HasColumnName("AUTHTOKEN");

                entity.Property(e => e.AuthtokenExpire)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("AUTHTOKEN_EXPIRE");

                entity.Property(e => e.Blockuntil)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("BLOCKUNTIL");

                entity.Property(e => e.CCode)
                    .HasMaxLength(255)
                    .HasColumnName("C_CODE");

                entity.Property(e => e.Firebasetoken)
                    .HasMaxLength(5000)
                    .HasColumnName("FIREBASETOKEN");

                entity.Property(e => e.Forgottoken)
                    .HasMaxLength(5000)
                    .HasColumnName("FORGOTTOKEN");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(255)
                    .HasColumnName("GROUP_CODE");

                entity.Property(e => e.Lastlogin)
                    .HasColumnType("timestamp(6) with time zone")
                    .HasColumnName("LASTLOGIN");

                entity.Property(e => e.Nama)
                    .HasMaxLength(255)
                    .HasColumnName("NAMA");

                entity.Property(e => e.Nik)
                    .HasMaxLength(255)
                    .HasColumnName("NIK");

                entity.Property(e => e.Password)
                    .HasMaxLength(2500)
                    .HasColumnName("PASSWORD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
