namespace CTDS.CaseManagement.Contracts.Validators
{
    using CTDS.CaseManagement.Contracts.Dto;

    using FluentValidation;

    public class NotesValidator : AbstractValidator<NotesDto>
    {
        public NotesValidator()
        {
            RuleFor(notes => notes.NotesByCpa).MaximumLength(200);
        }
    }
}