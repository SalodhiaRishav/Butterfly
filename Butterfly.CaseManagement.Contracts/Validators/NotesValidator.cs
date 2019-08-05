namespace Butterfly.CaseManagement.Contracts.Validators
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using FluentValidation;

    public class NotesValidator : AbstractValidator<NotesDto>
    {
        public NotesValidator()
        {
            RuleFor(notes => notes.NotesByCpa).MaximumLength(200);
        }
    }
}