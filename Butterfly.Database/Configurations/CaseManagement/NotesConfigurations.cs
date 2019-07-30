namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    public class NotesConfigurations : EntityTypeConfiguration<Notes>
    {
        public NotesConfigurations()
        {
            this.HasKey<int>(notes => notes.Id);

            this.Property(notes => notes.NotesByCpa)
                .HasMaxLength(200);
        }
    }
}
