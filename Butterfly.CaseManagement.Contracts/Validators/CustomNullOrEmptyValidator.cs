namespace Butterfly.CaseManagement.Contracts.Validators
{
    using FluentValidation;

    public static class CustomNullOrEmptyValidator
    {
        public static IRuleBuilderOptions<T, string> CheckNull<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, item, context) =>
            {
                if (item == null && item != "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            })
            .WithMessage("'{PropertyName}' should not be null.");
        }

        public static IRuleBuilderOptions<T, string> CheckEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, item, context) =>
            {
                if (item == "" && item != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            })
            .WithMessage("'{PropertyName}' should not be empty.");
        }
    }
}
