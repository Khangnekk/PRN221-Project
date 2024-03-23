using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business_Object.Models
{
	public partial class ProjectPRN221Context : DbContext
	{
		public ProjectPRN221Context()
		{
		}

		public ProjectPRN221Context(DbContextOptions<ProjectPRN221Context> options)
			: base(options)
		{
		}

		public virtual DbSet<Area> Areas { get; set; } = null!;
		public virtual DbSet<Group> Groups { get; set; } = null!;
		public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
		public virtual DbSet<Room> Rooms { get; set; } = null!;
		public virtual DbSet<Session> Sessions { get; set; } = null!;
		public virtual DbSet<Subject> Subjects { get; set; } = null!;
		public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				IConfigurationRoot configuration = builder.Build();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			}

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Area>(entity =>
			{
				entity.ToTable("Area");

				entity.Property(e => e.AreaId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("areaId");

				entity.Property(e => e.AreaName)
					.HasMaxLength(150)
					.IsUnicode(false)
					.HasColumnName("areaName");
			});

			modelBuilder.Entity<Group>(entity =>
			{
				entity.ToTable("Group");

				entity.Property(e => e.GroupId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("groupId");

				entity.Property(e => e.LecturerId).HasColumnName("lecturerId");

				entity.Property(e => e.Semester)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("semester");

				entity.Property(e => e.SubjectId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("subjectId");

				entity.Property(e => e.Year)
					.HasMaxLength(10)
					.HasColumnName("year")
					.IsFixedLength();

				entity.HasOne(d => d.Subject)
					.WithMany(p => p.Groups)
					.HasForeignKey(d => d.SubjectId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Group_Subject");
			});

			modelBuilder.Entity<Lecturer>(entity =>
			{
				entity.ToTable("Lecturer");

				entity.Property(e => e.LecturerId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("lecturerId");

				entity.Property(e => e.LecturerDob)
					.HasColumnType("datetime")
					.HasColumnName("lecturerDob");

				entity.Property(e => e.LecturerEmail)
					.HasMaxLength(150)
					.IsUnicode(false)
					.HasColumnName("lecturerEmail");

				entity.Property(e => e.LecturerGender).HasColumnName("lecturerGender");

				entity.Property(e => e.LecturerName)
					.HasMaxLength(255)
					.HasColumnName("lecturerName");

				entity.Property(e => e.LecturerPhone)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("lecturerPhone");
			});

			modelBuilder.Entity<Room>(entity =>
			{
				entity.ToTable("Room");

				entity.Property(e => e.RoomId).HasColumnName("roomId");

				entity.Property(e => e.AreaId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("areaId");

				entity.Property(e => e.RoomName)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("roomName");

				entity.HasOne(d => d.Area)
					.WithMany(p => p.Rooms)
					.HasForeignKey(d => d.AreaId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Room_Area");
			});

			modelBuilder.Entity<Session>(entity =>
			{
				entity.ToTable("Session");

				entity.Property(e => e.SessionId).HasColumnName("sessionId");

				entity.Property(e => e.Date)
					.HasColumnType("datetime")
					.HasColumnName("date");

				entity.Property(e => e.GroupId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("groupId");

				entity.Property(e => e.LecturerId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("lecturerId");

				entity.Property(e => e.RoomId).HasColumnName("roomId");

				entity.Property(e => e.TimeslotId).HasColumnName("timeslotId");

				entity.HasOne(d => d.Group)
					.WithMany(p => p.Sessions)
					.HasForeignKey(d => d.GroupId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_Group");

				entity.HasOne(d => d.Lecturer)
					.WithMany(p => p.Sessions)
					.HasForeignKey(d => d.LecturerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_Lecturer");

				entity.HasOne(d => d.Room)
					.WithMany(p => p.Sessions)
					.HasForeignKey(d => d.RoomId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_Room");

				entity.HasOne(d => d.Timeslot)
					.WithMany(p => p.Sessions)
					.HasForeignKey(d => d.TimeslotId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_TimeSlot");
			});

			modelBuilder.Entity<Subject>(entity =>
			{
				entity.ToTable("Subject");

				entity.Property(e => e.SubjectId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("subjectId");

				entity.Property(e => e.SubjectName)
					.HasMaxLength(255)
					.IsUnicode(false)
					.HasColumnName("subjectName");
			});

			modelBuilder.Entity<TimeSlot>(entity =>
			{
				entity.ToTable("TimeSlot");

				entity.Property(e => e.TimeslotId).HasColumnName("timeslotId");

				entity.Property(e => e.TimeslotDescription)
					.HasMaxLength(255)
					.IsUnicode(false)
					.HasColumnName("timeslotDescription");

				entity.Property(e => e.TimeslotName)
					.HasMaxLength(255)
					.IsUnicode(false)
					.HasColumnName("timeslotName");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
